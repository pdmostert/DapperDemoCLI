using System.Data;

namespace Persistance;
public interface ISQLDataAccess
{
    Task<List<T>> Load<T, U>(string sql, U parameters);
    Task<int> Save<T>(string sql, T parameters, CommandType type);
}