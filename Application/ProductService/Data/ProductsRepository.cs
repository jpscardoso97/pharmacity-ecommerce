namespace ProductService.Data
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using ProductService.Data.Dto;
    using ProductService.Data.Fakes;

    public class ProductsRepository
    {
        private readonly IMongoCollection<ProductDto> _productsCollection;

        public ProductsRepository(IMongoCollection<ProductDto> productsCollection)
        {
            _productsCollection = productsCollection
                                ?? throw new ArgumentNullException(nameof(productsCollection));
            if (_productsCollection.EstimatedDocumentCount() == 0)
            {
                _productsCollection.InsertMany(FakeProducts.Data);
            }
        }

        public async Task<ProductDto> GetProductAsync(string productId, CancellationToken cancellationToken)
        {
            return await _productsCollection.Find(p =>p.ProductId == productId)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public IQueryable<ProductDto> GetProducts()
        {
            return _productsCollection.AsQueryable();
        }
    }
}