using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPlanner
{
    public class Package
    {
        public string name { get; set; }

        public List<Task> children { get; set; }

        public override string ToString()
        {
            return String.Format("Package name: {0}", name);
        }
    }
}
