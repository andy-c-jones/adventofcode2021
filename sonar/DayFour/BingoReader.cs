using System.Text;

namespace sonar.DayFour;

public class BingoReader : IBingoReader
{
    public async Task<BingoGameData> ReadFrom(string filePath)
    {
        var lines = await File.ReadAllLinesAsync(filePath, Encoding.UTF8);
        var numbersToDraw = lines.First().Split(',').Select(int.Parse).ToArray();

        var boards = lines.Skip(1).ToArray();
        var numberOfBoardsInInput = boards.Length / 6;

        for (var i = 0; i < numberOfBoardsInInput; i++)
        {
            var boardNumber = i + 1;
            var lastLineOfBoard = 6 * boardNumber;
            var firstLineOfBoard = lastLineOfBoard - 4;
            var boardInputs = boards.Take(new Range(firstLineOfBoard, lastLineOfBoard));

            // new Board()
            var items = new GridItem[5, 5];
            foreach (var line in boardInputs)
            {
                var gridItems = line.Split(' ').Select(int.Parse).Select(n => new GridItem(n, false));
            }
        }

        return new BingoGameData(numbersToDraw, new[] {new Board(new GridItem[5, 5])});
    }
}

public interface IBingoReader
{
    Task<BingoGameData> ReadFrom(string filePath);
}

public record BingoGameData(IEnumerable<int> NumbersToDraw, IEnumerable<Board> Boards);

public record GridItem(int Number, bool Marked);