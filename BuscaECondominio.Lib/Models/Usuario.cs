namespace BuscaECondominio.Lib.Models
{
    public class Usuario : ModelBase
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string UrlImagemCadastro { get; private set; }
        public DateTime DataCadastro { get; private set; }

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
            Cpf = cpf;
        }
        public void SetDataNascimento(DateTime dataNascimento)
        {           
            DataNascimento = dataNascimento;
        }
        public void SetEmail(string email)
        {            
            Email = email;
        }
        public void SetSenha(string senha)
        {
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
    }
}