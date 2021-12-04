using System.Text;

namespace sonar.DayTwo;

public class CommandReader : ICommandReader
{
    public async Task<SubmarineCommand[]> ReadCommandsFromFile(string filePath)
    {
        var lines = await File.ReadAllLinesAsync(filePath, Encoding.UTF8);

        return lines.Select(l =>
        {
            var lineParts = l.Split(' ');
            var commandAsString = lineParts.First();
            var valueAsString = lineParts.Skip(1).Take(1).First();
            return new SubmarineCommand(InterpretCommand(commandAsString), int.Parse(valueAsString));
        }).ToArray();
    }

    private static CommandType InterpretCommand(string commandAsString) =>
        commandAsString switch
        {
            "down" => CommandType.Down,
            "up" => CommandType.Up,
            "forward" => CommandType.Forwards,
            _ => throw new Exception("Not a known command")
        };
}

public interface ICommandReader
{
    Task<SubmarineCommand[]> ReadCommandsFromFile(string filePath);
}