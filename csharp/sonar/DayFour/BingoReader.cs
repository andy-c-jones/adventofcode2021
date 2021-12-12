using System.Text;
using System.Text.RegularExpressions;

namespace sonar.DayFour;

public class BingoReader : IBingoReader
{
    public async Task<BingoGameData> ReadFrom(string filePath)
    {
        var lines = await File.ReadAllLinesAsync(filePath, Encoding.UTF8);
        var numbersToDraw = lines.First().Split(',').Select(int.Parse).ToArray();

        var boards = lines.Skip(1).ToArray();
        var numberOfBoardsInInput = boards.Length / 6;

        var gameBoards = new List<Board>();
        for (var i = 0; i < numberOfBoardsInInput; i++)
        {
            var boardNumber = i + 1;
            var lastLineOfBoard = 6 * boardNumber;
            var firstLineOfBoard = lastLineOfBoard - 5;
            var boardInputs = boards.Take(new Range(firstLineOfBoard, lastLineOfBoard)).ToArray();

            var items = new GridItem[5, 5];
            for (var lineNumber = 0; lineNumber < boardInputs.Length; lineNumber++)
            {
                var line = boardInputs[lineNumber];
                var gridItems = Regex.Split(line, @"\s+")
                    .Where(s => s != string.Empty)
                    .Select(int.Parse)
                    .Select(n => new GridItem(n, false)).ToArray();

                for (var itemNumber = 0; itemNumber < gridItems.Length; itemNumber++)
                {
                    items[lineNumber, itemNumber] = gridItems[itemNumber];
                }
            }

            gameBoards.Add(new Board(items));
        }

        return new BingoGameData(numbersToDraw, gameBoards);
    }
}

public interface IBingoReader
{
    Task<BingoGameData> ReadFrom(string filePath);
}

public record BingoGameData(IEnumerable<int> NumbersToDraw, IEnumerable<IBoard> Boards);

public class GridItem
{
    protected bool Equals(GridItem other)
    {
        return Number == other.Number && Marked == other.Marked;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((GridItem) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Number, Marked);
    }

    public int Number { get; }
    public bool Marked { get; set; }

    public GridItem(int number, bool marked)
    {
        Number = number;
        Marked = marked;
    }
};