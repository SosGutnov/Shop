using Serilog;

namespace Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();


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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

    }
}
