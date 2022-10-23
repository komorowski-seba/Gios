namespace ApplicationGios.Options;

public class KafkaOpions
{
    public string? BootstrapServer { get; init; }
    public string? Key { get; init; }
    public string? Topic { get; init; }
}