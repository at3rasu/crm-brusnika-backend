namespace CrmBrusnika.Models
{
    public class Land
    {
        public Guid Id { get; set; }
        public int RegisterNumber { get; set; }
        public string Adress { get; set; } = null!;
        public string AreaInMeters { get; set; } = null!;
        public string AboutHolder { get; set; } = null!;
        public double Price { get; set; }
        public string WhoIsFound { get; set; } = null!;

        public Land(
            int registerNumber,
            string adress,
            string areaInMeters,
            string aboutHolder,
            double price,
            string whoIsFound)
        {
            RegisterNumber = registerNumber;
            Adress = adress;
            AreaInMeters = areaInMeters;
            AboutHolder = aboutHolder;
            Price = price;
            WhoIsFound = whoIsFound;
        }
    }
}
