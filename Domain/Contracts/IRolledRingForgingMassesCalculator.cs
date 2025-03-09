using ForgingModelCalculator.Domain.Models;

namespace ForgingModelCalculator.Domain.Contracts
{
    public interface IRolledRingForgingMassesCalculator
    {
        RolledRingCalculatedForgingMasses CalculateRingForgingMasses(RolledRingCalculatedForgingSizes ringForgingSizes);
    }
}
