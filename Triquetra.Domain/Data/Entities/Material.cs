namespace Triquetra.Domain.Data.Entities
{
    public class Material : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int MaterialUnitId { get; set; }
        public double? Price { get; set; }
        public double? Cost { get; set; }
        public MaterialUnit MaterialUnit { get; set; }
        public ICollection<ContractMaterial> ContractMaterials { get; set; }
    }
}