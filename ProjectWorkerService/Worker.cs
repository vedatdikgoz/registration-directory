using System.Drawing;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using WebAppAPI.Services;

namespace ProjectWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly RabbitMQClientService _rabbitMQClientService;
        private IModel _channel;
        public Worker(RabbitMQClientService rabbitMQClientService, ILogger<Worker> logger)
        {
            _rabbitMQClientService=rabbitMQClientService;
            _logger = logger;
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _rabbitMQClientService.Connect();

            _channel.BasicQos(0, 1, false);



            return base.StartAsync(cancellationToken);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {




            var consumer = new AsyncEventingBasicConsumer(_channel);

            _channel.BasicConsume(RabbitMQClientService.QueueName, false, consumer);

            consumer.Received += Consumer_Received;



            return Task.CompletedTask;




        }

        private Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {


            Task.Delay(1000).Wait();


            try
            {
                var customerImageCreatedEvent = JsonSerializer.Deserialize<CustomerImageCreatedEvent>(Encoding.UTF8.GetString(@event.Body.ToArray()));



                var path = Path.Combine(Directory.GetCurrentDirectory(), "C:/Users/vedat/source/repos/registration-directory/WebAppAPI/wwwroot/img/", customerImageCreatedEvent.ImageName);

                var siteName = "wwww.mysite.com";

                using var img = Image.FromFile(path);
                
                using var graphic = Graphics.FromImage(img);

                var font = new Font(FontFamily.GenericMonospace, 40, FontStyle.Bold, GraphicsUnit.Pixel);

                var textSize = graphic.MeasureString(siteName, font);

                var color = Color.FromArgb(128, 255, 255, 255);
                var brush = new SolidBrush(color);

                var position = new Point(img.Width - ((int)textSize.Width + 30), img.Height - ((int)textSize.Height + 30));


                graphic.DrawString(siteName, font, brush, position);

                img.Save("C:/Users/vedat/source/repos/registration-directory/WebAppAPI/wwwroot/img/watermarks/" + customerImageCreatedEvent.ImageName);


                img.Dispose();
                graphic.Dispose();

                _channel.BasicAck(@event.DeliveryTag, false);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }


            return Task.CompletedTask;


        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}