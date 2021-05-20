namespace CheckoutService.Resolvers
{
    using System;
    using System.Threading.Tasks;
    using CheckoutService.Data;
    using CheckoutService.Data.Dto;
    using CheckoutService.Models;
    using Crosscutting.Helpers;
    using MongoDB.Bson;

    public class PaymentsResolver
    {
        private readonly PaymentsRepository _repository;

        public PaymentsResolver(PaymentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Payment> GetPayment(string id)
        {
            var queryResult = await _repository.GetPayment(id);
            if (queryResult == null)
                return default;

            return new Payment
            {
                Id = queryResult.PaymentId,
                Date = queryResult.Date,
                Amount = queryResult.Amount,
                OrderId = queryResult.OrderId,
                PaymentInfoId = queryResult.PaymentInfoId
            };
        }

        public async Task<Payment> CreatePayment(Payment payment)
        {
            if (!ValidPayment(payment))
            {
                throw new ArgumentException("Invalid payment provided");
            }

            var mutationResult = await _repository.CreatePayment(new PaymentDto
            {
                PaymentId = IdGenerationHelper.GenerateId(10),
                CustomerId = payment.CustomerId,
                Date = payment.Date,
                Amount = payment.Amount,
                OrderId = payment.OrderId,
                PaymentInfoId = payment.PaymentInfoId
            });

            if (mutationResult == null)
                return default;

            return new Payment
            {
                Id = mutationResult.PaymentId,
                Date = mutationResult.Date,
                Amount = mutationResult.Amount,
                OrderId = mutationResult.OrderId,
                PaymentInfoId = mutationResult.PaymentInfoId
            };
        }

        private bool ValidPayment(Payment payment) => string.IsNullOrWhiteSpace(payment.CustomerId) ||
                                                      string.IsNullOrWhiteSpace(payment.Amount) ||
                                                      string.IsNullOrWhiteSpace(payment.Date) ||
                                                      string.IsNullOrWhiteSpace(payment.OrderId) ||
                                                      string.IsNullOrWhiteSpace(payment.PaymentInfoId);
    }
}