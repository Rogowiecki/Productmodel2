using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnLineShop.DB;
using OnLineShop.DB.Models;

namespace ProductModel
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
            // получение строки подключения к BD
            string connection = Configuration.GetConnectionString("connection_onlineshop");
            // регистрация контестта BD
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
            
            services.AddTransient<IGetProducts, ProductFromDBRepository>();
            services.AddTransient<IGetCarts, CartsFromDBRepository>();
            services.AddTransient<IUsersRepository, UsersDbRepository>();

            //services.AddSingleton<IGetProducts, ProductRepository>();
            //services.AddSingleton<ICarts, CartsFromDBRepository>();

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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Admin}/{action=AddProduct}/{id?}");
            });
        }
    }
}
