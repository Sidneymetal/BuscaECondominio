using BuscaECondominio.Lib.Interfaces;
using BuscaECondominio.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace BuscaECondominio.Lib.Data.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        private readonly BuscaECondominioContext _context;
        public UsuarioRepositorio(BuscaECondominioContext context) : base(context, context.Usuarios)
        {
            _context = context;
        }
        public void AlterarUsuario(int id)
        {
            var usuario = _dbset.Find(id);                        
            _context.SaveChanges();
        }
    }
}