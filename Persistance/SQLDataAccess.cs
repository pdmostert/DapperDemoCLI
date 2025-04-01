using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Persistance;

public class SQLDataAccess : ISQLDataAccess
{
    private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JournalDB;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"; //tobe refactored later



    public async Task<List<T>> Load<T, U>(string sql, U parameters)
    {
        try
        {
            //string? connectionString = _config.GetConnectionString(ConnectionStringName);
            string? connectionString = _connectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is null or empty.");
            }
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters, commandType: CommandType.Text);
                return data.ToList();
            }
        }
        catch (Exception ex)
        {

            throw;
        }

    }

    public async Task<int> Save<T>(string sql, T parameters, CommandType type)
    {
        //string? connectionString = _config.GetConnectionString(ConnectionStringName);
        string? connectionString = _connectionString;
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string is null or empty.");
        }
        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            int result = await connection.ExecuteScalarAsync<int>(sql, parameters, commandType: type);
            return result;
        }
    }





}
