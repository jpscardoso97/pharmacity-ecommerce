﻿namespace CheckoutService.Data
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using CheckoutService.Data.Dto;
    using CheckoutService.Data.Fakes;
    using MongoDB.Driver;

    public class PaymentsRepository
    {
        private IMongoCollection<PaymentDto> _paymentsCollection;

        public PaymentsRepository(IMongoCollection<PaymentDto> paymentsCollection)
        {
            _paymentsCollection = paymentsCollection
                                  ?? throw new ArgumentNullException(nameof(paymentsCollection));
            if (_paymentsCollection.EstimatedDocumentCount() == 0)
            {
                _paymentsCollection.InsertMany(FakePayments.Data);
            }
        }

        public async Task<PaymentDto> GetPayment(string paymentId)
        {
            return await _paymentsCollection.Find(p => p.PaymentId == paymentId).FirstOrDefaultAsync();
        }

        public async Task<PaymentDto> CreatePayment(PaymentDto paymentDto)
        {
            await _paymentsCollection.InsertOneAsync(paymentDto,
                new InsertOneOptions(), CancellationToken.None);

            return await _paymentsCollection.Find(p => p.PaymentId == paymentDto.PaymentId).FirstOrDefaultAsync();
        }
    }
}