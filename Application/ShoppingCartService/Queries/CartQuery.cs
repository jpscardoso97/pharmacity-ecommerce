namespace ShoppingCartService.Queries
{
    using System.Linq;
    using System.Threading.Tasks;
    using HotChocolate;
    using ShoppingCartService.Models;
    using ShoppingCartService.Resolvers;

    public class CartQuery
    {
        public IQueryable<Cart> GetCarts([Service] CartResolver resolver)
        {
            return resolver.Carts();
        }
        
        public async Task<Cart> GetCart([Service] CartResolver resolver, string cartId)
        {
            return await resolver.Cart(cartId);
        }
    }
}