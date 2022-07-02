
using Microsoft.EntityFrameworkCore;
using shared_library.Contexts;
using shared_library.Helpers;
using shared_library.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

var services = builder.Services;
services.AddDbContextPool<MainContext>(s => s.UseSqlServer(Settings.sql_connection_string));
services.AddCors();




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

