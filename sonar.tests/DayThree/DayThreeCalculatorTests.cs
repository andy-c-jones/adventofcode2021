using NUnit.Framework;
using sonar.DayThree;

namespace sonar.tests.DayThree;

public class DayThreeCalculatorTests
{
    [Test]
    public void Should_handle_empty_input()
    {
        var calculator = new DayThreeCalculator();

        var powerConsumption = calculator.CalculatePowerConsumption(Array.Empty<string>());

        Assert.That(powerConsumption, Is.EqualTo(0));
    }

    [TestCase(new[] {"00001", "00001", "00001"}, 1)]
    [TestCase(new[] {"00001", "00001", "00001", "00001"}, 1)]
    [TestCase(new[] {"00000", "00000", "00001", "00001"}, 0)]
    [TestCase(new[] {"00000", "00000", "00001", "00001", "00001"}, 1)]
    [TestCase(new[] {"00000", "00001", "00001"}, 1)]
    [TestCase(new[] {"00001", "00001", "00000"}, 1)]
    [TestCase(new[] {"00010", "00000", "00000"}, 0)]
    [TestCase(new[] {"00010", "00010", "00000"}, 2)]
    [TestCase(new[] {"00010", "00010", "00010"}, 2)]
    [TestCase(new[] {"00100", "00100", "00010"}, 4)]
    [TestCase(new[] {"01100", "01100", "00010"}, 12)]
    [TestCase(new[] {"11100", "11100", "00010"}, 28)]
    public void Gamma_rate_is_int_parsed_from_the_binary_found_from_identifying_all_the_common_bits_across_values(
        string[] inputs, int expectedGammaRate)
    {
        var calculator = new DayThreeCalculator();
        var gammaRate = calculator.CalculateGammaRate(inputs);
        Assert.That(gammaRate, Is.EqualTo(expectedGammaRate));
    }
}