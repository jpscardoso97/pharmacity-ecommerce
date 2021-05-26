namespace CheckoutService.Data.Fakes
{
    using System.Collections.Generic;
    using Bogus;
    using CheckoutService.Data.Dto;
    using Crosscutting.Helpers;

    public class FakePayments
    {
        private const int CountPayments = 5;

        public static IEnumerable<PaymentDto> Data => new Faker<PaymentDto>()
            .RuleFor(p => p.PaymentId, (f, p) => $"PAY-{f.UniqueIndex}")
            .RuleFor(p => p.Amount, f => f.Commerce.Price())
            .RuleFor(p => p.CustomerId, f => f.Commerce.Price())
            .RuleFor(p => p.Date, f => DateHelper.GenerateReadableDateTime(f.Date.Recent(10)))
            .RuleFor(p => p.PaymentInfoId, f => f.Date.Recent(10).ToShortDateString())
            .Generate(CountPayments);

    }
}