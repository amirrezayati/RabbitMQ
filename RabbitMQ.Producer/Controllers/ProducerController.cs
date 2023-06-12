using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Shared;

namespace RabbitMQ.Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IPublishEndpoint _publishEndpoint;

        public ProducerController(IBus bus, IPublishEndpoint publishEndpoint)
        {
            _bus = bus;
            _publishEndpoint = publishEndpoint;

        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(ModelShared? modelShared)
        {
            if (modelShared is null)
                return BadRequest();

            Uri uri = new Uri(RabbitMqConsts.RabbitMqUri);
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(modelShared);

            //await _publishEndpoint.Publish<ModelShared>(new
            //{
            //    modelShared.Id,
            //    modelShared.CreatedTime,
            //    modelShared.Description,
            //    modelShared.IsCompleted
            //});
            return Ok();

        }
    }
}