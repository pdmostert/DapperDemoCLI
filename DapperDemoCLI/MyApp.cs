using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemoCLI;
public class MyApp
{
    private readonly IJournalRepo _journalRepo;

    public MyApp(IJournalRepo journalRepo)
    {
        _journalRepo = journalRepo;
    }



    public void ShowMenu()
    {
        Console.WriteLine("1. Add Journal");
        Console.WriteLine("2. View Journals");
        Console.WriteLine("3. Update Journal");
        Console.WriteLine("4. Delete Journal");
        Console.WriteLine("5. Exit");
        Console.WriteLine("Enter your choice: ");
        var choice = Console.ReadLine();

        if (int.Parse(choice) == 2)
        {
            ShowJournalList();
        }






    }


    public void ShowJournalList()
    {
        var journalEntries = _journalRepo.GetAll().Result;

        foreach (var item in journalEntries)
        {
            Console.WriteLine($"{item.Id}, {item.Title}, {item.CreatedDate}");
        }


    }




}
