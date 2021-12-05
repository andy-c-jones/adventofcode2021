namespace sonar.DayFour;

public class BingoSubsystem : IBingoSubsystem
{
    private readonly IRoundExecutor _roundExecutor;

    public BingoSubsystem(IRoundExecutor roundExecutor)
    {
        _roundExecutor = roundExecutor;
    }

    public int DrawNumbersUntilThereIsAWinner(BingoGameData data) => Score(data, FindWinner);

    public int FindTheLastBoardToWin(BingoGameData data) => Score(data, FindLastWinner);

    private static int Score(BingoGameData data, Func<BingoGameData,
        (int numberWhenWon, int SumOfUnmarkedNumbersOnWinningBoard)> func)
    {
        var (numberWhenWon, sumOfUnmarkedNumbersOnWinningBoard) = func(data);
        return numberWhenWon * sumOfUnmarkedNumbersOnWinningBoard;
    }

    private (int numberWhenWon, int SumOfUnmarkedNumbersOnWinningBoard) FindLastWinner(BingoGameData data)
    {
        var boards = data.Boards.ToList();
        (int numberWhenWon, IBoard board) lastWinningBoard = (0, null)!;

        foreach (var number in data.NumbersToDraw)
        {
            var (win, winningBoard) = _roundExecutor.ExecutePartTwo(number, boards);
            if (win)
            {
                var winningBoards = winningBoard.ToList();
                lastWinningBoard = (number, winningBoards.Last())!;
                foreach (var b in winningBoards) boards.Remove(b);
            }

            if (boards.Count == 0)
                return (lastWinningBoard.numberWhenWon, lastWinningBoard.board!.SumOfUnmarkedNumbers());
        }

        return (lastWinningBoard.numberWhenWon, lastWinningBoard.board!.SumOfUnmarkedNumbers());
    }

    private (int numberWhenWon, int SumOfUnmarkedNumbersOnWinningBoard) FindWinner(BingoGameData data)
    {
        foreach (var number in data.NumbersToDraw)
        {
            var (win, winningBoard) = _roundExecutor.Execute(number, data.Boards);
            if (win)
                return (number, winningBoard!.SumOfUnmarkedNumbers());
        }

        return (0, 0);
    }
}

public interface IBingoSubsystem
{
    public int DrawNumbersUntilThereIsAWinner(BingoGameData data);

    public int FindTheLastBoardToWin(BingoGameData data);
}