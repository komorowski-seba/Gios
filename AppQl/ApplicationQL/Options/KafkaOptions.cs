namespace Application.Options;

public class KafkaOptions
{
    public string? BootstrapServer { get; init; }
    public string? Topic { get; init; }
    public string? Key { get; init; }
}