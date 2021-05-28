namespace Crosscutting.MessageBroker
{
    using System;
    using System.Text;
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    public class RabbitMQClient
    {
        private readonly IModel _channel;
        
        public RabbitMQClient()
        {
            var factory = new ConnectionFactory()
            {
                HostName = AppConfigurations.RabbitMQHost,
                UserName = AppConfigurations.RabbitMQUsername,
                Password = AppConfigurations.RabbitMQPassword,
                Port = AppConfigurations.RabbitMQPort
            };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();  
        }

        public virtual void PushMessage(string routingKey, object message)
        {
            _channel.QueueDeclare(queue: "message",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            
            string msgJson = JsonConvert.SerializeObject(message);
            
            var body = Encoding.UTF8.GetBytes(msgJson);
            _channel.BasicPublish(exchange: "message",
                routingKey: routingKey,
                basicProperties: null,
                body: body);
        }
        
        public void Subscribe(string message)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };
            _channel.BasicConsume(queue: "hello",
                autoAck: true,
                consumer: consumer);
        }
    }
}