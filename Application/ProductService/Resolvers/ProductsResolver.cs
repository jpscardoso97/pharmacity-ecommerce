using System.Collections.Generic;
using System.Linq;
using ProductService.Data;
using ProductService.Models;

namespace ProductService.Resolvers
{
    using System;
    using Crosscutting.Helpers;

    public class ProductsResolver
    {
        private readonly ApplicationDbContext _context;

        public ProductsResolver(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Products()
        {
            return _context.Products.Select(productDto => new Product
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

        public IEnumerable<Product> ProductsByIds(string idsString)
        {
            var ids = DataTransferHelper.ProductIdsFromString(idsString);
            return _context.Products.Where(p => ids.Contains(p.ProductId)).Select(productDto => new Product
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