using NUnit.Framework;
using sonar.DayFive;

namespace sonar.tests.DayFive;

public class StraightLineFilterTests
{
    [Test]
    public void Should_remove_any_lines_that_are_not_straight()
    {
        var straightLineFilter = new StraightLineFilter();
        var lines = new[]
        {
            new Line(new Point(0, 1), new Point(0, 2)),
            new Line(new Point(2, 9), new Point(2, 2)),
            new Line(new Point(7, 3), new Point(1, 3)),
            new Line(new Point(1, 1), new Point(0, 2)),
            new Line(new Point(12, 435), new Point(324, 55)),
            new Line(new Point(1, 1), new Point(0, 2)),
        };
        var actualLines = straightLineFilter.SelectStraightLines(lines);
        var expectedLines = new[]
        {
            new Line(new Point(0, 1), new Point(0, 2)),
            new Line(new Point(2, 9), new Point(2, 2)),
            new Line(new Point(7, 3), new Point(1, 3)),
        };
        
        CollectionAssert.AreEquivalent(expectedLines, actualLines);
    }
}