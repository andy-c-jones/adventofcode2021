namespace sonar.Submarine;

public class Submarine
{
    public Position Position { get; private set; }

    public Submarine(int horizontal = 0, int depth = 0) => Position = new Position(horizontal, depth);

    private readonly Dictionary<CommandType, Action<Submarine, int>> _commands = new()
    {
        { CommandType.Down, ExecuteDown },
        { CommandType.Up, ExecuteUp },
        { CommandType.Forwards, ExecuteForwards }
    };

    private static void ExecuteForwards(Submarine submarine, int value) => submarine.Position =
        new Position(submarine.Position.Horizontal + value, submarine.Position.Depth);

    private static void ExecuteUp(Submarine submarine, int value) => submarine.Position =
        new Position(submarine.Position.Horizontal, submarine.Position.Depth - value);

    private static void ExecuteDown(Submarine submarine, int value) => submarine.Position =
        new Position(submarine.Position.Horizontal, submarine.Position.Depth + value);

    public void Execute(IEnumerable<SubmarineCommand> commands)
    {
        foreach (var (commandType, value) in commands)
        {
            _commands[commandType].Invoke(this, value);
        }
    }
}

public enum CommandType
{
    Up,
    Down,
    Forwards
}

public record struct SubmarineCommand(CommandType Type, int Value);

public record struct Position(int Horizontal, int Depth);