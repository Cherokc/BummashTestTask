namespace ForgingModelCalculator.Domain.Models
{
    public record RolledRingToleranceAllowance
    {
        public decimal HeightMin { get; set; }
        public decimal HeightMax { get; set; }
        public decimal DiameterMin { get; set; }
        public decimal DiameterMax { get; set; }
        public decimal Allowance { get; set; }
        public decimal Tolerance { get; set; }
    }
}
