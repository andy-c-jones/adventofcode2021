using NUnit.Framework;
using sonar.DayTwo;

namespace sonar.tests.DayTwo;

public class SubmarineTests
{
    [Test]
    public void Should_start_at_0_0()
    {
        var submarine = new sonar.DayTwo.Submarine();
        Assert.Multiple(() =>
        {
            Assert.That(submarine.Position, Is.EqualTo(new Position(0, 0)));
            Assert.That(submarine.Aim, Is.EqualTo(0));
        });
    }

    [Test]
    public void Executing_down_should_increase_aim_by_value([Values(1, 123, 43266)] int value)
    {
        var submarine = new sonar.DayTwo.Submarine();
        submarine.Execute(new[] { new SubmarineCommand(CommandType.Down, value) });
        Assert.That(submarine.Aim, Is.EqualTo(value));
    }

    [TestCase(1, -1)]
    [TestCase(123, -123)]
    [TestCase(778, -778)]
    public void Executing_up_should_decrease_aim_by_value(int value, int expected)
    {
        var submarine = new sonar.DayTwo.Submarine(0, 1000, 0);
        submarine.Execute(new[] { new SubmarineCommand(CommandType.Up, value) });
        Assert.That(submarine.Aim, Is.EqualTo(expected));
    }

    [TestCase(1, 1, 1, 100, 101)]
    [TestCase(123, 1, 123, 0, 123)]
    [TestCase(43266, 1, 43266, 200, 43466)]
    [TestCase(1, 2, 1, 450, 452)]
    [TestCase(123, 3, 123, 100, 469)]
    [TestCase(43266, 4, 43266, 0, 173064)]
    public void
        Executing_forward_should_increase_horizontal_position_by_value_and_increase_depth_by_aim_multiplied_by_value
        (int value, int startingAim, int expectedHorizontal, int startingDepth, int expectedDepth)
    {
        var submarine = new sonar.DayTwo.Submarine(0, startingDepth, startingAim);
        submarine.Execute(new[] { new SubmarineCommand(CommandType.Forwards, value) });
        Assert.Multiple(() =>
        {
            Assert.That(submarine.Position.Horizontal, Is.EqualTo(expectedHorizontal));
            Assert.That(submarine.Position.Depth, Is.EqualTo(expectedDepth));
        });
    }
}