namespace Triquetra.Domain.DTO.Offers
{
    public class OfferDTO
    {
        public int Id { get; set; }
        public double SetupArea { get; set; }
        public int InverterCount { get; set; }
        public int PanelCount { get; set; }
        public float TotalPriceTL { get; set; }
        public float TotalPriceDollar { get; set; }
        public DateTime AddedOn { get; set; }
    }
}