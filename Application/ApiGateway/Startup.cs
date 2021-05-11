using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGateway.Models;
using ApiGateway.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ApiGateway
{
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
                .AddQueryType(d => d.Name("Query"))
                .AddRemoteSchema(Products, true)
                .AddRemoteSchema(Customers, true)
                .AddRemoteSchema(Carts, true)
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