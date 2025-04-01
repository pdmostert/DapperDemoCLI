using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories;
public class JournalRepo : IJournalRepo
{
    private readonly ISQLDataAccess _context;
    public JournalRepo(ISQLDataAccess context)
    {
        _context = context;
    }


    //CRUD = Create, Read/Get(All, ById), Update , Delete

    public async Task<IEnumerable<Journal>> GetAll()
    {
        string sql = "SELECT Id, Title, CreatedDate, Content FROM dbo.Journals";
        return await _context.Load<Journal, dynamic>(sql, new { });
    }

    public async Task<Journal> Get(int id)
    {
        string sql = "SELECT Id, Title, CreatedDate, Content Journals WHERE Id = @Id";
        var journal = await _context.Load<Journal, dynamic>(sql, new { Id = id });
        return journal.FirstOrDefault();
    }

    public async Task<int> Create(Journal journal)
    {
        string sql = @"INSERT INTO Journals (Title, Content, CreatedDate) VALUES (@Title, @Content, @CreatedDate);";
        return await _context.Save<Journal>(sql, journal, CommandType.Text);
    }

    public async Task<int> Update(Journal journal)
    {
        string sql = @"UPDATE Journals SET Title = @Title, Content = @Content, CreatedDate = @CreatedDate WHERE Id = @Id";
        return await _context.Save<Journal>(sql, journal, CommandType.Text);
    }

    public async Task<int> Delete(int id)
    {
        string sql = @"DELETE FROM Journals WHERE Id = @Id";
        return await _context.Save(sql, new { Id = id }, CommandType.Text);
    }



}
