
namespace BuscaECondominio.Lib.Models
{
    public class Usuario : ModelBase
    {
        public string Email { get; set; }        
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nome { get; set; }        
        public string Senha { get; set; }
        public string UrlImagemCadastro { get; set; }
        public DateTime DataCriacao { get; set; }
        
        public List<Usuario> ListaUsuario { get; set; } = new List<Usuario>();

        public Usuario(int id, string email, string cpf, DateTime dataNascimento, string nome, string senha, DateTime dataCriacao) : base(id)
        {
            SetId(id);  
            SetEmail(email);          
            SetCpf(cpf);
            SetDataNascimento(dataNascimento);            
            SetNome(nome);
            SetSenha(senha);
            DataCriacao = dataCriacao;
        }
        public void SetNome(string nome)
        {
            Nome = nome;
        }
        public void SetCpf(string cpf)
        {
            ValidarCpF(cpf);
            Cpf = cpf;
        }
        public void SetDataNascimento(DateTime dataNascimento)
        {
            ValidarDataNascimento(dataNascimento);
            DataNascimento = dataNascimento;
        }
        public void SetEmail(string email)
        {
            ValidarEmail(email);
            Email = email;
        }
        public void SetSenha(string senha)
        {
            ValidarSenha(senha);
            Senha = senha;
        }
        public void SetUrlImagemCadastro(string urlImagem)
        {
            UrlImagemCadastro = urlImagem;
        }
        public void SetDataCadastro(DateTime dataCriacao)
        {
            DataCriacao = dataCriacao;
        }
        public bool ValidarDataNascimento(DateTime dataNascimento)
        {
            if (dataNascimento < DateTime.Parse("01/01/2010")) ;
            return true;
        }
        public bool ValidarEmail(string email)
        {
            if (email.Contains("@"));
            return true;
        }
        public bool ValidarCpF(string cpf)
        {
            if ((cpf.Count() <= 11) & cpf.All(char.IsNumber));
            return true;
        }
        public bool ValidarSenha(string senha)
        {
            if (senha.Count() > 8);
            return true;
        }
    }
}