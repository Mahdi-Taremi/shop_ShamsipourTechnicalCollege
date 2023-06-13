using shop_MahdiTaremi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
// using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
builder.Services.AddDbContext<dbShop>(x => x.UseSqlServer("Server=.;Database=shopShamsipourTechnicalCollege;User Id=MahdiTaremi;Password=12;TrustServerCertificate=True;"));

// 1. Add Swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name= "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    option.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!))

    };
});

//.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
//builder.Services.AddDbContext<dbShop>(x => x.UseSqlServer("Server=.:Initial Catalog=shopShamsipourTechnicalCollege;Integrated Security=False;Persist Security Info=False;TrustServerCertificate=True; User Id=MahdiTaremi;Password=123;"));

//"Server=.:Initial Catalog=shopShamsipourTechnicalCollege;Integrated Security=False;Persist Security Info=False;TrustServerCertificate=True; User Id=myUsername;Password=myPassword;"
//.Services.AddDbContext<>(x => x.UseSqlServer("Connection String"));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 2. Add Swagger 
app.UseSwaggerUI();

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

// 3. Add Swagger 
app.UseSwagger(x => x.SerializeAsV2 = true);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
