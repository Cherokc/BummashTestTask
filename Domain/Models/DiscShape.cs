namespace ForgingModelCalculator.Domain.Models
{
    public record DiscShape
    {
        public decimal Diameter { get; set; }
        public decimal Height { get; set; }
        public decimal Volume 
        { 
            get
            {
                return (decimal)Math.PI * (Diameter*Diameter / 4m) * Height;    
            }
        }
        public decimal Mass
        {
            get
            {
                return Volume * 0.78m / 10e8m;
            }
        }
    }
}
