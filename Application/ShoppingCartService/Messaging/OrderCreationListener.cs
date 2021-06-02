namespace ShoppingCartService.Messaging
{
    using System;
    using Crosscutting.MessageBroker;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using ShoppingCartService.Resolvers;

    public class OrderCreationListener : RabbitMQListener
    {
        private readonly IServiceProvider _services;

        public OrderCreationListener(IServiceProvider services)
        {
            base.RouteKey = "order.created";
            base.QueueName = "messages";
            _services = services;
        }

        public override bool Process(string message)
        {
            var taskMessage = JsonConvert.DeserializeObject<OrderCreatedMessage>(message);
            
            if (taskMessage == null)
            {
                // When false is returned, the message is rejected directly, indicating that it cannot be processed
                return false;
            }

            try
            {
                using (var scope = _services.CreateScope())
                {
                    var cartsResolver = scope.ServiceProvider.GetRequiredService<CartResolver>();
                    cartsResolver.ClearCart(taskMessage.CartId);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        private class OrderCreatedMessage
        {
            public string CartId { get; set; }
            
            public string OrderId { get; set; }
        }
    }
}