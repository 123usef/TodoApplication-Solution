using Microsoft.EntityFrameworkCore;
using TodoApplication.AppContext;
using TodoApplication.Models;

namespace TodoApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Allow For Dependecy Injection to create Objects
            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.
                UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Todo}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
