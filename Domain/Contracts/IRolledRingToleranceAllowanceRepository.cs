using ForgingModelCalculator.Domain.Models;

namespace ForgingModelCalculator.Domain.Contracts
{
    public interface IRolledRingToleranceAllowanceRepository
    {
        RolledRingToleranceAllowance GetToleranceAllowance(decimal height, decimal diameter);

        IReadOnlyList<RolledRingToleranceAllowance> GetAllToleranceAllowances();
    }
}
