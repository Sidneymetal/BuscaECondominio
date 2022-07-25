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
        public async Task AlterarEmail(int id, string emailCadastrar)
        {
           _dbset.Find(id).SetEmail(emailCadastrar);
            await _context.SaveChangesAsync();
        }
    }
}