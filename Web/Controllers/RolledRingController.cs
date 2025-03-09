using ForgingModelCalculator.Web.Models;
using ForgingModelCalculator.Web.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ForgingModelCalculator.Controllers
{
    public class RolledRingController : Controller
    {
        private readonly ILogger<RolledRingController> _logger;
        private readonly IRolledRingServices _rolledRingServices;

        public RolledRingController(
            ILogger<RolledRingController> logger,
            IRolledRingServices rolledRingServices)
        {
            _logger = logger;
            _rolledRingServices = rolledRingServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RolledRingModel rolledRing)
        {
            if (ModelState.IsValid)
            {
                var calculatedRingSizes = _rolledRingServices.CalculateRolledRingSizes(rolledRing);

                return View("Result", calculatedRingSizes);
            }
            return View(rolledRing);
        }

        public IActionResult Result(RolledRingModel model)
        {
            return View();
        }
    }
}
