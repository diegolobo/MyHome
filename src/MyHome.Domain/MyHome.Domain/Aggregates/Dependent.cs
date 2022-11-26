namespace MyHome.Domain.Aggregate
{
    public class Dependent
    {
        public string Name { get; init; }
        public int Age => new DateTime(DateTime.Now.Subtract(BirthDate).Ticks).Year;
        public DateTime BirthDate { get; init; }
    }
}
