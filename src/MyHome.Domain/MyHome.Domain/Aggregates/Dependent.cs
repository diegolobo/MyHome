namespace MyHome.Domain.Aggregates
{
    public class Dependent
    {
        public string? Name { get; set; }
        public int Age => new DateTime(DateTime.Now.Subtract(BirthDate).Ticks).Year;
        public DateTime BirthDate { get; init; }
    }
}
