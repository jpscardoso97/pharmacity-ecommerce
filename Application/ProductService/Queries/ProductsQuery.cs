using System.Collections.Generic;
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

        public IEnumerable<Product> GetProductsById([Service] ProductsResolver resolver, string ids)
        {
            return resolver.ProductsByIds(ids);
        }
    }
}