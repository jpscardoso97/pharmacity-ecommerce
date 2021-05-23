namespace ShoppingCartService.Mutations
{
    using System.Threading.Tasks;
    using HotChocolate;
    using HotChocolate.Types;
    using ShoppingCartService.Models;
    using ShoppingCartService.Resolvers;

    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class CartMutations
    {
        public async Task<Cart> AddItemToCart([Service] CartResolver resolver, string cartId, string productId)
        {
            return await resolver.AddToCart(cartId, productId);
        }
    }
}