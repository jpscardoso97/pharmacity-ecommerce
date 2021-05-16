namespace CheckoutService.Data.Fakes
{
    using System.Collections.Generic;
    using Bogus;
    using CheckoutService.Data.Dto;

    public class FakePayments
    {
        private const int CountPayments = 5;

        public static IEnumerable<PaymentDto> Data => new Faker<PaymentDto>()
            .RuleFor(p => p.Id, f => f.UniqueIndex)
            .RuleFor(p => p.PaymentId, (f, p) => $"PAY-{p.Id}")
            .RuleFor(p => p.Amount, f => f.Commerce.Price())
            .RuleFor(p => p.Date, f => f.Date.Recent(10).ToShortDateString())
            .RuleFor(p => p.OrderId, (f, p) => $"ORD-{p.Id}")
            .RuleFor(p => p.PaymentInfoId, f => f.Date.Recent(10).ToShortDateString())
            .Generate(CountPayments);

    }
}