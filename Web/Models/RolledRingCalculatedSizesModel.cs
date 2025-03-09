using ForgingModelCalculator.Domain.Models;

namespace ForgingModelCalculator.Web.Models
{
    public class RolledRingCalculatedSizesModel
    {
        public RolledRing RolledRing { get; set; }
        public RolledRingCalculatedForgingSizes RolledRingCalculatedForgingSizesWithoutAllowance { get; set; }
        public RolledRingCalculatedForgingSizes RolledRingCalculatedForgingSizesWithAllowance { get; set; }
        public RolledRingCalculatedForgingMasses RolledRingCalculatedForgingMassesWithoutAllowance { get; set; }
        public RolledRingCalculatedForgingMasses RolledRingCalculatedForgingMassesWithAllowance { get; set; }
    }
}
