using MassTransit;
using Newtonsoft.Json;
using RabbitMQ.Shared;

namespace RabbitMQ.Producer;

public class ModelCreatedConsumer: IConsumer<ModelShared>
{
    public async Task Consume(ConsumeContext<ModelShared> context)
    {
        var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"OrderCreated message: {jsonMessage}");
    }
}