using System.Threading.Tasks;

namespace sonar;

public class Runner
{
    private readonly ISonarReader _reader;
    private readonly IDepthIncreaseCalculator _calculator;
    private readonly IOutputWriter _outputWriter;

    public Runner(ISonarReader reader, IDepthIncreaseCalculator calculator, IOutputWriter outputWriter)
    {
        _reader = reader;
        _calculator = calculator;
        _outputWriter = outputWriter;
    }
    
    public async Task Run(string[] args)
    {
        var measurementsFromFile = await _reader.ReadSonarMeasurementsFromFile(args[0]);
        var increases = _calculator.CountIncreases(measurementsFromFile);
        _outputWriter.WriteLine(increases.ToString());
    }
}