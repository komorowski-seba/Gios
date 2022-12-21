using System.Net;
using ApplicationGios.Extensions;
using ApplicationGios.Interfaces;
using ApplicationGios.Options;
using DomainGios.Entities;
using Microsoft.Extensions.Options;
using Polly;
using RestSharp;
using Shareed.Models;

namespace InfrastructureGios.Gios;

public sealed class GiosService : IGiosService
{
    private GiosOptions _giosOptions;
    private IAsyncPolicy<IRestResponse<string>> asyncPolicy = Policy<IRestResponse<string>>
            .Handle<HttpRequestException>()
            .OrResult(n => n.StatusCode is >= HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout)
            .WaitAndRetryAsync(10, i => TimeSpan.FromSeconds(i + 2));
    
    public GiosService(IOptions<GiosOptions> giosOptions)
    {
        _giosOptions = giosOptions.Value;
    }
    
    public async Task<IList<Station>?> GetAllStations(CancellationToken cancellationToken)
    {
        var client = new RestClient(_giosOptions.StationsUrl ?? throw new NullReferenceException(nameof(_giosOptions.StationsUrl)));
        var request = new RestRequest(Method.GET);
        // var response = await client.GetAsync<string>(request, cancellationToken);
        
        var i = await asyncPolicy
            .ExecuteAsync(async () => await client.GetAsync<IRestResponse<string>>(request, cancellationToken).ConfigureAwait(false))
            .ConfigureAwait(false);
        
        // if (!response.IsSuccessful)
        //     throw new HttpRequestException(response.ErrorException?.Message ?? string.Empty);
        return new List<Station>();
        // return response.Data;
    }

    public async Task<IEnumerable<AirQualityIndexModel>> GetStationAirQuality(long stationId)
    {
        var client = new RestClient($"{_giosOptions.QualityUrl}/{stationId}");
        var request = new RestRequest(Method.GET);

        var response = await client.GetAsync<IRestResponse<AirQualityIndex>>(request);
        if (!response.IsSuccessful)
            throw new HttpRequestException(response.ErrorException?.Message ?? string.Empty);

        return response.Data.ToAirQualityIndexModel();
    }
}