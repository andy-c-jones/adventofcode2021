namespace sonar.DayFive;

public class DayFiveRunner
{
    private readonly IDayFiveReader _reader;
    private readonly IStraightLineFilter _straightLineFilter;
    private readonly IDayFiveMapGenerator _generator;
    private readonly IDayFiveScoreCalculator _calculator;
    private readonly IOutputWriter _writer;

    public DayFiveRunner(IDayFiveReader reader, IStraightLineFilter straightLineFilter, IDayFiveMapGenerator generator,
        IDayFiveScoreCalculator calculator, IOutputWriter writer)
    {
        _reader = reader;
        _straightLineFilter = straightLineFilter;
        _generator = generator;
        _calculator = calculator;
        _writer = writer;
    }

    public async Task Run(string[] args)
    {
        var lines = await _reader.ReadLinesFrom(args[1]);
        var straightLines = _straightLineFilter.SelectStraightLines(lines);
        var map = _generator.CreateMap(straightLines);
        var count = _calculator.CountWhereThereAreXOrGreaterVents(2, map);
        _writer.WriteLine($"Part One: {count.ToString()}");
    }
}

