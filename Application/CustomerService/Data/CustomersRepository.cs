namespace ShoppingCartService.Data
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using CustomerService.Data.Dto;
    using CustomerService.Data.Fakes;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class CustomersRepository
    {
        private readonly IMongoCollection<CustomerDto> _customersCollection;

        public CustomersRepository(IMongoCollection<CustomerDto> customersCollection)
        {
            _customersCollection = customersCollection
                                   ?? throw new ArgumentNullException(nameof(customersCollection));
            if (_customersCollection.EstimatedDocumentCount() == 0)
            {
                _customersCollection.InsertMany(FakeCustomers.Data());
            }
        }
        
        public Task<CustomerDto> GetCustomerAsync(string customerId, CancellationToken cancellationToken)
        {
            return _customersCollection.Find(c => c.Id == ObjectId.Parse(customerId))
                .FirstOrDefaultAsync(cancellationToken);
        } 
        
        public IQueryable<CustomerDto> GetCustomers()
        {
            return _customersCollection.AsQueryable();
        } 
    }
}