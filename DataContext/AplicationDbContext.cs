using Microsoft.EntityFrameworkCore;
using WebApiGerenciador.Models;

namespace WebApiGerenciador.DataContext
{
    public class AplicationDbContext: DbContext 
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ColaboradoresModel> Colaboradores { get; set;}
    }
}
