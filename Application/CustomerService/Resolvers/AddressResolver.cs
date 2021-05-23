namespace CustomerService.Resolvers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Crosscutting.Helpers;
    using CustomerService.Data;
    using CustomerService.Models;

    public class AddressResolver
    {
        private readonly AddressesRepository _repository;

        public AddressResolver(AddressesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Address> Address(string id)
        {
            var queryResult = await _repository.GetAddressAsync(id, default);
            return queryResult != null ? new Address
            {
                Id = queryResult.AddressId,
                City = queryResult.City,
                Country = queryResult.Country,
                Phone = queryResult.Phone,
                DeliveryAddress = queryResult.DeliveryAddress,
                ZipCode = queryResult.ZipCode
            } : default;
        }

        public IQueryable<Address> Addresses(string ids)
        {
            var addressIds = DataTransferHelper.IdsFromString(ids);
            return _repository.GetAddresses().Where(a => addressIds.Contains(a.AddressId)).Select(c => new Address
            {
                Id = c.AddressId,
                City = c.City,
                Country = c.Country,
                Phone = c.Phone,
                DeliveryAddress = c.DeliveryAddress,
                ZipCode = c.ZipCode
            });
        }
    }
}