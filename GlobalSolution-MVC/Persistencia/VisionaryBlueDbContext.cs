using GlobalSolution_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution_MVC.Persistencia
{
    public class VisionaryBlueDbContext:DbContext
    {
        public DbSet<Denuncia> Denuncias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AutoridadeAmbiental> AutoridadesAmbientais { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<AutoridadeAmbientalDenuncia> AutoridadesAmbientaisDenuncias { get; set; }
        public DbSet<Localizacao> Locais { get; set; }
        public DbSet<Notificacao> Notificacoes {  get; set; } 
        public DbSet<Residuo> Residuos { get; set; }

        public VisionaryBlueDbContext(DbContextOptions<VisionaryBlueDbContext> options) : base(options)
        {

        }
    }
}
