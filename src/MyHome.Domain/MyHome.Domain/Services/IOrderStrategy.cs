using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHome.Domain.Aggregate;

namespace MyHome.Domain.Services
{
    public interface IOrderStrategy
    {
        Family GetNextFamily(Home home);
    }
}
