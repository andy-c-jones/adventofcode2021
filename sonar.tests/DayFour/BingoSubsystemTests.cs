using Moq;
using Moq.Sequences;
using NUnit.Framework;
using sonar.DayFour;

namespace sonar.tests.DayFour;

public class BingoSubsystemTests
{
    [TestCase(23, 35, 805)]
    [TestCase(123, 65, 7995)]
    [TestCase(10, 4, 40)]
    [TestCase(1, 45, 45)]
    public void Score_should_be_the_winning_number_times_by_the_sum_of_unmarked_numbers_on_the_winning_board
        (int winningNumber, int sumOfUnmarkedNumbers, int expectedScore)
    {
        var roundExecutor = new Mock<IRoundExecutor>(MockBehavior.Strict);
        var bingoSubsystem = new BingoSubsystem(roundExecutor.Object);

        var boardOne = new Mock<IBoard>(MockBehavior.Strict);
        var boards = new[]
        {
            boardOne.Object,
            new Mock<IBoard>(MockBehavior.Strict).Object,
            new Mock<IBoard>(MockBehavior.Strict).Object
        };

        using (Sequence.Create())
        {
            roundExecutor.Setup(e => e.Execute(4, boards)).InSequence()
                .Returns((false, null));
            roundExecutor.Setup(e => e.Execute(2, boards)).InSequence()
                .Returns((false, null));
            roundExecutor.Setup(e => e.Execute(3, boards)).InSequence()
                .Returns((false, null));
            roundExecutor.Setup(e => e.Execute(winningNumber, boards)).InSequence()
                .Returns((true, boardOne.Object));

            boardOne.Setup(b => b.SumOfUnmarkedNumbers()).Returns(sumOfUnmarkedNumbers);
            
            var score = bingoSubsystem.DrawNumbersUntilThereIsAWinner(
                new BingoGameData(new[] {4, 2, 3, winningNumber},
                    boards));
            
            Assert.That(score, Is.EqualTo(expectedScore));
        }
    }
}