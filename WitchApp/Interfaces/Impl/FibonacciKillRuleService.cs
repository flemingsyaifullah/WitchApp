namespace WitchApp.Interfaces.Impl
{
    public class FibonacciKillRuleService: IKillRuleService
    {
        public int CalculateVillagerKillByYear(int year)
        {
            int a = 1, b = 1, sum = 2, index = 3;

            if (year == 1) return 1;
            if (year == 2) return 2;

            while (index <= year)
            {
                int nextKill = a + b;
                sum += nextKill;
                a = b;
                b = nextKill;
                index++;
            }

            return sum;
        }
    }
}
