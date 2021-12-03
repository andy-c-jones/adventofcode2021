using Microsoft.Extensions.DependencyInjection;

namespace sonar;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IDepthIncreaseCalculator, DepthIncreaseCalculator>()
            .AddSingleton<ISonarReader, SonarReader>()
            .AddSingleton<IOutputWriter, ConsoleWriter>()
            .AddSingleton<Runner>()
            .BuildServiceProvider();
        
        var runner = serviceProvider.GetService<Runner>();
        await runner?.Run(args)!;
    }
}