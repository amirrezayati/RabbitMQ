using MassTransit;
using Microsoft.OpenApi.Models;
using RabbitMQ.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddBus(b => Bus.Factory.CreateUsingRabbitMq(r =>
    {
        r.Host(new Uri(RabbitMqConsts.RabbitMqRootUri), h =>
        {
            h.Username(RabbitMqConsts.UserName);
            h.Password(RabbitMqConsts.Password);
        });
    }));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RabbitMQ.Producer", Version = "v1" });
});
var app = builder.Build();
    
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
