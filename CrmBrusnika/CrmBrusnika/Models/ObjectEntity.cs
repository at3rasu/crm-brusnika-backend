namespace CrmBrusnika.Models
{
    public class ObjectEntity
    {
        public Guid Id { get; set; }
        public double JuridicalCost { get; set; }
        public string PermissiveSide { get; set; } = null!;
        public string GeotechnicalConditions { get; set; } = null!;
        public string AvailabilityEngineeringNetworks { get; set; } = null!;
        public string TransportationaAccessibility { get; set;} = null!;

        public ObjectEntity(
            double juridicalCost,
            string permissiveSide,
            string geotechnicalConditions,
            string availabilityEngineeringNetworks,
            string transportationaAccessibility)
        {
            JuridicalCost = juridicalCost;
            PermissiveSide = permissiveSide;
            GeotechnicalConditions = geotechnicalConditions;
            AvailabilityEngineeringNetworks = availabilityEngineeringNetworks;
            TransportationaAccessibility = transportationaAccessibility;
        }
    }
}
