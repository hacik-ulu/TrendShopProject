using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace TrendShopProject.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("Queue2", false, false, false, arguments: null);

            var messageContent = "Merhaba bugün hava çok sıcak";

            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

            channel.BasicPublish(exchange: "", routingKey: "Queue2", basicProperties: null, body: byteMessageContent);

            return Ok("Mesajınız Kuyruğa Alınmıştır.");
        }

        [HttpGet]
        public async Task<IActionResult> ReadMessage()
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);

                var tcs = new TaskCompletionSource<string>();

                consumer.Received += (model, x) =>
                {
                    var byteMessage = x.Body.ToArray();
                    var message = Encoding.UTF8.GetString(byteMessage);
                    tcs.SetResult(message);  
                };

                channel.BasicConsume(queue: "Queue2", autoAck: true, consumer: consumer);

                var result = await Task.WhenAny(tcs.Task, Task.Delay(5000));  

                if (result == tcs.Task)
                {
                    return Ok(tcs.Task.Result);  
                }
                else
                {
                    return StatusCode(408, "Request Timeout");  
                }
            }
        }

    }
}

