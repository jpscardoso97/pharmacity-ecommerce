namespace CustomerService.Queries
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CustomerService.Models;
    using CustomerService.Resolvers;
    using HotChocolate;

    public class CustomerQuery
    {
        public IEnumerable<Customer> GetCustomers([Service] CustomerResolver resolver)
        {
            return resolver.Customers();
        }

        public async Task<Customer> GetCustomer([Service] CustomerResolver resolver, string id)
        {
            return await resolver.Customer(id);
        }
        
        public IEnumerable<Address> GetAddresses([Service] AddressResolver resolver, string ids)
        {
            return resolver.Addresses(ids);
        }

        public async Task<Address> GetAddress([Service] AddressResolver resolver, string id)
        {
            return await resolver.Address(id);
        }
    }
}