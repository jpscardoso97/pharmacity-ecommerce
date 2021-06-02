namespace CustomerService.Resolvers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Crosscutting.Helpers;
    using CustomerService.Data;
    using CustomerService.Data.Dto;
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
            return queryResult != null ? FromDto(queryResult) : default;
        }

        public IEnumerable<Address> Addresses(string ids)
        {
            var addressIds = DataTransferHelper.IdsFromString(ids);
            return _repository.GetAddresses()
                .ToList()
                .Where(a => addressIds.Contains(a.AddressId))
                .Select(FromDto);
        }

        private Address FromDto(AddressDto addressDto) => new()
        {
            Id = addressDto.AddressId,
            City = addressDto.City,
            Country = addressDto.Country,
            Phone = addressDto.Phone,
            DeliveryAddress = addressDto.DeliveryAddress,
            ZipCode = addressDto.ZipCode
        };
    }
}