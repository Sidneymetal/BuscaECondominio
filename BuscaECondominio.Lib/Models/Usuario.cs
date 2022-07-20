
namespace BuscaECondominio.Lib.Models
{
    public class Usuario : ModelBase
    {
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string? UrlImagemCadastro { get; private set; }
        public DateTime DataCriacao { get; private set; }       

        public Usuario(int id, string email, string cpf, DateTime dataNascimento, string nome, string senha, DateTime dataCriacao) : base(id)
        {
            SetId(id);
            SetEmail(email);
            SetCpf(cpf);
            SetDataNascimento(dataNascimento);
            SetNome(nome);
            SetSenha(senha);
            SetDataCriacao(dataCriacao);
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
        public void SetDataCriacao(DateTime dataCriacao)
        {
            DataCriacao = dataCriacao;
        }
        public bool ValidarDataNascimento(DateTime dataNascimento)
        {
            if (dataNascimento < DateTime.Parse("01/01/2010"))
                return true;
            throw new Exception();
        }
        public bool ValidarEmail(string email)
        {
            if (email.Contains("@"))
                return true;
            throw new Exception();
        }
        public bool ValidarCpF(string cpf)
        {
            if ((cpf.Count() <= 11) & cpf.All(char.IsNumber))
                return true;
            throw new Exception();
        }
        public bool ValidarSenha(string senha)
        {
            if (senha.Count() > 8)
                return true;
            throw new Exception();
        }
    }
}