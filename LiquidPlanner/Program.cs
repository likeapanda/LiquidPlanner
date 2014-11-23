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

            LiquidPlanner liquidplanner = new LiquidPlanner(username, password);

            Member myAccount = liquidplanner.GetAccount();
            Console.WriteLine(myAccount.ToString());


            liquidplanner.WorkspaceId = 75731;
            Package package = liquidplanner.GetPackage();
            Console.WriteLine(package);
            if (package.children == null) return;
            var totalDoneToday = package.children.Sum(child => child.checklist_items.Count(x => x.completed));
            var totalCheckListItems = package.children.Sum(child => child.checklist_items.Count());

            Console.WriteLine("Total Done today checklist items: " + totalDoneToday + ", Total check list items: " + totalCheckListItems);
        }
    }
}
