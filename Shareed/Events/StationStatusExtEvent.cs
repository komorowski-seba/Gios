using Shareed.Interfaces;
using Shareed.Models;

namespace Shareed.Events;

public sealed class StationStatusExtEvent : IExternalEvent
{
    public Guid Id { get; set; }
    public AirQualityIndexModel? Status { get; set; } 
}