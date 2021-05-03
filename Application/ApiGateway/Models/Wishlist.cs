using System.Collections.Generic;

namespace ApiGateway.Models
{
    public class Wishlist
    {
        public IEnumerable<Product> Items { get; set; }
    }
}