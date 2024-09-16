using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WitchApp.Models;

namespace WitchApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly WitchFacade _witchFacade;
        public HomeController(WitchFacade witchFacade)
        {
            _witchFacade = witchFacade;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateAverageKills(int personA_age, int personA_deathYear, int personB_age, int personB_deathYear)
        {
            //encapsulate given parameters in Villager object
            var villagerA = new Villager(personA_age, personA_deathYear);
            var villagerB = new Villager(personB_age, personB_deathYear);

            double averageKills = _witchFacade.CalculateAverageKills(villagerA, villagerB);

            return View("Index", new CalculationResult { AverageKills = averageKills });
        }
    }
}
