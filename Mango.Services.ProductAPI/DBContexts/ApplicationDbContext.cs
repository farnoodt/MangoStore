using Mango.Services.ProductAPI.DBContexts.Models;
using Microsoft.EntityFrameworkCore;


namespace Mango.Services.ProductAPI.DBContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> producs { get; set; }
    }
}
