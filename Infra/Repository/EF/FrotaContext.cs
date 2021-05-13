using Localiza.Frotas.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Localiza.Frotas.Infra.Repository.EF
{
    public class FrotaContext : DbContext
    {
        public FrotaContext(DbContextOptions<FrotaContext> options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}