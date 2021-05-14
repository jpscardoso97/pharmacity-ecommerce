namespace ShoppingCartService.Data.Dto
{
    using MongoDB.Bson;

    public class CartDto
    {
        public ObjectId Id { get; set; }
        
        public string CartId { get; set; }

        public string[] ProductIds { get; set; }
    }
}