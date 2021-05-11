namespace CustomerService.Data
{
    using Bogus;
    using CustomerService.Data.Dto;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        private const int AddressesCount = 10;
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            
        }

        public DbSet<CustomerDto> Customers { get; set; }
        public DbSet<AddressDto> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var addresses = new Faker<AddressDto>()
                .RuleFor(a => a.Id, f => f.UniqueIndex)
                .RuleFor(a => a.AddressId, (f, a) => GenerateAddressId(a.Id))
                .RuleFor(a => a.DeliveryAddress, f => f.Address.StreetName())
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Country, f => f.Address.Country())
                .RuleFor(a => a.ZipCode, f => f.Address.ZipCode())
                .RuleFor(a => a.Phone, f => f.Phone.PhoneNumber())
                .Generate(AddressesCount);
            
            var customers = 
            
            modelBuilder.Entity<AddressDto>()
                .HasData(addresses);
            
            modelBuilder.Entity<CustomerDto>()
                .HasData(customers);
        }

        public static string GenerateAddressId(int index) => $"addr-{index}";
    }
}