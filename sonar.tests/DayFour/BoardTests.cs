using NUnit.Framework;
using sonar.DayFour;

namespace sonar.tests.DayFour;

public class BoardTests
{
    [Test]
    public void When_marking_numbers_and_number_not_present()
    {
        var board = new Board(new[,]
        {
            {Item(1), Item(43)},
            {Item(231), Item(10)}
        });

        board.MarkNumber(12);

        Assert.Multiple(() =>
        {
            Assert.That(board.Grid[0, 0].Marked, Is.EqualTo(false));
            Assert.That(board.Grid[0, 1].Marked, Is.EqualTo(false));
            Assert.That(board.Grid[1, 0].Marked, Is.EqualTo(false));
            Assert.That(board.Grid[1, 1].Marked, Is.EqualTo(false));
        });
    }

    [Test]
    public void When_marking_numbers_and_number_is_present()
    {
        var board = new Board(new[,]
        {
            {Item(1), Item(43)},
            {Item(43), Item(10)}
        });

        board.MarkNumber(43);

        Assert.Multiple(() =>
        {
            Assert.That(board.Grid[0, 0].Marked, Is.EqualTo(false));
            Assert.That(board.Grid[0, 1].Marked, Is.EqualTo(true));
            Assert.That(board.Grid[1, 0].Marked, Is.EqualTo(true));
            Assert.That(board.Grid[1, 1].Marked, Is.EqualTo(false));
        });
    }

    public IEnumerable<Board> RowWinningBoards()
    {
        yield return new Board(new[,]
        {
            {Item(1), Item(43)},
            {MarkedItem(43), MarkedItem(10)}
        });
        yield return new Board(new[,]
        {
            {MarkedItem(1), MarkedItem(43)},
            {Item(43), Item(10)}
        });
        yield return new Board(new[,]
        {
            {Item(1), MarkedItem(43), Item(1)},
            {MarkedItem(43), MarkedItem(10), MarkedItem(21)},
            {MarkedItem(43), Item(10), MarkedItem(21)},
        });
    }

    [TestCaseSource(nameof(RowWinningBoards))]
    public void When_checking_if_board_has_won_and_a_row_is_all_marked(Board board) => 
        Assert.That(board.HasBoardWon, Is.True);

    public IEnumerable<Board> ColumnWinningBoards()
    {
        yield return new Board(new[,]
        {
            {MarkedItem(1), Item(43)},
            {MarkedItem(43), Item(10)}
        });
        yield return new Board(new[,]
        {
            {Item(1), MarkedItem(43)},
            {Item(43), MarkedItem(10)}
        });
        yield return new Board(new[,]
        {
            {Item(1), MarkedItem(43)},
            {Item(43), MarkedItem(10)},
            {Item(43), MarkedItem(10)},
            {Item(43), MarkedItem(10)},
            {Item(43), MarkedItem(10)},
        });
        yield return new Board(new[,]
        {
            {Item(1), MarkedItem(43), Item(1)},
            {Item(43), MarkedItem(10), Item(1)},
            {Item(43), MarkedItem(10), Item(1)},
            {Item(43), MarkedItem(10), Item(1)},
            {Item(43), MarkedItem(10), Item(1)},
        });
    }

    [TestCaseSource(nameof(ColumnWinningBoards))]
    public void When_checking_if_board_has_won_and_a_column_is_all_marked(Board board) => 
        Assert.That(board.HasBoardWon, Is.True);

    private static GridItem Item(int number) => new(number, false);
    private static GridItem MarkedItem(int number) => new(number, true);
}