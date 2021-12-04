using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using sonar.DayOne;
using sonar.DayThree;
using sonar.DayTwo;

namespace sonar;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IOutputWriter, ConsoleWriter>()
            .AddSingleton<ISonarReader, SonarReader>()
            .AddSingleton<IDepthIncreaseCalculator, DepthIncreaseCalculator>()
            .AddSingleton<ICommandReader, CommandReader>()
            .AddSingleton<IDayThreeCalculator, DayThreeCalculator>()
            .AddSingleton<IDayThreeReader, DayThreeReader>()
            .AddSingleton<DayOneRunner>()
            .AddSingleton<DayTwoRunner>()
            .AddSingleton<DayThreeRunner>()
            .BuildServiceProvider();
        
        switch (args[0])
        {
            case "day1":
                await serviceProvider.GetService<DayOneRunner>()?.Run(args)!;
                break;
            case "day2":
                await serviceProvider.GetService<DayTwoRunner>()?.Run(args)!;
                break;
            case "day3":
                await serviceProvider.GetService<DayThreeRunner>()?.Run(args)!;
                break;
        }
    }
}