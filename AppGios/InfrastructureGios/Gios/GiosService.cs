using ApplicationGios.Extensions;
using ApplicationGios.Interfaces;
using ApplicationGios.Options;
using DomainGios.Entities;
using Microsoft.Extensions.Options;
using RestSharp;
using Shareed.Models;

namespace InfrastructureGios.Gios;

public sealed class GiosService : IGiosService
{
    private GiosOptions _giosOptions;
    
    public GiosService(IOptions<GiosOptions> giosOptions)
    {
        _giosOptions = giosOptions.Value;
    }
    
    public async Task<IList<Station>?> GetAllStations(CancellationToken cancellationToken)
    {
        var client = new RestClient(_giosOptions.StationsUrl ?? throw new NullReferenceException(nameof(_giosOptions.StationsUrl)));
        var request = new RestRequest(Method.GET);
        var response = await client.GetAsync<IRestResponse<IList<Station>>>(request, cancellationToken);
        
        if (!response.IsSuccessful)
            throw new HttpRequestException(response.ErrorException?.Message ?? string.Empty);
            
        return response.Data;
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