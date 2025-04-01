
using Domain;

namespace Persistance.Repositories;

public interface IJournalRepo
{
    Task<int> Create(Journal journal);
    Task<int> Delete(int id);
    Task<Journal> Get(int id);
    Task<IEnumerable<Journal>> GetAll();
    Task<int> Update(Journal journal);
}