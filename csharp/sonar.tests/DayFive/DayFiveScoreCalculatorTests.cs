using NUnit.Framework;
using sonar.DayFive;

namespace sonar.tests.DayFive;

public class DayFiveScoreCalculatorTests
{
    [Test]
    public void Should_could_the_number_of_points_where_vents_are_equal_or_greater_than_x()
    {
        var calculator = new DayFiveScoreCalculator();

        // 1 1 0
        // 3 3 2
        // 1 1 0
        var map = Map.InitialiseFromLines(new[]
        {
            new Line(new Point(0, 2), new Point(0, 0)),
            new Line(new Point(1, 0), new Point(1, 2)),
            new Line(new Point(2, 1), new Point(0, 1)),
            new Line(new Point(0, 1), new Point(2, 1))
        });

        Assert.Multiple(() =>
        {
            Assert.That(calculator.CountWhereThereAreXOrGreaterVents(0, map), Is.EqualTo(9));
            Assert.That(calculator.CountWhereThereAreXOrGreaterVents(1, map), Is.EqualTo(7));
            Assert.That(calculator.CountWhereThereAreXOrGreaterVents(2, map), Is.EqualTo(3));
            Assert.That(calculator.CountWhereThereAreXOrGreaterVents(3, map), Is.EqualTo(2));
            Assert.That(calculator.CountWhereThereAreXOrGreaterVents(4, map), Is.EqualTo(0));
        });
        
    }
}