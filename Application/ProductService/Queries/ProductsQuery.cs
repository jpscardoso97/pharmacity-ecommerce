using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using ProductService.Models;
using ProductService.Resolvers;

namespace ProductService.Queries
{
    public class ProductsQuery
    {
        public IEnumerable<Product> GetProducts([Service] ProductsResolver resolver)
        {
            return resolver.Products();
        }
    }
}