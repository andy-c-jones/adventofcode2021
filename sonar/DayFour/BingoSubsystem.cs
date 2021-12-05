namespace sonar.DayFour;

public class BingoSubsystem : IBingoSubsystem
{
    private readonly IRoundExecutor _roundExecutor;

    public BingoSubsystem(IRoundExecutor roundExecutor)
    {
        _roundExecutor = roundExecutor;
    }
    
    public int DrawNumbersUntilThereIsAWinner(BingoGameData data)
    {
        var (numberWhenWon, sumOfUnmarkedNumbersOnWinningBoard) = FindWinner(data);
        return numberWhenWon * sumOfUnmarkedNumbersOnWinningBoard;
    }

    private (int numberWhenWon, int SumOfUnmarkedNumbersOnWinningBoard) FindWinner(BingoGameData data) =>
        data.NumbersToDraw.Select(number => new Result(_roundExecutor.Execute(number, data.Boards), number))
            .Where(result => result.ExecuteResult.win)
            .Select(result => (result.Number, result.ExecuteResult.winningBoard!.SumOfUnmarkedNumbers()))
            .FirstOrDefault();

    private record Result((bool win, IBoard? winningBoard) ExecuteResult, int Number);
}

public interface IBingoSubsystem
{
    public int DrawNumbersUntilThereIsAWinner(BingoGameData data);
}