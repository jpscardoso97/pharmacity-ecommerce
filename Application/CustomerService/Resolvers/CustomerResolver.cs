namespace CustomerService.Resolvers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Crosscutting.Helpers;
    using CustomerService.Models;
    using ShoppingCartService.Data;

    public class CustomerResolver
    {
        private readonly CustomersRepository _repository;

        public CustomerResolver(CustomersRepository repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Customer(string id)
        {
            var queryResult = await _repository.GetCustomerAsync(id, default);
            return queryResult != null ? new Customer
            {
                Id = queryResult.CustomerId,
                CartId = queryResult.CartId,
                Name = queryResult.Name,
                Email = queryResult.Email,
                Addresses = DataTransferHelper.IdsToString(queryResult.Addresses),
                DiscountCard = queryResult.DiscountCard,
                WishlistId = queryResult.WishlistId,
                Orders = DataTransferHelper.IdsToString(queryResult.Orders)
            } : default;
        }

        public IEnumerable<Customer> Customers()
        {
            return _repository.GetCustomers()?
                .ToList()
                .Select(c => new Customer
            {
                Id = c.CustomerId,
                CartId = c.CartId,
                Name = c.Name,
                Email = c.Email,
                Addresses = DataTransferHelper.IdsToString(c.Addresses),
                DiscountCard = c.DiscountCard,
                WishlistId = c.WishlistId,
                Orders = DataTransferHelper.IdsToString(c.Orders)
            });
        }
    }
}