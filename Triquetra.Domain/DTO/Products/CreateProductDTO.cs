namespace Triquetra.Domain.DTO.Products
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public double? Size { get; set; }
        public double? DollarPrice { get; set; }
        public int ProductTypeId { get; set; }
    }
}