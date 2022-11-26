using MyHome.Domain.Aggregates;

namespace MyHome.Domain.Services
{
    public class OrderStrategy : IOrderStrategy
    {
        private const int MinIncome = 900;
        private const int MaxIncome = 1500;
        private const int MaxAge = 18;

        public Family GetAbleFamily(HomeQueue home)
        {
            if (!home.Families.Any()) return Family.DefaultFamily;

            var nextFamily = home.Families.First();

            var maxTotalPointsFamily = 0;

            foreach (var family in home.Families)
            {
                var totalPoints = GetIncomePoints(family) + GetAgePoints(family);

                if (totalPoints < maxTotalPointsFamily) continue;
                nextFamily = family;
                maxTotalPointsFamily = totalPoints;
            }

            return nextFamily;
        }

        private static int GetAgePoints(Family family)
        {
            var countAbleDependents = family.Dependents.Count(x => x.Age < MaxAge);

            return countAbleDependents switch
            {
                >= 3 => 3,
                >= 1 => 2,
                _ => 0
            };
        }

        private static int GetIncomePoints(Family family)
        {
            return family.Income switch
            {
                <= MinIncome => 5,
                > MinIncome and <= MaxIncome => 3,
                _ => 0
            };
        }
    }
}
