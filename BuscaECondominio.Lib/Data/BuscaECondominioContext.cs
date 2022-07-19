using BuscaECondominio.Lib.Models;
using Microsoft.EntityFrameworkCore;


namespace BuscaECondominio.Lib.Data
{
    public class BuscaECondominioContext : DbContext
    {
        public BuscaECondominioContext(DbContextOptions context) : base(context)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Usuario>().HasKey(x => x.Id);
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}