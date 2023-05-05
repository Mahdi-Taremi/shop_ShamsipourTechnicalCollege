using shop_MahdiTaremi.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<dbShop>(x => x.UseSqlServer("Server=.:Initial Catalog=shopShamsipourTechnicalCollege;Integrated Security=False;Persist Security Info=False;TrustServerCertificate=True; User Id=MahdiTaremi;Password=123;"));
//"Server=.:Initial Catalog=shopShamsipourTechnicalCollege;Integrated Security=False;Persist Security Info=False;TrustServerCertificate=True; User Id=myUsername;Password=myPassword;"
//.Services.AddDbContext<>(x => x.UseSqlServer("Connection String"));
builder.Services.AddControllersWithViews();

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
