namespace Triquetra.Domain.DTO.Contracts
{
    public class ContractDTO
    {
        public int Id { get; set; }
        public double PanelPower { get; set; }
        public double Power { get; set; }
        public double RoofSize { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public DateTime AddedOn { get; set; }
    }
}