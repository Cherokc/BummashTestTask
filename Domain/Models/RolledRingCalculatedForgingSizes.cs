namespace ForgingModelCalculator.Domain.Models
{
    public record RolledRingCalculatedForgingSizes
    {
        public SizeWithTolerance Height { get; set; }
        public SizeWithTolerance Diameter { get; set; }
        public SizeWithTolerance InnerDiameter { get; set; }
    }
}
