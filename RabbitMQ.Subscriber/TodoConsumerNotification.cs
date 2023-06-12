using MassTransit;
using RabbitMQ.Shared;

namespace RabbitMQ.Subscriber
{
    public class TodoConsumerNotification : IConsumer<ModelShared>
    {
        public async Task Consume(ConsumeContext<ModelShared> context)
        {
            await Console.Out.WriteLineAsync($"Notification sent: ModelShared id {context.Message.Id}");
        }
    }
}
