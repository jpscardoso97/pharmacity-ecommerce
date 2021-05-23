namespace ShoppingCartService
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MongoDB.Driver;
    using ShoppingCartService.Data;
    using ShoppingCartService.Data.Dto;
    using ShoppingCartService.Mutations;
    using ShoppingCartService.Queries;
    using ShoppingCartService.Resolvers;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   
            services
                .AddGraphQLServer()
                .AddQueryType()
                .AddTypeExtension<CartQuery>()
                .AddMutationType()
                .AddTypeExtension<CartMutations>();
            
            services.AddSingleton<IMongoClient>(new MongoClient("mongodb://127.0.0.1:8069"));
            services.AddSingleton<IMongoDatabase>(s => s.GetRequiredService<IMongoClient>().GetDatabase("PharmacityDB"));
            services.AddSingleton<IMongoCollection<CartDto>>(s => s.GetRequiredService<IMongoDatabase>().GetCollection<CartDto>("carts"));
            services.AddSingleton<CartsRepository>();

            services.AddScoped<CartResolver>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
        }
    }
}