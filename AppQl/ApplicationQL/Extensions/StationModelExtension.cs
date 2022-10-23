using Application.Models.Cache;
using Domain.Entities;

namespace ApplicationQl.Extensions;

public static class StationModelExtension
{
    public static Station ToEntityStation(this Models.GiosStation.Station station)
    {
        var result = Station.Create(
            station.Id,
            station.StationName,
            station.GegrLat,
            station.GegrLon,
            station.AddressStreet,
            station.City?.Name ?? "[NULL]",
            station.City?.Commune?.DistrictName ?? "[NULL]",
            station.City?.Commune?.ProvinceName ?? "[NULL]");
        return result;
    }
}