namespace sonar.DayOne;

public class DayOneRunner
{
    private readonly ISonarReader _reader;
    private readonly IDepthIncreaseCalculator _calculator;
    private readonly IOutputWriter _outputWriter;

    public DayOneRunner(ISonarReader reader, IDepthIncreaseCalculator calculator, IOutputWriter outputWriter)
    {
        _reader = reader;
        _calculator = calculator;
        _outputWriter = outputWriter;
    }
    
    public async Task Run(string[] args)
    {
        var measurementsFromFile = await _reader.ReadSonarMeasurementsFromFile(args[1]);
        var increases = _calculator.CountIncreases(measurementsFromFile);
        _outputWriter.WriteLine(increases.ToString());
    }
}