namespace BuscaECondominio.Web.DTOs
{
    public class UsuarioDTO
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string UrlImagemCadastro { get; private set; }
        public DateTime DataCadastro { get; private set; }
    }
}