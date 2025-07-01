using Microsoft.EntityFrameworkCore;
using LocadoraApi.Models;


namespace LocadoraApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Veiculos = Set<Veiculo>();
            Clientes = Set<Cliente>();
            Alugueis = Set<Aluguel>();
        }
    }

}
