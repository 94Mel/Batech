using Batech.Data;
using Batech.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;


public class Program
{
    //public void ConfigureServices(IServiceCollection services)
    //{
    //    services.AddDbContext<VisitorDbContext>(options =>
    //     options.UseSqlServer(Configuration.GetConnectionString("VisitorConnection")));
    //    services.AddControllersWithViews();
    //    services.AddRazorPages();

    //    services.AddAuthorization(options =>
    //    {
    //        options.AddPolicy("EmailID", policy =>
    //        policy.RequireClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "mert.atalay@rentgo.com"
    //        ));

    //        options.AddPolicy("rolecreation", policy =>
    //        policy.RequireRole("Admin")
    //        );
    //    });
    //}


    private static void Main(string[] args)
    {






        var builder = WebApplication.CreateBuilder(args);



        //await ContextSeed.SeedSuperAdminAsync(userManager, roleManager);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));


        var formconnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<FormContext>(options =>
            options.UseSqlServer(formconnectionString));




        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        //builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true);
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
         .AddDefaultUI()
                    .AddDefaultTokenProviders();




        builder.Services.AddControllersWithViews();
        
        builder.Services.AddRazorPages();

        builder.Services.AddControllersWithViews();






        var app = builder.Build();




        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{Controller=Home}/{action=Index}/{id?}");

        app.MapRazorPages();

        app.Run();
    }
}
