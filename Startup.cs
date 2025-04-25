using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductInventoryAPI.Data;
using ProductInventoryAPI.Repositories;
using ProductInventoryAPI.Services;
using ProductInventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProductInventoryAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method is called to configure services.
        public void ConfigureServices(IServiceCollection services)
        {
            // Bind MongoDbSettings from appsettings.json
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));

            // Register MongoDbContext
            services.AddSingleton<MongoDbContext>();

            // Register repositories and services
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            // Add controllers and configure JSON options
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
                });
        }


        // This method is called to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 1. Handle exceptions during development
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 2. Enable routing to map incoming requests to appropriate controllers
            app.UseRouting();

            // 3. Define the endpoints for the API
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // This will map the controllers to the routes defined in them
            });
        }
    }
}
