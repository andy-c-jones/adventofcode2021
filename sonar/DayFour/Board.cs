namespace sonar.DayFour;

public class Board : IBoard
{
    public Board(GridItem[,] grid)
    {
        Grid = grid;
    }

    public GridItem[,] Grid { get; private set; }

    GridItem[,] IBoard.Grid() => Grid;

    public void MarkNumber(int number)
    {
    }

    public bool HasBoardWon()
    {
        return false;
    }
    
    public int SumOfUnmarkedNumbers() => 0;
}

public interface IBoard
{
    GridItem[,] Grid();   
    void MarkNumber(int number);
    bool HasBoardWon();
    int SumOfUnmarkedNumbers();
}