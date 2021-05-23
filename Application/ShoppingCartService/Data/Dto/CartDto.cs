namespace ShoppingCartService.Data.Dto
{
    using System.Collections.Generic;
    using MongoDB.Bson;

    public class CartDto
    {
        public ObjectId Id { get; set; }

        public string CartId { get; set; }

        public IList<string> ProductIds { get; set; }
    }
}