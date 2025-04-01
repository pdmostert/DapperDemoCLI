using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemoCLI;
public class JournalService
{
    private readonly IJournalRepo _journalRepo;

    public JournalService(IJournalRepo journalRepo)
    {
        _journalRepo = journalRepo;
    }

    public void ShowJournalList()
    {
        var journalEntries = _journalRepo.GetAll().Result;

        foreach (var item in journalEntries)
        {
            Console.Clear();
            Console.WriteLine("##### Journal Entries ####");
            Console.WriteLine($"{item.Id}, {item.Title}, {item.CreatedDate}");
            Console.WriteLine("##########################");
            Console.Write("Enter to Continue");
            Console.ReadLine();

        }


    }

}
