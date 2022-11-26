namespace MyHome.Domain.Aggregates
{
    public class Family
    {
        public Family(double income)
        {
            Dependents = new List<Dependent>();
            Income = income;
        }

        public double Income { get; }
        public List<Dependent> Dependents { get; }

        public void AddDependent(Dependent dependent)
        {
            if (dependent == null) throw new ArgumentNullException(nameof(dependent));

            Dependents.Add(dependent);
        }

        public static Family DefaultFamily => new(0);
    }
}
