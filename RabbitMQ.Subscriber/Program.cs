using MassTransit;
using RabbitMQ.Shared;
using RabbitMQ.Subscriber;

Console.Title = "Notification";
var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(new Uri(RabbitMqConsts.RabbitMqRootUri), h =>
    {
        h.Username(RabbitMqConsts.UserName);
        h.Password(RabbitMqConsts.Password);
    });
    cfg.ReceiveEndpoint("todoQueue", ep =>
    {
        ep.AutoDelete = false;
        ep.Durable = true;
        ep.PrefetchCount = 16;
        ep.UseMessageRetry(r => r.Interval(2, 100));
        ep.Consumer<TodoConsumerNotification>();
    });

});

bus.StartAsync();
Console.WriteLine("Listening for Todo registered events.. Press enter to exit");
Console.ReadLine();
bus.StopAsync();