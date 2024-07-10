global using System;
global using System.Diagnostics.CodeAnalysis;
using Knihy.Data;
using Knihy.Data.Services;
using Microsoft.EntityFrameworkCore;

#nullable enable // Enable nullable reference types

namespace Knihy {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MonsteraDbConnection"));
                });
            builder.Services.AddScoped<IWriterService, WritersService>();
            //builder.Services.AddScoped<IEditorsService, EditorsService>();
            builder.Services.AddScoped<IPublisherService, PublisherService>();
            builder.Services.AddScoped<IBooksService, BooksService>();

            var app = builder.Build();
            //AppDbInitializer.Seed(app);


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
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
                pattern: "{controller=Books}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
