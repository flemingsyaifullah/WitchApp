using WitchApp.Models;

namespace WitchApp.Interfaces.Impl
{
    public class KillCalculatorService : IKillCalculatorService
    {
        private readonly IKillRuleService _killRuleService;

        public KillCalculatorService(IKillRuleService killRuleService)
        {
            _killRuleService = killRuleService;
        }
        public double CalculateAverageKillsOfTwoVillagers(Villager villagerA, Villager villagerB)
        {
            int birthYearVillagerA = GetVillagerBirthYear(villagerA);
            int birthYearVillagerB = GetVillagerBirthYear(villagerB);

            int CountKillOnVillagerABirthYear = _killRuleService.CalculateVillagerKillByYear(birthYearVillagerA);
            int CountKillOnVillagerBBirthYear = _killRuleService.CalculateVillagerKillByYear(birthYearVillagerB);

            double averageKills = (CountKillOnVillagerABirthYear + CountKillOnVillagerBBirthYear) / 2.0;
            return averageKills;
        }

        private int GetVillagerBirthYear(Villager villager)
        {
            int year = 0;
            year = villager.YearOfDeath - villager.Age;
            return year;
        }
    }
}
