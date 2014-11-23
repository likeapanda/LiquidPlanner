using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPlanner
{
    public class Task
    {
        public string name { get; set; }

        public List<CheckListItem> checklist_items { get; set; }
        public Dictionary<string, string> custom_field_values { get; set; }
    }
}
