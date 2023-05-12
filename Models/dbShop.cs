using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace shop_MahdiTaremi.Models
{
    public class dbShop:DbContext
    {
        //ctor
        public dbShop(DbContextOptions<dbShop> options):base(options) { 
            
        }
        
        // public void ConfigureServices(IServiceCollection services)
        // {
        //  services.AddDbContext<dbShop>(options =>
        //options.UseSqlServer(Configuration.GetConnectionString("Server=.;Database=shopShamsipourTechnicalCollege;User Id=MahdiTaremi;Password=12;TrustServerCertificate=True;")));

        //services.AddControllersWithViews();
        // }

        //DbSet is Key Microsoft And Table DB with Models
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
    }
}
