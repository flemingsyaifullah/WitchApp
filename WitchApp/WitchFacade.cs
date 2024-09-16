using WitchApp.Interfaces;
using WitchApp.Models;

namespace WitchApp
{
    //create facade to handling services
    public class WitchFacade
    {
        private readonly IValidationService _validationService;
        private readonly IKillCalculatorService _killCalculatorService;

        public WitchFacade(IValidationService validationService, IKillCalculatorService killCalculatorService)
        {
            _killCalculatorService = killCalculatorService;
            _validationService = validationService;
        }

        public double CalculateAverageKills(Villager villagerA, Villager villagerB)
        {
            if (!_validationService.ValidateData(villagerA.Age, villagerA.YearOfDeath)
            || !_validationService.ValidateData(villagerB.Age, villagerB.YearOfDeath))
            {
                return -1;
            }

            return _killCalculatorService.CalculateAverageKillsOfTwoVillagers(villagerA, villagerB);
        }
    }
}
