using NUnit.Framework;
using sonar.DayFive;

namespace sonar.tests.DayFive;

public class DayFiveReaderTests
{
    [Test]
    public async Task Should_parse_lines_from_file()
    {
        var reader = new DayFiveReader();
        var lines = await reader.ReadLinesFrom("./DayFive/InputExample.txt");

        CollectionAssert.AreEquivalent(new[]
        {
            new Line(new Point(0, 9), new Point(5, 9)),
            new Line(new Point(8, 0), new Point(0, 8)),
            new Line(new Point(9, 4), new Point(3, 4)),
            new Line(new Point(2, 2), new Point(2, 1)),
            new Line(new Point(7, 0), new Point(7, 4)),
            new Line(new Point(6, 4), new Point(2, 0)),
            new Line(new Point(0, 9), new Point(2, 9)),
            new Line(new Point(3, 4), new Point(1, 4)),
            new Line(new Point(0, 0), new Point(8, 8)),
            new Line(new Point(5, 5), new Point(8, 2))
            
        }, lines);
    }
}