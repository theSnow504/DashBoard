using Dashboard.Common.Configuration;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.X86;
using Dashboard.Service.Api.Users;
using DashBoard.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IUsersApiServices, UsersApiServices>();


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
var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
AppConfigs.LoadAll(config);

//var services = new ServiceCollection();
//services.AddScoped<HomeController>();
//ConfigureServices(services);
//ServiceProvider serviceProvider = services.BuildServiceProvider();
//var form1 = serviceProvider.GetRequiredService<HomeController>();
////Application.Run(form1);

// static void ConfigureServices(ServiceCollection services)
//{
//    services.AddLogging(configure => configure.AddConsole())
//            .AddScoped<IUsersApiServices, UsersApiServices>();
//}



app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();