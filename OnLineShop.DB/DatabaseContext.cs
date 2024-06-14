using Microsoft.EntityFrameworkCore;
using OnLineShop.DB.Models;

namespace OnLineShop.DB
{
    public class DatabaseContext: DbContext
    {
        // название таблицы
        public DbSet<ProductDB> ProductDBs { get; set; }
        public DbSet<CartDB> CartDBs { get; set; }
        public DbSet<CartDBItem> CardDBItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }    
    }
}
