using ForgingModelCalculator.Domain.Contracts;
using ForgingModelCalculator.Domain.Models;

namespace ForgingModelCalculator.Infrastructure.Calculators
{
    public class RolledRingForgingSizesCalculator : IRolledRingForgeSizesCalculator
    {
        private readonly IRolledRingToleranceAllowanceRepository _repository;

        public RolledRingForgingSizesCalculator(IRolledRingToleranceAllowanceRepository repository)
        {
            _repository = repository;
        }

        public RolledRingCalculatedForgingSizes GetForgingSizesWithAllowance(RolledRing ring)
        {
            var toleranceAllowanceForH2 = _repository.GetToleranceAllowance(ring.H2, ring.D);

            var allowedH2 = ring.H2 + toleranceAllowanceForH2.Allowance;
            var allowedD = ring.D + ring.ThermalTreatmentAllowance + toleranceAllowanceForH2.Allowance;
            var allowed_d = ring.d - ring.ThermalTreatmentAllowance - toleranceAllowanceForH2.Allowance;

            return new RolledRingCalculatedForgingSizes
            {
                Height = new SizeWithTolerance(allowedH2, toleranceAllowanceForH2.Tolerance),
                Diameter = new SizeWithTolerance(allowedD, toleranceAllowanceForH2.Tolerance),
                InnerDiameter = new SizeWithTolerance(allowed_d, 3 * toleranceAllowanceForH2.Tolerance)
            };
        }

        public RolledRingCalculatedForgingSizes GetForgingSizesWithoutAllowance(RolledRing ring)
        {
            var toleranceAllowanceForH1 = _repository.GetToleranceAllowance(ring.H1, ring.D);

            var allowedH1 = ring.H1 + toleranceAllowanceForH1.Allowance;
            var disallowedD = ring.D + ring.ThermalTreatmentAllowance + toleranceAllowanceForH1.Allowance;
            var disallowed_d = ring.d - ring.ThermalTreatmentAllowance - toleranceAllowanceForH1.Allowance;

            return new RolledRingCalculatedForgingSizes
            {
                Height = new SizeWithTolerance(allowedH1, toleranceAllowanceForH1.Tolerance),
                Diameter = new SizeWithTolerance(disallowedD, toleranceAllowanceForH1.Tolerance),
                InnerDiameter = new SizeWithTolerance(disallowed_d, 3 * toleranceAllowanceForH1.Tolerance),
            };
        }
    }
}
