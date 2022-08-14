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

       public async Task <List<T>> ListarTodos()
        {
            return await _dbset.AsNoTracking().ToListAsync();           
        }             
        public async Task <T> ListarUsuarioPorId(Guid id)
        {
            return await _dbset.AsNoTracking().FirstAsync(x => x.Id == id);
        }
        public async Task CadastrarUsuario(T item)
        {
            await _dbset.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public async Task DeletarUsuario(Guid id)
        {
            var usuario = await _dbset.FindAsync(id);
            _dbset.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}