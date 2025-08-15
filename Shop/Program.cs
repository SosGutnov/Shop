using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Hosting;
using Shop.Db;
using ShopDb;
using System.Configuration;

namespace Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .CreateBootstrapLogger();

            Log.Information("Starting up!");

            try
            {
                
                var builder = WebApplication.CreateBuilder(args);

                builder.Services.AddSerilog((services, lc) => lc
                      .ReadFrom.Configuration(builder.Configuration)
                      .ReadFrom.Services(services)
                      .Enrich.FromLogContext()
                      .WriteTo.Console());

                builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("shop_db")));

                // Add services to the container.
                builder.Services.AddSingleton<IOrdersRepository, OrdersInMemoryRepository>();
                builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();
                builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>();
                builder.Services.AddSingleton<IRolesRepository, RolesInMemoryRepository>();
                builder.Services.AddSingleton<IUserManager, UserManager>();
                builder.Services.AddControllersWithViews();


                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {

                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseDeveloperExceptionPage();

                app.UseSerilogRequestLogging();

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "MyArea", 
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                



                app.Run();

                Log.Information("Stopped cleanly");
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "че то сломалось");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

    }
}
