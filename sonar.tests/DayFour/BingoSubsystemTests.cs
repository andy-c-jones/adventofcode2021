using Moq;
using Moq.Sequences;
using NUnit.Framework;
using NUnit.Framework.Constraints;
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


    [TestCase(23, 35, 805)]
    [TestCase(123, 65, 7995)]
    [TestCase(10, 4, 40)]
    [TestCase(1, 45, 45)]
    public void Score_should_be_the_winning_number_times_by_the_sum_of_unmarked_numbers_of_the_last_board_to_win
        (int lastWinningNumber, int sumOfUnmarkedNumbers, int expectedScore)
    {
        var roundExecutor = new Mock<IRoundExecutor>(MockBehavior.Strict);
        var bingoSubsystem = new BingoSubsystem(roundExecutor.Object);

        var boardOne = new Mock<IBoard>(MockBehavior.Strict);
        var boardTwo = new Mock<IBoard>(MockBehavior.Strict);
        var boardThree = new Mock<IBoard>(MockBehavior.Strict);
        var boards = new[]
        {
            boardOne.Object,
            boardTwo.Object,
            boardThree.Object
        };

        using (Sequence.Create())
        {
            // && It.IsAny<IBoard[]>().Contains(boardTwo)
            roundExecutor.Setup(e => e.ExecutePartTwo(4, It.Is<List<IBoard>>(
                    l => l.Contains(boardOne.Object) && l.Contains(boardTwo.Object) && l.Contains(boardThree.Object)
                ))).InSequence()
                .Returns((true, new List<IBoard> {boardTwo.Object}));
            roundExecutor.Setup(e => e.ExecutePartTwo(2, It.Is<List<IBoard>>(
                    l => l.Contains(boardOne.Object) && l.Contains(boardThree.Object)
                ))).InSequence()
                .Returns((false, new List<IBoard>()));
            roundExecutor.Setup(e => e.ExecutePartTwo(3, It.Is<List<IBoard>>(
                    l => l.Contains(boardOne.Object) && l.Contains(boardThree.Object)
                ))).InSequence()
                .Returns((true, new List<IBoard> {boardThree.Object}));
            roundExecutor.Setup(e => e.ExecutePartTwo(lastWinningNumber, It.Is<List<IBoard>>(
                    l => l.Contains(boardOne.Object)
                ))).InSequence()
                .Returns((true, new List<IBoard> {boardOne.Object}));

            boardOne.Setup(b => b.SumOfUnmarkedNumbers()).Returns(sumOfUnmarkedNumbers);

            var score = bingoSubsystem.FindTheLastBoardToWin(
                new BingoGameData(new[] {4, 2, 3, lastWinningNumber, 42123},
                    boards));

            Assert.That(score, Is.EqualTo(expectedScore));
        }
    }

    [TestCase(23, 35, 805)]
    [TestCase(123, 65, 7995)]
    [TestCase(10, 4, 40)]
    [TestCase(1, 45, 45)]
    public void
        Score_should_be_the_winning_number_times_by_the_sum_of_unmarked_numbers_of_the_last_board_to_win_even_when_some_boards_never_win
        (int lastWinningNumber, int sumOfUnmarkedNumbers, int expectedScore)
    {
        var roundExecutor = new Mock<IRoundExecutor>(MockBehavior.Strict);
        var bingoSubsystem = new BingoSubsystem(roundExecutor.Object);

        var boardOne = new Mock<IBoard>(MockBehavior.Strict);
        var boardTwo = new Mock<IBoard>(MockBehavior.Strict);
        var boardThree = new Mock<IBoard>(MockBehavior.Strict);
        var boardFour = new Mock<IBoard>(MockBehavior.Strict);
        var boards = new[]
        {
            boardOne.Object,
            boardTwo.Object,
            boardThree.Object,
            boardFour.Object
        };

        using (Sequence.Create())
        {
            roundExecutor.Setup(e => e.ExecutePartTwo(4, It.Is<List<IBoard>>(
                    l => l.Contains(boardOne.Object) && l.Contains(boardTwo.Object) && l.Contains(boardThree.Object) &&
                         l.Contains(boardFour.Object)
                ))).InSequence()
                .Returns((true, new List<IBoard> {boardTwo.Object}));
            roundExecutor.Setup(e => e.ExecutePartTwo(2, It.Is<List<IBoard>>(
                    l => l.Contains(boardOne.Object) && l.Contains(boardThree.Object) && l.Contains(boardFour.Object)
                ))).InSequence()
                .Returns((false, new List<IBoard>()));
            roundExecutor.Setup(e => e.ExecutePartTwo(3, It.Is<List<IBoard>>(
                    l => l.Contains(boardOne.Object) && l.Contains(boardThree.Object) && l.Contains(boardFour.Object)
                ))).InSequence()
                .Returns((true, new List<IBoard> {boardThree.Object}));
            roundExecutor.Setup(e => e.ExecutePartTwo(lastWinningNumber, It.Is<List<IBoard>>(
                    l => l.Contains(boardOne.Object) && l.Contains(boardFour.Object)
                ))).InSequence()
                .Returns((true, new List<IBoard> {boardOne.Object}));

            boardOne.Setup(b => b.SumOfUnmarkedNumbers()).Returns(sumOfUnmarkedNumbers);

            var score = bingoSubsystem.FindTheLastBoardToWin(
                new BingoGameData(new[] {4, 2, 3, lastWinningNumber},
                    boards));

            Assert.That(score, Is.EqualTo(expectedScore));
        }
    }
    
     [TestCase(23, 35, 805)]
    [TestCase(123, 65, 7995)]
    [TestCase(10, 4, 40)]
    [TestCase(1, 45, 45)]
    public void
        Score_should_be_the_winning_number_times_by_the_sum_of_unmarked_numbers_of_the_last_board_to_win_even_when_some_boards_win_at_the_same_time
        (int lastWinningNumber, int sumOfUnmarkedNumbers, int expectedScore)
    {
        var roundExecutor = new Mock<IRoundExecutor>(MockBehavior.Strict);
        var bingoSubsystem = new BingoSubsystem(roundExecutor.Object);

        var boardOne = new Mock<IBoard>(MockBehavior.Strict);
        var boardTwo = new Mock<IBoard>(MockBehavior.Strict);
        var boardThree = new Mock<IBoard>(MockBehavior.Strict);
        var boardFour = new Mock<IBoard>(MockBehavior.Strict);
        var boards = new[]
        {
            boardOne.Object,
            boardTwo.Object,
            boardThree.Object,
            boardFour.Object
        };

        using (Sequence.Create())
        {
            roundExecutor.Setup(e => e.ExecutePartTwo(4, It.Is<List<IBoard>>(
                    l => l.Contains(boardOne.Object) && l.Contains(boardTwo.Object) && l.Contains(boardThree.Object) &&
                         l.Contains(boardFour.Object)
                ))).InSequence()
                .Returns((true, new List<IBoard> {boardTwo.Object, boardThree.Object}));
            roundExecutor.Setup(e => e.ExecutePartTwo(2, It.Is<List<IBoard>>(
                    l => l.Contains(boardOne.Object) && l.Contains(boardFour.Object)
                ))).InSequence()
                .Returns((false, new List<IBoard>()));
            roundExecutor.Setup(e => e.ExecutePartTwo(3, It.Is<List<IBoard>>(
                    l => l.Contains(boardOne.Object) && l.Contains(boardFour.Object)
                ))).InSequence()
                .Returns((false, new List<IBoard>()));
            roundExecutor.Setup(e => e.ExecutePartTwo(lastWinningNumber, It.Is<List<IBoard>>(
                    l => l.Contains(boardOne.Object) && l.Contains(boardFour.Object)
                ))).InSequence()
                .Returns((true, new List<IBoard> {boardOne.Object}));

            boardOne.Setup(b => b.SumOfUnmarkedNumbers()).Returns(sumOfUnmarkedNumbers);

            var score = bingoSubsystem.FindTheLastBoardToWin(
                new BingoGameData(new[] {4, 2, 3, lastWinningNumber},
                    boards));

            Assert.That(score, Is.EqualTo(expectedScore));
        }
    }
}