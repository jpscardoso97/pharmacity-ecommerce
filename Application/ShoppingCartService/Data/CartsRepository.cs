namespace ShoppingCartService.Data
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MongoDB.Bson;
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
        
        public IQueryable<CartDto> GetCartsAsync()
        {
            return _cartsCollection.AsQueryable();
        } 
    }
}