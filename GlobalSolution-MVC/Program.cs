using GlobalSolution_MVC.Models;
using GlobalSolution_MVC.Persistencia;
//using GlobalSolution_MVC.Persistencia.Interfaces;
//using GlobalSolution_MVC.Persistencia.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<VisionaryBlueDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("OracleFIAP"));
            });

            //builder.Services.AddScoped<IRepositorio<Aluno>, Repositorio<Aluno>>()

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
