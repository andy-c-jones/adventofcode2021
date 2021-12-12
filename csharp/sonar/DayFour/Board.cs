namespace sonar.DayFour;

public class Board : IBoard
{
    public Board(GridItem[,] grid)
    {
        Grid = grid;
    }

    public GridItem[,] Grid { get; }

    GridItem[,] IBoard.Grid() => Grid;

    public void MarkNumber(int number)
    {
        foreach (var item in Grid)
        {
            if (item.Number == number) item.Marked = true;
        }
    }

    public bool HasBoardWon() => RowWinCondition() || ColumnWinCondition();

    private bool RowWinCondition()
    {
        for (var i = 0; i < Grid.GetLength(0); i++)
        {
            var win = true;
            for (var j = 0; j < Grid.GetLength(1); j++)
            {
                if (!Grid[i, j].Marked)
                    win = false;

                if (win == false) break;
            }

            if (win)
                return true;
        }

        return false;
    }

    private bool ColumnWinCondition()
    {
        for (var i = 0; i < Grid.GetLength(1); i++)
        {
            var win = true;
            for (var j = 0; j < Grid.GetLength(0); j++)
            {
                if (!Grid[j, i].Marked)
                    win = false;

                if (win == false) break;
            }

            if (win)
            {
                return true;
            }
        }

        return false;
    }

    public int SumOfUnmarkedNumbers() => Grid.Cast<GridItem?>()
        .Where(item => !item!.Marked)
        .Select(item => item!.Number)
        .Sum();
}

public interface IBoard
{
    GridItem[,] Grid();
    void MarkNumber(int number);
    bool HasBoardWon();
    int SumOfUnmarkedNumbers();
}