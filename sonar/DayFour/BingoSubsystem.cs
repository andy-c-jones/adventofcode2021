namespace sonar.DayFour;

public class BingoSubsystem : IBingoSubsystem
{
    public BingoSubsystem(IRoundExecutor roundExecutor)
    {
        
    }
    
    public int DrawNumbersUntilThereIsAWinner(BingoGameData data)
    {
        int lastNumber = 1;
        var score = 0 * lastNumber;
        return score;
    }
}

public interface IBingoSubsystem
{
    public int DrawNumbersUntilThereIsAWinner(BingoGameData data);
}