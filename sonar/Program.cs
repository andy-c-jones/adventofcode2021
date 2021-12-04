using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using sonar.DayOne;
using sonar.DayTwo;

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
            .AddSingleton<DayOneRunner>()
            .AddSingleton<DayTwoRunner>()
            .BuildServiceProvider();
        
        switch (args[0])
        {
            case "sonar":
                await serviceProvider.GetService<DayOneRunner>()?.Run(args)!;
                break;
            case "movesub":
                await serviceProvider.GetService<DayTwoRunner>()?.Run(args)!;
                break;
        }
    }
}