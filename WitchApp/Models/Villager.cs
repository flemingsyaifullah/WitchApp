namespace WitchApp.Models
{
    public class Villager
    {
        public int Age { get; set; }
        public int YearOfDeath { get; set; }

        public Villager(int age, int yearOfDeath)
        {
            Age = age;
            YearOfDeath = yearOfDeath;
        }
    }
}
