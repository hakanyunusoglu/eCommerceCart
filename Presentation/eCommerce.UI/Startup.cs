using eCommerce.Persistence;
using eCommerce.Persistence.Context;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace eCommerce.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddPersistenceServices();
            services.AddDistributedMemoryCache();
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(1);
                option.Cookie.Name = "eCommerceLogged";
                option.Cookie.HttpOnly = true;
                option.Cookie.IsEssential = true;
            });
            services.AddMvc();
          
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, eCommerceDbContext dbcontext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}