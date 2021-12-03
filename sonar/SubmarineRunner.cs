using sonar.Submarine;

namespace sonar;

public class SubmarineRunner
{
    private readonly ICommandReader _commandReader;
    private readonly IOutputWriter _writerObject;

    public SubmarineRunner(ICommandReader commandReader, IOutputWriter writerObject)
    {
        _commandReader = commandReader;
        _writerObject = writerObject;
    }

    public async Task Run(string[] args)
    {
        var readCommandsFromFile = await _commandReader.ReadCommandsFromFile(args[1]);
        var submarine = new Submarine.Submarine();
        submarine.Execute(readCommandsFromFile);
        var output = (submarine.Position.Depth * submarine.Position.Horizontal).ToString();
        _writerObject.WriteLine(output);
    }
}