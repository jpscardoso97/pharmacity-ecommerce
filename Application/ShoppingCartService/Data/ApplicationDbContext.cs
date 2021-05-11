using Bogus;
using Microsoft.EntityFrameworkCore;

namespace ProductService.Data
{
    using ShoppingCartService.Data.Dto;

    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            
        }

        public DbSet<CartDto> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var sizes = new[] { "small", "medium", "large"};
            var products = new Faker<CartDto>()
                .RuleFor(c => c.Id, c => c.UniqueIndex)
                .RuleFor(c => c.CustomerId, c => c.Random.AlphaNumeric(8))
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