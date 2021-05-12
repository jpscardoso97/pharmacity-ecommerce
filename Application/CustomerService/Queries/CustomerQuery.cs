namespace CustomerService.Queries
{
    using System.Linq;
    using System.Threading.Tasks;
    using CustomerService.Resolvers;
    using HotChocolate;
    using ShoppingCartService.Models;

    public class CustomerQuery
    {
        public IQueryable<Customer> GetCustomers([Service] CustomerResolver resolver)
        {
            return resolver.Customers();
        }

        public async Task<Customer> GetCustomer([Service] CustomerResolver resolver, string id)
        {
            return await resolver.Customer(id);
        }
    }
}