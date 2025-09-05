using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Hosting;
using ShopDb;
using ShopDb.Models;
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

                string connection = builder.Configuration.GetConnectionString("shop_db");
                builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

                builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));

                builder.Services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<IdentityContext>();

                // настройки куки
                builder.Services.ConfigureApplicationCookie(options =>
                {
                    options.ExpireTimeSpan= TimeSpan.FromDays(1); //сколько хранится
                    options.LoginPath = "/Account/Login"; // если не авторизован то сюда
                    options.LogoutPath = "/Account/Logout"; 
                    options.Cookie = new CookieBuilder()
                    {
                        IsEssential = true
                    };
                });

                // Add services to the container.
                builder.Services.AddTransient<IOrdersRepository, OrdersDbRepository>();
                builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();
                builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>();
                builder.Services.AddTransient<ILikedRepository, LikedDbRepository>();
                builder.Services.AddSingleton<IRolesRepository, RolesInMemoryRepository>();
                builder.Services.AddControllersWithViews();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {

                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    var dataBaseContext = services.GetRequiredService<DatabaseContext>();
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    IdentityInitializer.Initialize(userManager, roleManager);
                    dataBaseContext.Database.Migrate();
                    // DbInitializer.Initialize(context);
                }
                app.UseDeveloperExceptionPage();

                app.UseSerilogRequestLogging();

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthentication();
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
