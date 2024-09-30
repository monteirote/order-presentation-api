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
        public DbSet<Material> Materiais { get; set; }
        public DbSet<TipoMaterial> TiposMateriais { get; set; }
        public DbSet<OrdemServico> OrdensServico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>()
                .HasOne(m => m.TipoMaterial)
                .WithMany(t => t.Materiais)
                .HasForeignKey(m => m.IdTipoMaterial);
        }
    }
}
