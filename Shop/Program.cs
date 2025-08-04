using Serilog;
using Serilog.Events;
using Serilog.Extensions.Hosting;

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

                // Add services to the container.
                builder.Services.AddSingleton<IOrdersRepository, OrdersInMemoryRepository>();
                builder.Services.AddSingleton<ICartsRepository, CartsInMemoryRepository>();
                builder.Services.AddSingleton<IProductsRepository, ProductsInMemoryRepository>();
                builder.Services.AddSingleton<IFavoriteProductsRepository, FavoriteProductsInMemoryRepository>();
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
