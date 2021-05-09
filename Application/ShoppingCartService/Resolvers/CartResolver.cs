using System.Collections.Generic;
using System.Linq;
using ProductService.Data;
using ProductService.Models;

namespace ProductService.Resolvers
{
    using ShoppingCartService.Models;

    public class ProductsResolver
    {
        private readonly ApplicationDbContext _context;
        
        public ProductsResolver(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public Cart Cart()
        {
            return _context.Products.Select(productDto => new Cart
            {
                Id = productDto.ProductId,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                Color = productDto.Color,
                Size = productDto.Size
            });
        }
    }
}