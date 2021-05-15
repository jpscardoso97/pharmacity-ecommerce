namespace PrescriptionService.Data.Fakes
{
    using Bogus;
    using PrescriptionService.Data.Dto;

    public static class FakePrescriptions
    {
        private const int CountPrescriptions = 5;

        public static PrescriptionDto[] Data => new Faker<PrescriptionDto>()
            .RuleFor(p => p.Id, f => f.UniqueIndex)
            .RuleFor(p => p.Number, (f, p) => $"000000000{p.Id}")
            .RuleFor(p => p.AccessCode, f => f.Internet.Password())
            .RuleFor(p => p.OptionCode, f => f.Random.Number(1000,9999).ToString())
            .RuleFor(p => p.Attachment, f => f.Internet.Url())
            .RuleFor(p => p.Comments, f => f.Lorem.Sentence())
            .RuleFor(p => p.OrderId, (f, p) => $"ORD-{p.Id}")
            .Generate(CountPrescriptions).ToArray();
    }
}