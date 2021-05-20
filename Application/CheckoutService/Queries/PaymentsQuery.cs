namespace CheckoutService.Queries
{
    using System.Threading.Tasks;
    using CheckoutService.Models;
    using CheckoutService.Resolvers;
    using HotChocolate;
    using HotChocolate.Types;

    [ExtendObjectType(OperationTypeNames.Query)]
    public class PaymentsQuery
    {
        public async Task<Payment> GetPayment([Service] PaymentsResolver resolver, string id)
        {
            return await resolver.GetPayment(id);
        }
    }
}