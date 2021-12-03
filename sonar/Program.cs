using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using sonar.Sonar;
using sonar.Submarine;

namespace sonar;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IDepthIncreaseCalculator, DepthIncreaseCalculator>()
            .AddSingleton<ISonarReader, SonarReader>()
            .AddSingleton<IOutputWriter, ConsoleWriter>()
            .AddSingleton<ICommandReader, CommandReader>()
            .AddSingleton<Runner>()
            .AddSingleton<SubmarineRunner>()
            .BuildServiceProvider();
        
        switch (args[0])
        {
            case "sonar":
                await serviceProvider.GetService<Runner>()?.Run(args)!;
                break;
            case "movesub":
                await serviceProvider.GetService<SubmarineRunner>()?.Run(args)!;
                break;
        }
    }
}