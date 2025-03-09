namespace ForgingModelCalculator.Domain.Models
{
    public record RolledRingCalculatedForgingMasses
    {
        public DiscShape DiskNominal { get; set; }
        public DiscShape DiskMax { get; set; }
        public DiscShape HoleNominal { get; set; }
        public DiscShape HoleMax { get; set; }
        public decimal MassOfDiscWithHoleNominal
        {
            get
            {
                return DiskNominal.Mass - HoleNominal.Mass;
            }
        }
        public decimal MassOfDiscWithHoleMax
        {
            get
            {
                return DiskMax.Mass - HoleMax.Mass;
            }
        }
    }
}
