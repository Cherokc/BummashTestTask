using ForgingModelCalculator.Domain.Models;
using ForgingModelCalculator.Web.Models;

namespace ForgingModelCalculator.Web.Extensions.Mappers
{
    public static class RolledRingMappers
    {
        public static RolledRing ToDaoRolledRing(this RolledRingModel ringDto)
        {
            return new RolledRing()
            {
                D = ringDto.D,
                d = ringDto.InnderD,
                H = ringDto.H,
                x = ringDto.x,
                y = ringDto.y,
                Q = ringDto.Q,
                ThermalTreatmentAllowance = ringDto.ThermalTreatmentAllowance
            };
        }
    }
}
