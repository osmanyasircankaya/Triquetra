namespace Triquetra.Domain.DTO.Offers
{
    public class CreateOfferDTO
    {
        public double SetupArea { get; set; }
        public int InverterCount { get; set; }
        public int PanelCount { get; set; }
        public float TotalPriceTL { get; set; }
        public float TotalPriceDollar { get; set; }
    }
}