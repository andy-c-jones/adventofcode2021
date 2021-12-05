namespace sonar.DayFour;

public class BingoReader : IBingoReader
{
    public Task<BingoGameData> ReadFrom(string filePath)
    {
        throw new NotImplementedException();
    }
}

public interface IBingoReader
{
    Task<BingoGameData> ReadFrom(string filePath);
}

public record BingoGameData(IEnumerable<int> NumbersToDraw, IEnumerable<Board> Boards);

public record GridItem(int Number, bool Marked);