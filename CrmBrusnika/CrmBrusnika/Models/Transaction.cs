using CrmBrusnika.Models.Enums;

namespace CrmBrusnika.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Land Land { get; set; } = null!;
        public StagesTransactions Stage { get; set; }
    }
}
