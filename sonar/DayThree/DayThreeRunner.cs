namespace sonar.DayThree;

public class DayThreeRunner
{
    private readonly IDayThreeReader _reader;
    private readonly IOutputWriter _writer;
    private readonly IDayThreeCalculator _calculator;

    public DayThreeRunner(IDayThreeReader reader, IOutputWriter writer, IDayThreeCalculator calculator)
    {
        _reader = reader;
        _writer = writer;
        _calculator = calculator;
    }

    public async Task Run(string[] args)
    {
        var input = await _reader.Read(args[1]);
        var powerConsumption = _calculator.CalculatePowerConsumption(input);
        _writer.WriteLine(powerConsumption.ToString());
    }
}