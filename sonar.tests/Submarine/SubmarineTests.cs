using NUnit.Framework;
using sonar.Submarine;

namespace sonar.tests;

public class SubmarineTests
{
    [Test]
    public void Should_start_at_0_0()
    {
        var submarine = new Submarine.Submarine();
        Assert.That(submarine.Position, Is.EqualTo(new Position(0, 0)));
    }

    [Test]
    public void Executing_down_should_increase_depth_by_value([Values(1, 123, 43266)] int value)
    {
        var submarine = new Submarine.Submarine();
        submarine.Execute(new[] { new SubmarineCommand(CommandType.Down, value) });
        Assert.That(submarine.Position.Depth, Is.EqualTo(value));
    }
    
    [TestCase(1, 999)]
    [TestCase(123, 877)]
    [TestCase(778, 222)]
    public void Executing_down_should_decrease_depth_by_value(int value, int expected)
    {
        var submarine = new Submarine.Submarine(0, 1000);
        submarine.Execute(new[] { new SubmarineCommand(CommandType.Up, value) });
        Assert.That(submarine.Position.Depth, Is.EqualTo(expected));
    }
    
    [Test]
    public void Executing_forward_should_increase_horizontal_position_by_value([Values(1, 123, 43266)] int value)
    {
        var submarine = new Submarine.Submarine();
        submarine.Execute(new[] { new SubmarineCommand(CommandType.Forwards, value) });
        Assert.That(submarine.Position.Horizontal, Is.EqualTo(value));
    }
}