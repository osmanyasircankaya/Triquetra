namespace Triquetra.Domain.Data.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double? Size { get; set; }
        public double? TLPrice { get; set; }
        public double? DollarPrice { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}