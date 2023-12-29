namespace CrmBrusnika.Models
{
    public class Land
    {
        public Guid Id { get; set; }
        public int RegisterNumber { get; set; }
        public string Address { get; set; } = null!;
        public string AreaInMeters { get; set; } = null!;
        public string AboutHolder { get; set; } = null!;
        public double Price { get; set; }
        public string WhoIsFound { get; set; } = null!;
        public ObjectEntity? Entity { get; set; } = null!;

        public Land(
            int registerNumber,
            string address,
            string areaInMeters,
            string aboutHolder,
            double price,
            string whoIsFound)
        {
            RegisterNumber = registerNumber;
            Address = address;
            AreaInMeters = areaInMeters;
            AboutHolder = aboutHolder;
            Price = price;
            WhoIsFound = whoIsFound;
        }
    }
}
