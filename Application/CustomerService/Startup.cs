using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CustomerService
{
    using CustomerService.Data;
    using CustomerService.Data.Dto;
    using CustomerService.Queries;
    using CustomerService.Resolvers;
    using MongoDB.Driver;
    using ShoppingCartService.Data;

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                .AddQueryType<CustomerQuery>();
            
            services.AddSingleton<IMongoClient>(new MongoClient("mongodb://127.0.0.1:27017"));
            services.AddSingleton<IMongoDatabase>(s => s.GetRequiredService<IMongoClient>().GetDatabase("PharmacityDB"));
            services.AddSingleton<IMongoCollection<CustomerDto>>(s => s.GetRequiredService<IMongoDatabase>().GetCollection<CustomerDto>("customers"));
            services.AddSingleton<IMongoCollection<AddressDto>>(s => s.GetRequiredService<IMongoDatabase>().GetCollection<AddressDto>("addresses"));
            services.AddSingleton<CustomersRepository>();
            services.AddSingleton<AddressesRepository>();

            services.AddScoped<CustomerResolver>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
        }
    }
}