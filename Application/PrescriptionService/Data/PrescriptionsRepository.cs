namespace PrescriptionService.Data
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using PrescriptionService.Data.Dto;
    using PrescriptionService.Data.Fakes;

    public class PrescriptionsRepository
    {
        private readonly IMongoCollection<PrescriptionDto> _prescriptionsCollection;

        public PrescriptionsRepository(IMongoCollection<PrescriptionDto> prescriptionsCollection)
        {
            _prescriptionsCollection = prescriptionsCollection
                                ?? throw new ArgumentNullException(nameof(prescriptionsCollection));
            if (_prescriptionsCollection.EstimatedDocumentCount() == 0)
            {
                _prescriptionsCollection.InsertMany(FakePrescriptions.Data);
            }
        }

        public async Task<PrescriptionDto> GetPrescriptionAsync(string prescriptionNumber, CancellationToken cancellationToken)
        {
            return await _prescriptionsCollection.Find(o => o.Number == prescriptionNumber)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}