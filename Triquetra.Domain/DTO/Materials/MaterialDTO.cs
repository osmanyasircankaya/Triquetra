namespace Triquetra.Domain.DTO.Materials
{
    public class MaterialDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaterialUnitId { get; set; }
        public double? Price { get; set; }
        public double? Cost { get; set; }
        public DateTime AddedOn { get; set; }
    }
}