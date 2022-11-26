namespace MyHome.Domain.Aggregate
{
    public class Family
    {
        public Family(double income)
        {
            Dependents = new List<Dependent>();
            Income = income;
        }

        public double Income { get; set; }
        public List<Dependent> Dependents { get; set; }

        public void AddDependent(Dependent dependent)
        {
            if (dependent == null) throw new ArgumentNullException(nameof(dependent));

            Dependents.Add(dependent);
        }
    }
}
