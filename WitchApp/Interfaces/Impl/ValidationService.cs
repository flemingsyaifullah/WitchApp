namespace WitchApp.Interfaces.Impl
{
    public class ValidationService : IValidationService
    {
        public bool ValidateData(int age, int yearDeath)
        {
            //villager age must be greater than 0
            //villager yeardeath must be greater than 0
            if (age <= 0 || yearDeath <= 0)
            {
                return false;
            }

            //birth year must be at least the first year that witch control the village
            int yearOfBirth = yearDeath - age;
            if (yearOfBirth < 1)
            {
                return false;
            }

            return true;
        }
    }
}
