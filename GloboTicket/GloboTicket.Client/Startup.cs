using System;
using System.Net.Http;
using GloboTicket.Client.Repositories;
using GloboTicket.EventCatalogService;
using GloboTicket.ShoppingBasketService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GloboTicket.Client
{
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
            services.AddControllersWithViews();

            services.AddScoped<IEventCatalogRepository, EventCatalogRepository>();
            services.AddScoped<IShoppingBasketRepository, ShoppingBasketRepository>();

            services.AddHttpClient("ShoppingBasketClient");
            services.AddHttpClient("EventCatalogClient");

            services.AddScoped<IShoppingBasketClient>(ctx =>
            {
                var clientFactory = ctx.GetRequiredService<IHttpClientFactory>();
                var httpClient = clientFactory.CreateClient("ShoppingBasketClient");

                return new ShoppingBasketClient(Configuration["ServiceConfigs:ShoppingBasket:url"], 
                    httpClient);
            });

            services.AddScoped<IEventCatalogClient>(ctx =>
            {
                var clientFactory = ctx.GetRequiredService<IHttpClientFactory>();
                var httpClient = clientFactory.CreateClient("EventCatalogClient");

                return new EventCatalogClient(Configuration["ServiceConfigs:EventCatalog:url"], 
                    httpClient);
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=EventCatalog}/{action=Index}/{id?}");
            });
        }
    }
}
