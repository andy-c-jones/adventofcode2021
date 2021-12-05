namespace sonar.DayFour;

public class Board : IBoard
{
    public Board(GridItem[][] grid)
    {
        Grid = grid;
    }

    public GridItem[][] Grid { get; private set; }

    public void MarkNumber(int number)
    {
    }

    public (bool, int sumOfUnmarkedNumbers) HasBoardWon()
    {
        return (false, 0);
    }
}

public interface IBoard
{
    void MarkNumber(int number);
    (bool, int sumOfUnmarkedNumbers) HasBoardWon();
}