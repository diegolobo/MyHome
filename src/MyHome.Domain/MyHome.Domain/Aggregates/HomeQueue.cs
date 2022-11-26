using MyHome.Domain.Services;

namespace MyHome.Domain.Aggregate
{
    public class HomeQueue
    {
        public HomeQueue()
        {
            Families = new List<Family>();
        }

        public List<Family> Families { get; set; }

        public void AddFamily(Family family)
        {
            if (family == null) throw new ArgumentNullException(nameof(family));

            Families.Add(family);
        }

        public Family GetAbleFamily(IOrderStrategy orderStrategy)
        {
            return orderStrategy.GetNextFamily(this);
        }
    }
}
