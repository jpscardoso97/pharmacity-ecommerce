﻿namespace CheckoutService.Resolvers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using CheckoutService.Data;
    using CheckoutService.Data.Dto;
    using CheckoutService.InputTypes;
    using CheckoutService.Models;
    using Crosscutting.Helpers;
    using Newtonsoft.Json;

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
                PaymentInfoId = queryResult.PaymentInfoId
            };
        }

        public async Task<Payment> CheckoutOrder(
            IEnumerable<OrderItem> orderItems,
            string prescriptionId,
            string cartId,
            string customerId,
            string addressId,
            string paymentInfoId,
            string amount)
        {
            if (!ValidPayment(prescriptionId, customerId, addressId, paymentInfoId, cartId, amount))
            {
                throw new ArgumentException("Invalid payment provided");
            }

            var mutationResult = await _repository.CreatePayment(new PaymentDto
            {
                PaymentId = IdGenerationHelper.GenerateId(10),
                CustomerId = customerId,
                Date = DateHelper.GenerateReadableDateTime(),
                Amount = amount,
                PaymentInfoId = paymentInfoId
            });

            if (mutationResult == null)
                return default;

            HttpResponseMessage response = default;

            if (prescriptionId == null)
            {
                if (orderItems == null)
                    throw new ArgumentException("Invalid request");

                response = await ProcessProductsOrder(orderItems, mutationResult.Amount, mutationResult.PaymentId,
                    cartId, customerId, addressId);
            }
            else
            {
                response = await ProcessPrescriptionOrder(prescriptionId, mutationResult.Amount,
                    mutationResult.PaymentId, cartId, customerId, addressId);
            }

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException("Error creating order");

            return new Payment
            {
                Id = mutationResult.PaymentId,
                Date = mutationResult.Date,
                Amount = mutationResult.Amount,
                PaymentInfoId = mutationResult.PaymentInfoId
            };
        }

        private bool ValidPayment(string prescriptionId, string customerId, string addressId, string paymentInfoId, string cartId, string amount) =>
            !string.IsNullOrWhiteSpace(customerId) &&
            !string.IsNullOrWhiteSpace(addressId) &&
            !string.IsNullOrWhiteSpace(paymentInfoId) &&
            (!string.IsNullOrWhiteSpace(prescriptionId) || !string.IsNullOrWhiteSpace(cartId)) &&
            !string.IsNullOrWhiteSpace(amount);

        private async Task<HttpResponseMessage> ProcessProductsOrder(
            IEnumerable<OrderItem> items, 
            string value,
            string paymentId, 
            string cartId,
            string customerId,
            string addressId)
        {
            var request = JsonConvert.SerializeObject(new
            {
                Order = new ProductsOrder
                {
                    Value = value,
                    PaymentId = paymentId,
                    Items = items,
                    CustomerId = customerId,
                    AddressId = addressId
                },
                CartId = cartId
            });

            var client = new HttpClient();

            return await client.PostAsync(
                new Uri("https://localhost:6004/api/orders/products"),
                new StringContent(request, Encoding.UTF8, "application/json"));
        }

        private async Task<HttpResponseMessage> ProcessPrescriptionOrder(
            string prescriptionId, 
            string value,
            string paymentId, 
            string cartId,
            string customerId,
            string addressId)
        {
            var request = JsonConvert.SerializeObject(new
            {
                Order = new PrescriptionOrder
                {
                    Value = value,
                    PaymentId = paymentId,
                    PrescriptionId = prescriptionId,
                    CustomerId = customerId,
                    AddressId = addressId
                },
                CartId = cartId
            });
            
            var client = new HttpClient();

            return await client.PostAsync(
                new Uri("https://localhost:6004/api/orders/prescription"),
                new StringContent(request, Encoding.UTF8, "application/json"));
        }
    }
}