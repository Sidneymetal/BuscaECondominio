namespace BuscaECondominio.Lib.Models
{
    public class Usuario : ModelBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string UrlImagemCadastro { get; set; }
        public DateTime DataCadastro { get; set; }
        
        public Usuario(int id, string nome, string cpf, DateTime dataNascimento, string email, string senha, DateTime dataCadastro) : base(id)
        {
            SetNome(nome);
            SetCpf(cpf);
            SetDataNascimento(dataNascimento);
            SetEmail(email);
            SetSenha(senha);
            DataCadastro = dataCadastro;
        }
        public void SetNome(string nome)
        {
            Nome = nome;
        }
        public void SetCpf(string cpf)
        {
            ValidarCpf(cpf);
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
        public void SetDataCadastro(DateTime dataCadastro)
        {
            DataCadastro = dataCadastro;
        }
        public bool ValidarDataNascimento(DateTime dataNascimento)
        {
            if (dataNascimento < DateTime.Parse("01/01/2010")) ;
            return true;
        }
        public bool ValidarEmail(string email)
        {
            if (email.Contains("@")) ;
            return true;
        }
        public bool ValidarCpf(string cpf)
        {
            if ((cpf.Count() <= 11) & cpf.All(char.IsNumber))
            return true;
        }
        public bool ValidarSenha(string senha)
        {
            if (senha.Count() > 8) ;
            return true
        }
    }
}