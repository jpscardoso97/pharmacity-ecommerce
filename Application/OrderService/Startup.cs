using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace OrderService
{
    using MongoDB.Driver;
    using OrderService.Data;
    using OrderService.Data.Dto;
    using OrderService.Models;
    using OrderService.Mutations;
    using OrderService.Queries;
    using OrderService.Resolvers;

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
                .AddType<ProductsOrder>()
                .AddType<PrescriptionOrder>()
                .AddQueryType()
                .AddTypeExtension<OrdersQuery>()
                .AddMutationType()
                .AddTypeExtension<OrderMutations>();
            
            services.AddSingleton<IMongoClient>(new MongoClient("mongodb://127.0.0.1:8069"));
            services.AddSingleton<IMongoDatabase>(s => s.GetRequiredService<IMongoClient>().GetDatabase("PharmacityDB"));
            services.AddSingleton<IMongoCollection<OrderDto>>(s => s.GetRequiredService<IMongoDatabase>().GetCollection<OrderDto>("orders"));
            services.AddSingleton<OrdersRepository>();

            services.AddScoped<OrdersResolver>();
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