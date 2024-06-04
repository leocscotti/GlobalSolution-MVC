using GlobalSolution_MVC.Persistencia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution_MVC.Persistencia.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class

    {
        private readonly VisionaryBlueDbContext _context;

        private readonly DbSet<T> _dbSet;

        public Repositorio(VisionaryBlueDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _context.Add(entity);

            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);

            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int? id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
