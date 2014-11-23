using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            String username, password;
            if (args.Length < 2)
            {
                username = "aleksandr.gostev@oecd.org";
                password = "aleksandr";
            }
            else
            {
                username = args[0];
                password = args[1];
            }

            var liquidplanner = new LiquidPlanner(username, password);

            var myAccount = liquidplanner.GetAccount();
            Console.WriteLine(myAccount.ToString());

            Package package = liquidplanner.GetPackage(18735015);
            //Console.WriteLine(package);
            if (package.children == null) return;
            var totalDoneToday = 0;
            var totalCheckListItems = 0;
            foreach (var task in package.children)
            {
                if (task.custom_field_values.Any(x => x.Value == "To Do" || x.Value == "In Progress" || x.Value == "Validation" || x.Value == "Completed"))
                {
                    totalDoneToday += task.checklist_items.Count(x => x.completed);
                    totalCheckListItems += task.checklist_items.Count();
                }
            }

            Console.WriteLine("Total Done today checklist items: " + totalDoneToday + ", Total check list items: " + totalCheckListItems);
        }
    }
}
