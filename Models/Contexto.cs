using Microsoft.EntityFrameworkCore;

namespace ProjetoBancoDados.Models
{
    public class Contexto : DbContext 
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        { 

        }
        public DbSet<Visita> Visita { get; set; }

        public DbSet<Visitante> Visitante { get; set; }

        public DbSet<Artista> Artista { get; set; }

        public DbSet<Lugar> Lugar { get; set; }

        public DbSet<ObraDeArte> ObraDeArte { get; set; }

        public DbSet<LugarVisita> LugarVisita { get; set; }

        public DbSet<teste> teste { get; set; }
    }
}
