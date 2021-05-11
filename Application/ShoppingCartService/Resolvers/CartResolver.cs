namespace ShoppingCartService.Resolvers
{
    using System.Linq;
    using System.Threading.Tasks;
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
                OrderId = queryResult.OrderId,
                ProductIds = queryResult.ProductIds
            };
        }

        public IQueryable<Cart> Carts()
        {
            return _repository.GetCartsAsync().Select(c => new Cart
            {
                CartId = c.CartId,
                OrderId = c.OrderId,
                ProductIds = c.ProductIds
            });
        }
    }
}