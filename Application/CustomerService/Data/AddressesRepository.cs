namespace CustomerService.Data
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using CustomerService.Data.Dto;
    using CustomerService.Data.Fakes;
    using MongoDB.Driver;

    public class AddressesRepository
    {
        private readonly IMongoCollection<AddressDto> _addressesCollection;

        public AddressesRepository(IMongoCollection<AddressDto> addressesCollection)
        {
            _addressesCollection = addressesCollection
                                   ?? throw new ArgumentNullException(nameof(addressesCollection));
            if (_addressesCollection.EstimatedDocumentCount() == 0)
            {
                _addressesCollection.InsertMany(FakeAddresses.Data);
            }
        }

        public async Task<AddressDto> GetAddressAsync(string addressId, CancellationToken cancellationToken)
        {
            return await _addressesCollection.Find(a => a.AddressId == addressId)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public IQueryable<AddressDto> GetAddresses()
        {
            return _addressesCollection.AsQueryable();
        }
    }
}