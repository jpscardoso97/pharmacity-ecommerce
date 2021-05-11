namespace CustomerService.Resolvers
{
    using System.Linq;
    using System.Threading.Tasks;
    using ShoppingCartService.Data;
    using ShoppingCartService.Models;

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
            return new Customer
            {
                CustomerId = queryResult.CustomerId,
                CartId = queryResult.CartId,
                Name = queryResult.Name,
                Email = queryResult.Email,
                Addresses = queryResult.Addresses,
                DiscountCard = queryResult.DiscountCard,
                WishlistId = queryResult.WishlistId
            };
        }

        public IQueryable<Customer> Customers()
        {
            return _repository.GetCustomers().Select(c => new Customer
            {
                CustomerId = c.CustomerId,
                CartId = c.CartId,
                Name = c.Name,
                Email = c.Email,
                Addresses = c.Addresses,
                DiscountCard = c.DiscountCard,
                WishlistId = c.WishlistId
            });
        }
    }
}