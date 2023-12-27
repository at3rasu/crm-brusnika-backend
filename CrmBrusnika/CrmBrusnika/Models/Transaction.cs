namespace CrmBrusnika.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Land Land { get; set; } = null!;

        
    }
}
