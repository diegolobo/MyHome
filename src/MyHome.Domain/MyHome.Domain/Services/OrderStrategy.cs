using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHome.Domain.Aggregate;

namespace MyHome.Domain.Services
{
    public class OrderStrategy : IOrderStrategy
    {
        public Family GetNextFamily(Home home)
        {
            return home.Families.MinBy(f => f.Income)!;
        }
    }
}
