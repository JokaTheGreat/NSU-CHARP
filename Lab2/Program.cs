namespace Lab2;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddHostedService<Princess>()
                    .AddSingleton<IHall, Hall>()
                    .AddSingleton<IFreind, Freind>()
                    .AddSingleton<IContenderGenerator, ContenderGenerator>();
            })
            .Build();

        host.Run();
    }
}