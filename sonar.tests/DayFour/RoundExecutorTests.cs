using Moq;
using Moq.Sequences;
using NUnit.Framework;
using sonar.DayFour;

namespace sonar.tests.DayFour;

public class RoundExecutorTests
{
    [Test]
    public void Should_execute_round_and_check_but_find_no_winner([Values(1, 321, 543, 23)] int roundNumber)
    {
        var roundExecutor = new RoundExecutor();

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
            boardOne.Setup(one => one.MarkNumber(roundNumber)).InSequence();
            boardTwo.Setup(two => two.MarkNumber(roundNumber)).InSequence();
            boardThree.Setup(three => three.MarkNumber(roundNumber)).InSequence();
            boardOne.Setup(one => one.HasBoardWon()).InSequence().Returns(false);
            boardTwo.Setup(two => two.HasBoardWon()).InSequence().Returns(false);
            boardThree.Setup(three => three.HasBoardWon()).InSequence().Returns(false);

            var (winner, _) = roundExecutor.Execute(roundNumber, boards);
            Assert.That(winner, Is.False);
        }
    }

    [Test]
    public void When_a_board_wins_the_winner_is_returned()
    {
        var roundExecutor = new RoundExecutor();

        var boardOne = new Mock<IBoard>();
        var boardTwo = new Mock<IBoard>();
        var boardThree = new Mock<IBoard>();
        var boards = new[]
        {
            boardOne.Object,
            boardTwo.Object,
            boardThree.Object
        };

        boardOne.Setup(one => one.HasBoardWon()).Returns(false);
        boardTwo.Setup(two => two.HasBoardWon()).Returns(false);
        boardThree.Setup(three => three.HasBoardWon()).Returns(true);

        const int roundNumber = 1;
        var (winner, winningBoard) = roundExecutor.Execute(roundNumber, boards);
        Assert.Multiple(() =>
        {
            Assert.That(winner, Is.True);
            Assert.That(winningBoard, Is.EqualTo(boardThree.Object));    
        });
    }
    
    [Test]
    public void When_many_boards_are_winning_the_first_winner_is_returned()
    {
        var roundExecutor = new RoundExecutor();

        var boardOne = new Mock<IBoard>();
        var boardTwo = new Mock<IBoard>();
        var boardThree = new Mock<IBoard>();
        var boards = new[]
        {
            boardOne.Object,
            boardTwo.Object,
            boardThree.Object
        };

        boardOne.Setup(one => one.HasBoardWon()).Returns(false);
        boardTwo.Setup(two => two.HasBoardWon()).Returns(true);
        boardThree.Setup(three => three.HasBoardWon()).Returns(true);

        const int roundNumber = 1;
        var (winner, winningBoard) = roundExecutor.Execute(roundNumber, boards);
        Assert.Multiple(() =>
        {
            Assert.That(winner, Is.True);
            Assert.That(winningBoard, Is.EqualTo(boardTwo.Object));    
        });
    }
    
    [Test]
    public void When_all_boards_are_winning_the_first_winner_is_returned()
    {
        var roundExecutor = new RoundExecutor();

        var boardOne = new Mock<IBoard>();
        var boardTwo = new Mock<IBoard>();
        var boardThree = new Mock<IBoard>();
        var boards = new[]
        {
            boardOne.Object,
            boardTwo.Object,
            boardThree.Object
        };

        boardOne.Setup(one => one.HasBoardWon()).Returns(true);
        boardTwo.Setup(two => two.HasBoardWon()).Returns(true);
        boardThree.Setup(three => three.HasBoardWon()).Returns(true);

        const int roundNumber = 1;
        var (winner, winningBoard) = roundExecutor.Execute(roundNumber, boards);
        Assert.Multiple(() =>
        {
            Assert.That(winner, Is.True);
            Assert.That(winningBoard, Is.EqualTo(boardOne.Object));    
        });
    }
}