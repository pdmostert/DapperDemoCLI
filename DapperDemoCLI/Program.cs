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
        using IHost host = CreateHostBuilder(args).Build();
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        services.GetRequiredService<MyApp>().Run(args);

    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddScoped<ISQLDataAccess, SQLDataAccess>();
                services.AddScoped<IJournalRepo, JournalRepo>();
                services.AddScoped<JournalService>();
                services.AddSingleton<MyApp>();
            });
}
