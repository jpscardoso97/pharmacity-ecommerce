namespace ShoppingCartService.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using ShoppingCartService.Data.Dto;
    using ShoppingCartService.Data.Fakes;

    public class CartsRepository
    {
        private readonly IMongoCollection<CartDto> _cartsCollection;

        public CartsRepository(IMongoCollection<CartDto> cartsCollection)
        {
            _cartsCollection = cartsCollection
                               ?? throw new ArgumentNullException(nameof(cartsCollection));
            if (_cartsCollection.EstimatedDocumentCount() == 0)
            {
                _cartsCollection.InsertMany(FakeCarts.Data);
            }
        }

        public async Task<CartDto> GetCartAsync(string cartId, CancellationToken cancellationToken)
        {
            return await _cartsCollection.Find(c => c.CartId == cartId)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public IQueryable<CartDto> GetCarts()
        {
            return _cartsCollection.AsQueryable();
        }

        public async Task<CartDto> AddItem(string cartId, string productId, CancellationToken cancellationToken)
        {
            await _cartsCollection.UpdateOneAsync(c => c.CartId == cartId,
                Builders<CartDto>.Update.AddToSet(c => c.ProductIds, productId), cancellationToken: cancellationToken);

            return await GetCartAsync(cartId, cancellationToken);
        }

        public async Task ClearCart(string cartId, CancellationToken cancellationToken)
        {
            await _cartsCollection.UpdateOneAsync(c => c.CartId == cartId,
                Builders<CartDto>.Update.Set(c => c.ProductIds, new List<string>()), cancellationToken: cancellationToken);
        }
    }
}