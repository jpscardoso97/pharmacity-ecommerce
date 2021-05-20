using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CheckoutService
{
    using CheckoutService.Data;
    using CheckoutService.Data.Dto;
    using CheckoutService.Mutations;
    using CheckoutService.Queries;
    using CheckoutService.Resolvers;
    using MongoDB.Driver;

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                .AddQueryType()
                .AddTypeExtension<PaymentsQuery>()
                .AddMutationType()
                .AddTypeExtension<PaymentsMutation>();

            services.AddSingleton<IMongoClient>(new MongoClient("mongodb://127.0.0.1:8069"));
            services.AddSingleton<IMongoDatabase>(s =>
                s.GetRequiredService<IMongoClient>().GetDatabase("PharmacityDB"));
            services.AddSingleton<IMongoCollection<PaymentDto>>(s =>
                s.GetRequiredService<IMongoDatabase>().GetCollection<PaymentDto>("payments"));
            services.AddSingleton<PaymentsRepository>();

            services.AddScoped<PaymentsResolver>();
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