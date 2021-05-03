using Bogus;
using Microsoft.EntityFrameworkCore;
using ProductService.Data.Dto;

namespace ProductService.Data
{
    public class ApplicationDbContext : DbContext
    {
        private const int ProductCount = 100;
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            
        }

        public DbSet<ProductDto> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var sizes = new[] { "small", "medium", "large"};
            var products = new Faker<ProductDto>()
                .RuleFor(p => p.Id, p => p.UniqueIndex)
                .RuleFor(p => p.ProductId, p => p.Random.AlphaNumeric(8))
                .RuleFor(p => p.Price, p => p.Commerce.Price())
                .RuleFor(p => p.Color, p => p.Commerce.Color())
                .RuleFor(p => p.Description, p => p.Commerce.ProductDescription())
                .RuleFor(p => p.Size, p => p.PickRandom(sizes))
                .RuleFor(p => p.Name, p => p.Commerce.ProductName())
                .RuleFor(p => p.Quantity, p => p.Random.Number(0, 100))
                .Generate(ProductCount);
            
            modelBuilder.Entity<ProductDto>()
                .HasData(products);
        }
    }
}