using NUnit.Framework;
using sonar.DayFour;

namespace sonar.tests.DayFour;

public class BingoReaderTests
{
    [Test]
    public async Task Should_parse_input_from_file()
    {
        var bingoReader = new BingoReader();

        var gameData = await bingoReader.ReadFrom("./DayFour/InputExample.txt");

        Assert.Multiple(() =>
        {
            CollectionAssert.AreEquivalent(
                new[]
                {
                    7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1
                },
                gameData.NumbersToDraw);

            var boards = gameData.Boards.ToArray();

            var expectedBoardOne = new Board(new[,]
            {
                {Item(22), Item(13), Item(17), Item(11), Item(0)},
                {Item(8), Item(2), Item(23), Item(4), Item(24)},
                {Item(21), Item(9), Item(14), Item(16), Item(7)},
                {Item(6), Item(10), Item(3), Item(18), Item(5)},
                {Item(1), Item(12), Item(20), Item(15), Item(19)},
            });
            var expectedBoardTwo = new Board(new[,]
            {
                {Item(3), Item(15), Item(0), Item(2), Item(22)},
                {Item(9), Item(18), Item(13), Item(17), Item(5)},
                {Item(19), Item(8), Item(7), Item(25), Item(23)},
                {Item(20), Item(11), Item(10), Item(24), Item(4)},
                {Item(14), Item(21), Item(16), Item(12), Item(6)},
            });
            var expectedBoardThree = new Board(new[,]
            {
                {Item(14), Item(21), Item(17), Item(24), Item(4)},
                {Item(10), Item(16), Item(15), Item(9), Item(19)},
                {Item(18), Item(8), Item(23), Item(26), Item(20)},
                {Item(22), Item(11), Item(13), Item(6), Item(5)},
                {Item(2), Item(0), Item(12), Item(3), Item(7)},
            });
            AssertBoard(0, boards, expectedBoardOne);
            AssertBoard(1, boards, expectedBoardTwo);
            AssertBoard(2, boards, expectedBoardThree);
        });
    }

    private static void AssertBoard(int boardNumber, Board[] boards, Board board)
    {
        AssertRow(0,boardNumber, boards, board);
        AssertRow(1,boardNumber, boards, board);
        AssertRow(2,boardNumber, boards, board);
        AssertRow(3,boardNumber, boards, board);
        AssertRow(4,boardNumber, boards, board);
    }

    private static void AssertRow(int rowNumber, int i, Board[] boards, Board board)
    {
        Assert.That(boards[i].Grid[rowNumber, 0], Is.EqualTo(board.Grid[rowNumber, 0]));
        Assert.That(boards[i].Grid[rowNumber, 1], Is.EqualTo(board.Grid[rowNumber, 1]));
        Assert.That(boards[i].Grid[rowNumber, 2], Is.EqualTo(board.Grid[rowNumber, 2]));
        Assert.That(boards[i].Grid[rowNumber, 3], Is.EqualTo(board.Grid[rowNumber, 3]));
        Assert.That(boards[i].Grid[rowNumber, 4], Is.EqualTo(board.Grid[rowNumber, 4]));
    }

    GridItem Item(int number) => new(number, false);
}