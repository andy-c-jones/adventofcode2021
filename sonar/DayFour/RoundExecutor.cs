using System.Collections;

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
    
    public (bool win, IEnumerable<IBoard> winningBoard) ExecutePartTwo(int number, IEnumerable<IBoard> boards)
    {
        var boardsAsList = boards.ToList();
        boardsAsList.ForEach(b => b.MarkNumber(number));
        var winningBoards = boardsAsList.Where(b => b.HasBoardWon()).ToList();
        return winningBoards.Any() ? (true, winningBoards): (false, new List<IBoard>());
    }
}

public interface IRoundExecutor
{
    public (bool win, IBoard? winningBoard) Execute(int number, IEnumerable<IBoard> boards);

    public (bool win, IEnumerable<IBoard> winningBoard) ExecutePartTwo(int number, IEnumerable<IBoard> boards);
}