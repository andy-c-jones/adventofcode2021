using NUnit.Framework;
using sonar.Sonar;

namespace sonar.tests.Sonar;

public class DepthIncreaseCalculatorTests
{
    private static IEnumerable<(int[] measurements, int increases)> TestData()
    {
        yield return (new[] { 1, 2 }, 0);
        yield return (new[] { 1, 2, 3 }, 0);
        yield return (new[] { 1, 0, 2, 0, 2 }, 1);
        yield return (new[] { 3, 2, 1 }, 0);
        yield return (new[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }, 5);
        yield return (new[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263, 1000 }, 6);
    }

    [TestCaseSource(nameof(TestData))]
    public void Should_count_number_of_increases_from_previous_measurement(
        (int[] measurements, int expectedIncreases) data)
    {
        var (measurements, expectedIncreases) = data;

        var calculator = new DepthIncreaseCalculator();
        var increases = calculator.CountIncreases(measurements);
        Assert.That(increases, Is.EqualTo(expectedIncreases));
    }
}