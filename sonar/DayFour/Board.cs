namespace sonar.DayFour;

public class Board : IBoard
{
    protected bool Equals(Board other)
    {
        return Grid.Equals(other.Grid);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Board) obj);
    }

    public override int GetHashCode()
    {
        return Grid.GetHashCode();
    }

    public Board(GridItem[,] grid)
    {
        Grid = grid;
    }

    public GridItem[,] Grid { get; private set; }

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