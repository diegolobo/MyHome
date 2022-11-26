using MyHome.Domain.Aggregate;

namespace MyHome.Domain.Services
{
    public class OrderStrategy : IOrderStrategy
    {
        private const int MIN_INCOME = 900;
        private const int MAX_INCOME = 1500;
        private const int MAX_AGE = 18;

        public Family GetNextFamily(HomeQueue home)
        {
            if (!home.Families.Any()) return null;

            Family nextFamily = home.Families.First();

            int maxTotalPointsFamily = 0;

            foreach (var family in home.Families)
            {
                int totalPoints = 0;

                if (family.Income <= MIN_INCOME)
                {
                    totalPoints += 5;
                }

                if (family.Income > MIN_INCOME && family.Income <= MAX_INCOME)
                {
                    totalPoints += 3;
                }

                var countAbleDepentes = family.Dependents.Count(x => x.Age < MAX_AGE);

                if (countAbleDepentes >= 3)
                {
                    totalPoints += 3;
                }
                else if (countAbleDepentes >= 1)
                {
                    totalPoints += 2;
                }

                if (totalPoints >= maxTotalPointsFamily)
                {
                    nextFamily = family;
                    maxTotalPointsFamily = totalPoints;
                }
            }

            return nextFamily;

        }
    }
}
