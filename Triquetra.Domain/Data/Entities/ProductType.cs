namespace Triquetra.Domain.Data.Entities
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}