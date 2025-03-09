using ForgingModelCalculator.Domain.Contracts;
using ForgingModelCalculator.Web.Models;
using ForgingModelCalculator.Web.Services.Contracts;
using ForgingModelCalculator.Web.Repositories;
using ForgingModelCalculator.Web.Extensions.Mappers;

namespace ForgingModelCalculator.Web.Services
{
    public class RolledRingServices : IRolledRingServices
    {
        private readonly IRolledRingForgeSizesCalculator _sizesCalculator;
        private readonly IRolledRingForgingMassesCalculator _massesCalculator;

        public RolledRingServices(
            IRolledRingForgeSizesCalculator sizesCalculator,
            IRolledRingForgingMassesCalculator massesCalculator)
        {
            _sizesCalculator = sizesCalculator;
            _massesCalculator = massesCalculator;
        }

        public RolledRingCalculatedSizesModel CalculateRolledRingSizes(RolledRingModel rolledRing)
        {
            var daoRing = rolledRing.ToDaoRolledRing();

            var ringSizesWithoutAllowances = _sizesCalculator.GetForgingSizesWithoutAllowance(daoRing);
            var ringSizesWithAllowances = _sizesCalculator.GetForgingSizesWithAllowance(daoRing);

            var ringMassesWithoutAllowances = _massesCalculator.CalculateRingForgingMasses(ringSizesWithoutAllowances);
            var ringMassesWithAllowances = _massesCalculator.CalculateRingForgingMasses(ringSizesWithAllowances);

            return new RolledRingCalculatedSizesModel
            {
                RolledRing = daoRing,
                RolledRingCalculatedForgingSizesWithoutAllowance = ringSizesWithoutAllowances,
                RolledRingCalculatedForgingSizesWithAllowance = ringSizesWithAllowances,
                RolledRingCalculatedForgingMassesWithoutAllowance = ringMassesWithoutAllowances,
                RolledRingCalculatedForgingMassesWithAllowance = ringMassesWithAllowances,
            };
        }
    }
}
