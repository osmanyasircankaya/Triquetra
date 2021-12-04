namespace Triquetra.Domain.Data.Entities
{
    public class MaterialUnit : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Material> Materials { get; set; }
    }
}