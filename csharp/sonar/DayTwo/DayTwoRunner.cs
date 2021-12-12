namespace sonar.DayTwo;

public class DayTwoRunner
{
    private readonly ICommandReader _commandReader;
    private readonly IOutputWriter _writerObject;

    public DayTwoRunner(ICommandReader commandReader, IOutputWriter writerObject)
    {
        _commandReader = commandReader;
        _writerObject = writerObject;
    }

    public async Task Run(string[] args)
    {
        var readCommandsFromFile = await _commandReader.ReadCommandsFromFile(args[1]);
        var submarine = new Submarine();
        submarine.Execute(readCommandsFromFile);
        var output = (submarine.Position.Depth * submarine.Position.Horizontal).ToString();
        _writerObject.WriteLine(output);
    }
}