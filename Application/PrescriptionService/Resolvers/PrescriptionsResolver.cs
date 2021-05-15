namespace PrescriptionService.Resolvers
{
    using System.Threading;
    using System.Threading.Tasks;
    using PrescriptionService.Data;
    using PrescriptionService.Models;

    public class PrescriptionsResolver
    {
        private readonly PrescriptionsRepository _repository;

        public PrescriptionsResolver(PrescriptionsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Prescription> GetPrescription(string id)
        {
            var queryResult = await _repository.GetPrescriptionAsync(id, CancellationToken.None);
            if (queryResult == null)
                return default;

            return new Prescription
            {
                Number = queryResult.Number,
                AccessCode = queryResult.AccessCode,
                OptionCode = queryResult.OptionCode,
                Comments = queryResult.Comments,
                Attachment = queryResult.Attachment,
                OrderId = queryResult.OrderId
            };
        }
    }
}