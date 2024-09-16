using WitchApp.Models;

namespace WitchApp.Interfaces
{
    public interface IKillCalculatorService
    {
        double CalculateAverageKillsOfTwoVillagers(Villager villagerA, Villager villagerB);
    }
}
