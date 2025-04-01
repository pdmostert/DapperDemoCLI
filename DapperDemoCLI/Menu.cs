using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemoCLI;
internal static class Menu
{
    internal static int GetChoice()
    {
       var choice = Console.ReadLine();
        return Convert.ToInt32(choice);
    }

    internal static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("##### Journal App ####");
        Console.WriteLine("1. Add Journal");
        Console.WriteLine("2. View Journals");
        Console.WriteLine("3. Update Journal");
        Console.WriteLine("4. Delete Journal");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice: ");
    }


}
