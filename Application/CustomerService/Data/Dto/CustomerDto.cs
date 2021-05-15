namespace CustomerService.Data.Dto
{
    using MongoDB.Bson;

    public class CustomerDto
    {
        public ObjectId Id { get; set; }

        public string CustomerId { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string DiscountCard { get; set; }
        
        public string CartId { get; set; }
        
        public string WishlistId { get; set; }
        
        public string[] Addresses { get; set; }
    }
}