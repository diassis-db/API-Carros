using APICarros.Domain;
using Microsoft.EntityFrameworkCore;

namespace APICarros.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
         public DbSet<Carro> Carros { get; set; }
    }
    
}
