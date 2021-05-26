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
        private const string Products = "products";
        private const string Customers = "customers";
        private const string Carts = "carts";
        private const string Orders = "orders";
        private const string Prescriptions = "prescriptions";
        private const string Checkout = "checkout";
        
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
                c => c.BaseAddress = new Uri("https://localhost:6001/graphql"));
            services.AddHttpClient(
                Customers, 
                c => c.BaseAddress = new Uri("https://localhost:6002/graphql"));
            services.AddHttpClient(
                Carts, 
                c => c.BaseAddress = new Uri("https://localhost:6003/graphql"));
            services.AddHttpClient(
                Orders, 
                c => c.BaseAddress = new Uri("https://localhost:6004/graphql"));
            services.AddHttpClient(
                Prescriptions, 
                c => c.BaseAddress = new Uri("https://localhost:6005/graphql"));
            services.AddHttpClient(
                Checkout, 
                c => c.BaseAddress = new Uri("https://localhost:6006/graphql"));

            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("LocalQuery"))
                .AddMutationType(d => d.Name("LocalMutation"))
                .AddRemoteSchema(Products)
                .AddRemoteSchema(Customers)
                .AddRemoteSchema(Orders)
                .AddRemoteSchema(Prescriptions)
                .AddRemoteSchema(Checkout, true)
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