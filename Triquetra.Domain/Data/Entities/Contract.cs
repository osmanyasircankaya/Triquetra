namespace Triquetra.Domain.Data.Entities
{
    public class Contract : BaseEntity
    {
        public double PanelPower { get; set; }
        public double Power { get; set; }
        public double RoofSize { get; set; }
        public double? Price { get; set; }
        public double? Cost { get; set; }
        public double? TotalPrice { get; set; }
        public double? TotalCost { get; set; }
        public ICollection<ContractMaterial> ContractMaterials { get; set; }
    }
}