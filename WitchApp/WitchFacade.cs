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

        public ResponseMessage<double> CalculateAverageKills(Villager villagerA, Villager villagerB)
        {
            var response = new ResponseMessage<double>();
            try
            {
                if (!_validationService.ValidateData(villagerA.Age, villagerA.YearOfDeath)
                || !_validationService.ValidateData(villagerB.Age, villagerB.YearOfDeath))
                {
                    response.Success = false;
                    response.Message = "Invalid input";
                    response.Data = -1;
                }
                else
                {
                    response.Success = true;
                    response.Data = _killCalculatorService.CalculateAverageKillsOfTwoVillagers(villagerA, villagerB);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.InnerException?.Message;
                response.Data = -1;
            }

            return response;
        }
    }
}
