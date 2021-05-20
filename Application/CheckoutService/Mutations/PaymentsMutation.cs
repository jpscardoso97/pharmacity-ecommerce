namespace CheckoutService.Mutations
{
    using System.Threading.Tasks;
    using CheckoutService.Models;
    using CheckoutService.Resolvers;
    using HotChocolate;
    using HotChocolate.Types;

    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class PaymentsMutation
    {
        public async Task<Payment> CreatePayment([Service] PaymentsResolver resolver, Payment payment)
        {
            return await resolver.CreatePayment(payment);
        }
    }
}