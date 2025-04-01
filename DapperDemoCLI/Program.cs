using DapperDemoCLI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistance;
using Persistance.Repositories;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var app = host.Services.GetRequiredService<MyApp>();
        app.ShowMenu();


    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddTransient<ISQLDataAccess, SQLDataAccess>();
                services.AddTransient<IJournalRepo, JournalRepo>();
                services.AddTransient<MyApp>();
            });
}
