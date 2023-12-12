namespace CrmBrusnika.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public int RegisterNumber { get; set; }
        public string Adress { get; set; } =null!;
        public string Square { get; set; } = null!;
        public string AboutHolder { get; set; } = null!;
        public double Price { get; set; }
        public string SearchObject { get; set; } = null!;
    }
}
