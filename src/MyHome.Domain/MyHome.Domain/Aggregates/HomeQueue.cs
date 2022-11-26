using MyHome.Domain.Services;

namespace MyHome.Domain.Aggregate
{
    public class HomeQueue
    {
        private readonly IOrderStrategy _orderStrategy;

        public HomeQueue(IOrderStrategy orderStrategy)
        {
            _orderStrategy = orderStrategy;
            Families = new List<Family>();
        }

        public List<Family> Families { get; set; }

        public void AddFamily(Family family)
        {
            if (family == null) throw new ArgumentNullException(nameof(family));

            Families.Add(family);
        }

        public Family GetAbleFamily()
        {
            return _orderStrategy.GetNextFamily(this);
        }

        public void PopFamily()
        {
            var family = GetAbleFamily();

            Families.Remove(family);
        }
    }
}
