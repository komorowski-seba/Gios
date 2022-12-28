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
    private readonly GiosOptions _giosOptions;
    private readonly IAsyncPolicy<IRestResponse<IList<Station>>> stationsPolicy = Policy<IRestResponse<IList<Station>>>
        .Handle<HttpRequestException>()
        .OrResult(n => n.StatusCode is >= HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout)
        .WaitAndRetryAsync(10, i => TimeSpan.FromSeconds(i + 2));
    private readonly IAsyncPolicy<IRestResponse<AirQualityIndex>> airQualityPolicy = Policy<IRestResponse<AirQualityIndex>>
        .Handle<HttpRequestException>()
        .OrResult(n => n.StatusCode is >= HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout)
        .WaitAndRetryAsync(10, i => TimeSpan.FromSeconds(i + 2));
    
    public GiosService(IOptions<GiosOptions> giosOptions)
    {
        _giosOptions = giosOptions.Value;
    }
    
    public async Task<IList<StationModel>> GetAllStationsAsync(CancellationToken cancellationToken)
    {
        var client = new RestClient(_giosOptions.StationsUrl ?? throw new NullReferenceException(nameof(_giosOptions.StationsUrl)));
        var request = new RestRequest(Method.GET);

        var response = await stationsPolicy
            .ExecuteAsync(async () => await client.ExecuteAsync<IList<Station>>(request, cancellationToken).ConfigureAwait(false))
            .ConfigureAwait(false);
        
        if (!response.IsSuccessful)
            throw new HttpRequestException(response.ErrorException?.Message ?? string.Empty);
        var result = response.Data.Select(n => n.ToSationModel()).ToList();
        return result;
    }

    public async Task<IEnumerable<AirQualityIndexModel>> GetStationAirQualityAsync(long stationId, CancellationToken cancellationToken)
    {
        var client = new RestClient($"{_giosOptions.QualityUrl}/{stationId}");
        var request = new RestRequest(Method.GET);

        var response = await airQualityPolicy
            .ExecuteAsync(async () => await client.ExecuteAsync<AirQualityIndex>(request, cancellationToken).ConfigureAwait(false))
            .ConfigureAwait(false);
            
        if (!response.IsSuccessful)
            throw new HttpRequestException(response.ErrorException?.Message ?? string.Empty);
        return response.Data.ToAirQualityIndexModel();
    }
}