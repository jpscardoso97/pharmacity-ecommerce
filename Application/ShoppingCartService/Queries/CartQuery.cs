namespace ShoppingCartService.Queries
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HotChocolate;
    using HotChocolate.Types;
    using ShoppingCartService.Models;
    using ShoppingCartService.Resolvers;

    
    [ExtendObjectType(OperationTypeNames.Query)]
    public class CartQuery
    {
        public IEnumerable<Cart> GetCarts([Service] CartResolver resolver)
        {
            return resolver.Carts();
        }
        
        public async Task<Cart> GetCart([Service] CartResolver resolver, string cartId)
        {
            return await resolver.Cart(cartId);
        }
    }
}