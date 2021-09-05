using Mango.Web.Services;


namespace Mango.Web
{
    public class Startup
    {
        private IConfiguration Configuration;// { get; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SD.ProductAPIBase = Configuration["ServiceUrls"];
            SD.ProductAPIBase = Configuration.GetSection("ServiceUrls").GetSection("ProductAPI").Value;
            services.AddHttpClient<IProductService, ProductService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddControllersWithViews();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies", C => C.ExpireTimeSpan = TimeSpan.FromMinutes(10))
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = Configuration.GetSection("ServiceUrls").GetSection("IdentityAPI").Value;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.ClientId = "mango";
                    options.ClientSecret = "secrt";
                    options.ResponseType = "code";
                    options.TokenValidationParameters.NameClaimType = "name";
                    options.TokenValidationParameters.RoleClaimType = "role";
                    options.Scope.Add("mango");
                    options.SaveTokens = true;
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
            app.UseAuthentication();
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
