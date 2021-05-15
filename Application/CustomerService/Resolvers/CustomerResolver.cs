namespace CustomerService.Resolvers
{
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
                Addresses = DataTransferHelper.ProductIdsToString(queryResult.Addresses),
                DiscountCard = queryResult.DiscountCard,
                WishlistId = queryResult.WishlistId
            } : default;
        }

        public IQueryable<Customer> Customers()
        {
            return _repository.GetCustomers().Select(c => new Customer
            {
                Id = c.CustomerId,
                CartId = c.CartId,
                Name = c.Name,
                Email = c.Email,
                Addresses = DataTransferHelper.ProductIdsToString(c.Addresses),
                DiscountCard = c.DiscountCard,
                WishlistId = c.WishlistId
            });
        }
    }
}