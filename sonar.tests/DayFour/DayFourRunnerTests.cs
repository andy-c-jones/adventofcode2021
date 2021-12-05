using Moq;
using NUnit.Framework;
using sonar.DayFour;

namespace sonar.tests.DayFour;

public class DayFourRunnerTests
{
    [Test]
    public async Task Should_parse_input_and_pass_to_the_bingo_player_which_should_return_result_to_be_output()
    {
        var writer = new Mock<IOutputWriter>();
        var reader = new Mock<IBingoReader>();
        var bingoSubsystem = new Mock<IBingoSubsystem>();

        var gameData = new BingoGameData(Array.Empty<int>(), Array.Empty<Board>());
        const int expectedGameResult = 321;
        const int expectedLastBoardToWinGameResult = 4232;
        const string filePath = "someFilePath";

        reader.Setup(r => r.ReadFrom(filePath))
            .Returns(Task.FromResult(gameData));

        bingoSubsystem.Setup(b => b.DrawNumbersUntilThereIsAWinner(gameData))
            .Returns(expectedGameResult);
        
        bingoSubsystem.Setup(b => b.FindTheLastBoardToWin(gameData))
            .Returns(expectedLastBoardToWinGameResult);
        
        var runner = new DayFourRunner(reader.Object, bingoSubsystem.Object, writer.Object);
        await runner.Run(new[] {"day4", filePath });
        
        writer.Verify(w => w.WriteLine($"Part 1 Score: {expectedGameResult.ToString()}"));
        writer.Verify(w => w.WriteLine($"Part 2 Score: {expectedLastBoardToWinGameResult.ToString()}"));
    }
}