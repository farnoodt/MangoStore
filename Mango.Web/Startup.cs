using Mango.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;

namespace Mango.Web
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private IConfigurationRoot ConfigRoot;
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        [Route("appsettings")]
        public void ConfigureServices(IServiceCollection services)
        {
            SD.ProductAPIBase = Configuration["ServiceUrls"];
            services.AddHttpClient<IProductService, ProductService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddControllersWithViews();
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
