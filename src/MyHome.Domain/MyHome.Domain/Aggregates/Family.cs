using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Domain.Aggregate
{
    public class Family
    {
        public Family()
        {
            Dependents = new List<Dependent>();
        }

        public double Income { get; set; }
        public List<Dependent> Dependents { get; set; }

        public void AddDependent(Dependent dependent)
        {
            Dependents.Add(dependent);
        }
    }
}
