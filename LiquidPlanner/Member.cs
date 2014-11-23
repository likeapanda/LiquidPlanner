using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPlanner
{
    public class Member : LpObject
    {
        public String name { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }

        public override String ToString()
        {
            return "User: " + this.id + "> " + this.name + "> " + this.first_name + " " + this.last_name;
        }
    }
}
