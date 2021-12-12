namespace Triquetra.Domain.DTO.Products
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Size { get; set; }
        public double? TLPrice { get; set; }
        public double? DollarPrice { get; set; }
        public int ProductTypeId { get; set; }
        public DateTime AddedOn { get; set; }
    }
}