namespace ShoppingCartService.Resolvers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Crosscutting.Helpers;
    using ShoppingCartService.Data;
    using ShoppingCartService.Models;

    public class CartResolver
    {
        private readonly CartsRepository _repository;

        public CartResolver(CartsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cart> Cart(string id)
        {
            var queryResult = await _repository.GetCartAsync(id, default);
            return new Cart
            {
                CartId = queryResult.CartId,
                ProductIds = DataTransferHelper.IdsToString(queryResult.ProductIds)
            };
        }

        public IEnumerable<Cart> Carts()
        {
            return _repository.GetCarts().ToList().Select(c => new Cart
            {
                CartId = c.CartId,
                ProductIds = DataTransferHelper.IdsToString(c.ProductIds)
            });
        }

        public async Task<Cart> AddToCart(string cartId, string productId)
        {
            var mutationResult = await _repository.AddItem(cartId, productId, default);

            if (mutationResult == null)
                return default;

            return new Cart
            {
                CartId = mutationResult.CartId,
                ProductIds = DataTransferHelper.IdsToString(mutationResult.ProductIds)
            };
        }
    }
}