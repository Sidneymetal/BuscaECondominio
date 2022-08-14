namespace BuscaECondominio.Lib.Models
{
    public class ModelBase
    {
        public ModelBase()
        {
            
        }
        public Guid Id { get; private set; }
        public ModelBase(Guid id)
        {
            SetId(id);
        }
        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}