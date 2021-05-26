namespace CheckoutService
{
    using System;
    using System.Net.Http;
    using CheckoutService.Data;
    using CheckoutService.Data.Dto;
    using CheckoutService.InputTypes;
    using CheckoutService.Mutations;
    using CheckoutService.Queries;
    using CheckoutService.Resolvers;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MongoDB.Driver;

    public class Startup
    {
        private const string Orders = "orders";
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient(
                Orders, 
                c => c.BaseAddress = new Uri("https://localhost:6004/graphql"));

            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("CheckoutQuery"))
                .AddTypeExtension<PaymentsQuery>()
                .AddMutationType(d => d.Name("CheckoutMutation"))
                .AddTypeExtension<PaymentsMutation>()
                .AddRemoteSchema(Orders);

            services.AddSingleton<IMongoClient>(new MongoClient("mongodb://127.0.0.1:8069"));
            services.AddSingleton<IMongoDatabase>(s =>
                s.GetRequiredService<IMongoClient>().GetDatabase("PharmacityDB"));
            services.AddSingleton<IMongoCollection<PaymentDto>>(s =>
                s.GetRequiredService<IMongoDatabase>().GetCollection<PaymentDto>("payments"));
            services.AddSingleton<PaymentsRepository>();

            services.AddScoped<PaymentsResolver>();
            
            services.AddHttpClient();
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