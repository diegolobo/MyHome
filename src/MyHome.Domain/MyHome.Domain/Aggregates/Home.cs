using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHome.Domain.Services;

namespace MyHome.Domain.Aggregate
{
    public class Home
    {
        public Home()
        {
            Families = new List<Family>();
        }

        public List<Family> Families { get; set; }

        public void AddFamily(Family family)
        {
            Families.Add(family);
        }

        public Family GetNextFamily(IOrderStrategy orderStrategy)
        {
            return orderStrategy.GetNextFamily(this);
        }
    }
}
