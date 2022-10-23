using ApplicationGios.Options;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shareed.Interfaces;

namespace InfrastructureGios.Kafka;

public class KafkaExternalEventPushService<T> : IExternalEventService<T>, IDisposable
    where T: class, IExternalEvent
{
     private readonly Lazy<IProducer<string, string>> _producer;
     private readonly ILogger<KafkaExternalEventPushService<T>> _logger;
     private readonly KafkaOpions _kafkaOpions;

     public KafkaExternalEventPushService(
         ILogger<KafkaExternalEventPushService<T>> logger, 
         IOptions<KafkaOpions> kafkaOpions)
     {
         _logger = logger;
         _kafkaOpions = kafkaOpions.Value;
         _producer = new Lazy<IProducer<string, string>>(
             () => new ProducerBuilder<string, string>(new ConsumerConfig
             {
                 BootstrapServers = _kafkaOpions.BootstrapServer,
                 AutoOffsetReset = AutoOffsetReset.Earliest,
                 EnableAutoCommit = true,
             })
            .Build());
     }

     private async Task SendAsync(T msg)
     {
         var serialisedMessage = JsonConvert.SerializeObject(msg);
         var messageType = msg.GetType().Name;
         try
         {
             var producedMessage = new Message<string, string>
             {
                 Key = _kafkaOpions.Key ?? throw new NullReferenceException($"Config Kafka Key is null"),
                 Value = serialisedMessage,
             };
             Console.WriteLine($" ==> send: {producedMessage.Value}");
             await _producer.Value.ProduceAsync(_kafkaOpions.Topic, producedMessage);
         }
         catch (Exception e)
         {
             _logger.LogWarning(
                 "I can't send a Message: '{Message}'; Type: '{Type}'; Key: '{Key}'; Error: '{Ex}'",
                 serialisedMessage,
                 messageType,
                 _kafkaOpions.Key,
                 e.Message); 
         }
     }
     
     public async Task Publish(T evt)
     {
         await SendAsync(evt);
     }

    public void Dispose()
    {
        if (_producer.IsValueCreated)
            _producer.Value.Dispose();
    }
}