using GlobalSolution_MVC.Models;

namespace GlobalSolution_MVC.Persistencia.Interfaces
{
    public interface IDenunciaRepositorio
    {
        IEnumerable<Denuncia> GetAll();

        Denuncia GetById(int? id);

        void Add(Denuncia denuncia);

        void Update(Denuncia denuncia);

        void Delete(Denuncia denuncia);
    }
}
