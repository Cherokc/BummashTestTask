using ForgingModelCalculator.Domain.Models;

namespace ForgingModelCalculator.Domain.Contracts
{
    public interface IRolledRingForgeSizesCalculator
    {
        RolledRingCalculatedForgingSizes GetForgingSizesWithAllowance(RolledRing ring);
        RolledRingCalculatedForgingSizes GetForgingSizesWithoutAllowance(RolledRing ring);
    }
}
