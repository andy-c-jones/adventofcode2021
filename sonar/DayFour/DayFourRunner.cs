namespace sonar.DayFour;

public class DayFourRunner
{
    private readonly IBingoReader _reader;
    private readonly IBingoSubsystem _bingoSubsystem;
    private readonly IOutputWriter _writer;

    public DayFourRunner(IBingoReader reader, IBingoSubsystem bingoSubsystem, IOutputWriter writer)
    {
        _reader = reader;
        _bingoSubsystem = bingoSubsystem;
        _writer = writer;
    }

    public async Task Run(string[] args)
    {
        var data = await _reader.ReadFrom(args[1]);
        _writer.WriteLine($"Part 1 Score: {_bingoSubsystem.DrawNumbersUntilThereIsAWinner(data).ToString()}");
        
        var dataTwo = await _reader.ReadFrom(args[1]);
        _writer.WriteLine($"Part 2 Score: {_bingoSubsystem.FindTheLastBoardToWin(dataTwo).ToString()}");
    }
}