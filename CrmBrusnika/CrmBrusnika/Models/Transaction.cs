using CrmBrusnika.Models.Enums;

namespace CrmBrusnika.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Land? Land { get; set; } = null!;
        public Guid LandId { get; set; }
        public ObjectEntity? Entity { get; set; } = null!;
        public Guid EntityId { get; set; }
        public StagesTransactions Stage { get; set; } = StagesTransactions.InProcess!;

        public Transaction(Guid entityId, StagesTransactions stage)
        {
            EntityId = entityId;
            Stage = stage;
        }
    }
}
