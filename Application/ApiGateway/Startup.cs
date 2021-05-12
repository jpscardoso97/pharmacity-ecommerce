namespace ApiGateway
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public const string Products = "products";
        public const string Customers = "customers";
        public const string Carts = "carts";
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient(
                Products, 
                c => c.BaseAddress = new Uri("https://localhost:5001/graphql"));
            services.AddHttpClient(
                Customers, 
                c => c.BaseAddress = new Uri("https://localhost:5002/graphql"));
            services.AddHttpClient(
                Carts, 
                c => c.BaseAddress = new Uri("https://localhost:5003/graphql"));

            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("LocalQuery"))
                .AddRemoteSchema(Products)
                .AddRemoteSchema(Customers)
                .AddRemoteSchema(Carts)
                .AddTypeExtensionsFromFile("./Stitching.graphql");
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}