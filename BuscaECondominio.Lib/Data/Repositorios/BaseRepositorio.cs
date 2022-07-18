using BuscaECondominio.Lib.Interfaces;
using BuscaECondominio.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace BuscaECondominio.Lib.Data.Repositorios
{
    public class BaseRepositorio<T>: IBaseRepositorio<T> where T : ModelBase
    {
        protected readonly BuscaECondominioContext _context;
        protected readonly DbSet<T> _dbset;

        public BaseRepositorio(BuscaECondominioContext context, DbSet<T> dbset)
        {
            _context = context;
            _dbset = dbset;
        }

       public List<T> ListarTodos()
        {
            return _dbset.AsNoTracking().ToList();           
        }             
        public T ListarTodosPorId(int id)
        {
            return _dbset.AsNoTracking().First(x => x.Id == id);
        }
        public void AdicionarUsuario(T item)
        {
            _dbset.Add(item);
            _context.SaveChanges();
        }
        public void DeletarUsuario(int id)
        {
            var item = _dbset.Find(id);
            _dbset.Remove(item);
            _context.SaveChanges();
        }
    }
}