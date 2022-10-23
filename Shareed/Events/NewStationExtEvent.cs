using Shareed.Interfaces;
using Shareed.Models;

namespace Shareed.Events;

public sealed class NewStationExtEvent : IExternalEvent
{
    public Guid Id { get; set; }
    public StationModel? NewStation { get; set; }
}