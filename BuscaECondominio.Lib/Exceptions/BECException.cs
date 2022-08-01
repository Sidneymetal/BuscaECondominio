namespace BuscaECondominio.Lib.Exceptions
{
    public class BECException : Exception
    {
        public string Msg { get; set; }

        public BECException(string msg) : base(msg)
        {

        }
        public BECException()
        {

        }
    }
}