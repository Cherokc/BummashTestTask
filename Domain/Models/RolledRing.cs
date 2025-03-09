namespace ForgingModelCalculator.Domain.Models
{
    public record RolledRing
    {
        public decimal D { get; set; }
        public decimal d { get; set; }
        public decimal H { get; set; }
        public int x { get; set; }
        public decimal y { get; set; }

        public int z
        {
            get
            {
                return x - 1;
            }
        }

        public decimal Q { get; set; }

        public decimal ThermalTreatmentAllowance { get; set; }

        public decimal H1
        {
            get
            {
                return H * x + y * z + ThermalTreatmentAllowance;
            }
        }
        public decimal H2
        {
            get
            {
                return H * x + y * z + Q + ThermalTreatmentAllowance;
            }
        }
    }
}
