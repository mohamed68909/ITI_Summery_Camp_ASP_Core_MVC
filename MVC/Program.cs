using LibraryBookManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<LibraryContext>(options =>
     options.UseSqlServer(
         builder.Configuration.GetConnectionString("DefaultConnection")
     )
 );


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

          
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Books}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
