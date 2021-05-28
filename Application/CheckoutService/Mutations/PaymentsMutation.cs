namespace CheckoutService.Mutations
{
    using System.Linq;
    using System.Threading.Tasks;
    using CheckoutService.InputTypes;
    using CheckoutService.Models;
    using CheckoutService.Resolvers;
    using Crosscutting.Helpers;
    using HotChocolate;
    using HotChocolate.Types;

    [ExtendObjectType("CheckoutMutation")]
    public class PaymentsMutation
    {
        public async Task<Payment> CheckoutCart(
            [Service] PaymentsResolver resolver,
            string cartId,
            string addressId,
            string prescriptionId,
            string productIds,
            string customerId,
            string paymentInfoId,
            string amount)
        {
            var orderItems = !string.IsNullOrWhiteSpace(productIds)
                ? DataTransferHelper.IdsFromString(productIds)
                : default;
            
            return await resolver.CheckoutOrder(orderItems?.Select(o => new OrderItem
            {
                Price = "",
                Quantity = "1",
                ProductId = o
            }), prescriptionId, cartId, customerId, addressId, paymentInfoId, amount);
        }
    }
}