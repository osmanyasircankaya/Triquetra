namespace Triquetra.Domain.Data.Entities
{
    public class ExchangeRate : BaseEntity
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}