namespace OrderService.Data
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Crosscutting.Helpers;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using OrderService.Data.Dto;
    using OrderService.Data.Fakes;
    using OrderService.Models;

    public class OrdersRepository
    {
        private readonly IMongoCollection<OrderDto> _ordersCollection;

        public OrdersRepository(IMongoCollection<OrderDto> ordersCollection)
        {
            _ordersCollection = ordersCollection
                                ?? throw new ArgumentNullException(nameof(ordersCollection));
            if (_ordersCollection.EstimatedDocumentCount() == 0)
            {
                _ordersCollection.InsertMany(FakeOrders.Data);
            }
        }

        public async Task<OrderDto> GetOrderAsync(string orderId, CancellationToken cancellationToken)
        {
            return await _ordersCollection.Find(o => o.OrderId == orderId)
                .FirstOrDefaultAsync(cancellationToken);
        }
        
        public async Task<OrderDto> UpdateOrderPaymentIdAsync(string orderId, string paymentId, int paidStatus,CancellationToken cancellationToken)
        {
            return await _ordersCollection.FindOneAndUpdateAsync(
                Builders<OrderDto>.Filter.Eq(o => o.OrderId, orderId),
                Builders<OrderDto>.Update
                    .Set(o => o.PaymentId, paymentId)
                    .AddToSet(o => o.Status, new OrderStatusDto
                    {
                        Date = DateHelper.GenerateReadableDateTime(),
                        Value = paidStatus
                    }));
        }

        public IQueryable<OrderDto> GetOrders(string ids)
        {
            var idsList = DataTransferHelper.IdsFromString(ids);
            return _ordersCollection.AsQueryable().Where(o => idsList.Contains(o.OrderId));
        }

        public async Task<OrderDto> CreateOrder(OrderDto order)
        {
            await _ordersCollection.InsertOneAsync(order,
                new InsertOneOptions(), CancellationToken.None);

            return await _ordersCollection.Find(p => p.OrderId == order.OrderId).FirstOrDefaultAsync();
        }
    }
}