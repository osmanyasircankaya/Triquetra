namespace Triquetra.Domain.DTO.ExchangeRates
{
    public class ExchangeRateDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public DateTime AddedOn { get; set; }
    }
}