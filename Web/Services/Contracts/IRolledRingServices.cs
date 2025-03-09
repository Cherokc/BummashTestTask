using ForgingModelCalculator.Web.Models;

namespace ForgingModelCalculator.Web.Services.Contracts
{
    public interface IRolledRingServices
    {
        RolledRingCalculatedSizesModel CalculateRolledRingSizes(RolledRingModel rolledRing);
    }
}
