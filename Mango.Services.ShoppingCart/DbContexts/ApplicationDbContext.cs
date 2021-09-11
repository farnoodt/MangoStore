using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ShoppingCart.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //public DbSet<Product> producs { get; set; }
    }
}
