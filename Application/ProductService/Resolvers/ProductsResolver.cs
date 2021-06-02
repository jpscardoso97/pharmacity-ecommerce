using System.Collections.Generic;
using System.Linq;
using Crosscutting.Helpers;
using ProductService.Data;
using ProductService.Models;

namespace ProductService.Resolvers
{
    using ProductService.Data.Dto;

    public class ProductsResolver
    {
        private readonly ProductsRepository _repository;

        public ProductsResolver(ProductsRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> Products()
        {
            return _repository.GetProducts()?
                .ToList()
                .Select(FromDto);
        }

        public IEnumerable<Product> ProductsByIds(string idsString)
        {
            var ids = DataTransferHelper.IdsFromString(idsString);
            return _repository.GetProducts()?
                .ToList()
                .Where(p => ids.Contains(p.ProductId))
                .Select(productDto => FromDto(productDto));
        }

        private Product FromDto(ProductDto productDto) => productDto != null
            ? new Product()
            {
                Id = productDto.ProductId,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                Color = productDto.Color,
                Size = productDto.Size
            }
            : default;
    }
}