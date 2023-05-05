using Microsoft.EntityFrameworkCore;

namespace shop_MahdiTaremi.Models
{
    public class dbShop:DbContext
    {
        //ctor
        public dbShop(DbContextOptions options):base(options) { 
            
        }
        //DbSet is Key Microsoft And Table DB with Models
        public DbSet<Product> Product { get; set; }
    }
}
