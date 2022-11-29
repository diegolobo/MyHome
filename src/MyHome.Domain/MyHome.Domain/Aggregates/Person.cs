namespace MyHome.Domain.Aggregates
{
    public abstract class Person
    {
        protected Person(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string? Name { get; init; }
        public int Age => new DateTime(DateTime.Now.Subtract(BirthDate).Ticks).Year;
        public DateTime BirthDate { get; init; }
    }
}
