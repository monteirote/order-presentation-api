using Microsoft.EntityFrameworkCore;
using OrderPresentationApi.Models;

namespace OrderPresentationApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
  
    }
}
