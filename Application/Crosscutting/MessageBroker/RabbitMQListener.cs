namespace Crosscutting.MessageBroker
{
    using System;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    public class RabbitMQListener : IHostedService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQListener()
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    // This is my configuration. Just change it to my own use
                    HostName = AppConfigurations.RabbitMQHost,
                    UserName = AppConfigurations.RabbitMQUsername,
                    Password = AppConfigurations.RabbitMQPassword,
                    Port = AppConfigurations.RabbitMQPort
                };

                this._connection = factory.CreateConnection();
                this._channel = _connection.CreateModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RabbitListener init error,ex:{ex.Message}");
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Register();
            return Task.CompletedTask;
        }

        protected string RouteKey;
        protected string QueueName;

        // How to process messages
        public virtual bool Process(string message)
        {
            throw new NotImplementedException();
        }

        // Registered consumer monitoring here
        public void Register()
        {
            Console.WriteLine($"RabbitMQListener register,routeKey:{RouteKey}");
            
            _channel.ExchangeDeclare(exchange: "message", type: "topic");
            _channel.QueueDeclare(queue: QueueName, exclusive: false);
            _channel.QueueBind(queue: QueueName,
                exchange: "message",
                routingKey: RouteKey);
            
            var consumer = new EventingBasicConsumer(_channel);
            
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body.Span);
                var result = Process(message);
                if (result)
                {
                    _channel.BasicAck(ea.DeliveryTag, false);
                }
            };
            _channel.BasicConsume(queue: QueueName, consumer: consumer);
        }

        public void DeRegister()
        {
            this._connection.Close();
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            this._connection.Close();
            return Task.CompletedTask;
        }
    }
}