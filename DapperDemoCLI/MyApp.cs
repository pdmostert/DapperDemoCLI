using Microsoft.Extensions.Hosting;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemoCLI;
public class MyApp
{
    
    private bool exitApp = false;
    private readonly JournalService _journalService;

    public MyApp(JournalService journalService)
    {
        _journalService = journalService;
    }





    internal void Run(string[] args)
    {
        while (!exitApp)
        {
            Menu.ShowMenu();
            int choice = Menu.GetChoice();


            switch (choice)
            {
                case 1:
                    Console.WriteLine("Add Journal");
                    break;
                case 2:
                    _journalService.ShowJournalList();
                    break;
                case 3:
                    Console.WriteLine("Update Journal");
                    break;
                case 4:
                    Console.WriteLine("Delete Journal");
                    break;
                case 5:
                    Console.WriteLine("Exit");
                    exitApp = true;
                    break;
                default:
                    break;
            }
        }
    }


}
