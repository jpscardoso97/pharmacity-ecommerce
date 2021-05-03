using System.Collections.Generic;

namespace ProductService.Models
{
    public class Catalog
    {
        public string CatalogId { get; set; }
        
        public IEnumerable<Product> Products { get; set; }
    }
}