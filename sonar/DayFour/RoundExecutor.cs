namespace sonar.DayFour;

public class RoundExecutor : IRoundExecutor
{
    public (bool win, IBoard? winningBoard) Execute(int number, IEnumerable<IBoard> boards)
    {
        var boardsAsList = boards.ToList();
        boardsAsList.ForEach(b => b.MarkNumber(number));
        var winningBoard = boardsAsList.FirstOrDefault(b => b.HasBoardWon());
        return winningBoard != null ? (true, winningBoard): (false, null);
    }
}

public interface IRoundExecutor
{
    public (bool win, IBoard? winningBoard) Execute(int number, IEnumerable<IBoard> boards);
}