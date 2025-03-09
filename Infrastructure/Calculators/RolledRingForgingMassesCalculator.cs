using ForgingModelCalculator.Domain.Models;
using ForgingModelCalculator.Domain.Contracts;

namespace ForgingModelCalculator.Infrastructure.Calculators
{
    public class RolledRingForgingMassesCalculator : IRolledRingForgingMassesCalculator
    {
        public RolledRingCalculatedForgingMasses CalculateRingForgingMasses(RolledRingCalculatedForgingSizes ringForgingSizes)
        {
            var discNominal = new DiscShape()
            {
                Diameter = ringForgingSizes.Diameter.Value,
                Height = ringForgingSizes.Height.Value
            };
            var holeNominal = new DiscShape()
            {
                Diameter = ringForgingSizes.InnerDiameter.Value,
                Height = ringForgingSizes.Height.Value
            };

            var discMax = new DiscShape()
            {
                Diameter = ringForgingSizes.Diameter.Value + ringForgingSizes.Diameter.Tolerance,
                Height = ringForgingSizes.Height.Value + ringForgingSizes.Height.Tolerance
            };
            var holeMax = new DiscShape()
            {
                Diameter = ringForgingSizes.InnerDiameter.Value - ringForgingSizes.InnerDiameter.Tolerance,
                Height = ringForgingSizes.Height.Value + ringForgingSizes.Height.Tolerance
            };

            return new RolledRingCalculatedForgingMasses()
            {
                DiskNominal = discNominal,
                HoleNominal = holeNominal,
                DiskMax = discMax,
                HoleMax = holeMax
            };
        }
    }
}
