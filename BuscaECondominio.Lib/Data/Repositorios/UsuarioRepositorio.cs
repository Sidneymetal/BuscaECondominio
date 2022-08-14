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
        public async Task AlterarEmail(Guid id, string alterarEmail)
        {
           _dbset.Find(id).SetEmail(alterarEmail);
            await _context.SaveChangesAsync();
        }
        public async Task AlterarSenha(Guid id, string alterarSenha)
        {
            _dbset.Find(id).SetSenha(alterarSenha);
            await _context.SaveChangesAsync();
        }
        public async Task AlterarNome(Guid id, string alterarNome)
        {
            _dbset.Find(id).SetNome(alterarNome);
            await _context.SaveChangesAsync();
        }
        public async Task AlterarUrlImagemCadastro(Guid id, string alterarurlImagemCadastro)
        {
            _dbset.Find(id).SetUrlImagemCadastro(alterarurlImagemCadastro);
            await _context.SaveChangesAsync();
        }   
        public async Task<Usuario> LoginBuscarPorEmail(string emailDoUsuario)
        {
            return await _dbset.AsNoTracking().FirstAsync(x => x.Email == emailDoUsuario);
        }     
    }
}