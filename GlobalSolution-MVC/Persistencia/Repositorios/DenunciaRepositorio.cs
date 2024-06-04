using GlobalSolution_MVC.Models;
using GlobalSolution_MVC.Persistencia.Interfaces;

namespace GlobalSolution_MVC.Persistencia.Repositorios
{
    public class DenunciaRepositorio : IDenunciaRepositorio
    {
        private readonly VisionaryBlueDbContext _context;

        public DenunciaRepositorio(VisionaryBlueDbContext context)
        {
            _context = context;
        }

        public void Add(Denuncia denuncia)
        {
            _context.Add(denuncia);

            _context.SaveChanges();
        }

        public void Delete(Denuncia denuncia)
        {
            _context.Remove(denuncia);

            _context.SaveChanges();
        }

        public IEnumerable<Denuncia> GetAll()
        {
            return _context.Denuncias.ToList();
        }

        public Denuncia GetById(int? id)
        {
            return _context.Denuncias.Find(id);
        }

        public void Update(Denuncia denuncia)
        {
            _context.Update(denuncia);

            _context.SaveChangesAsync();
        }
    }

    
}

