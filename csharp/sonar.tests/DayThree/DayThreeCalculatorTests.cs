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

    [TestCase(new[] {"00001", "00001", "00001"}, 30)]
    [TestCase(new[] {"00001", "00001", "00001", "00001"}, 30)]
    [TestCase(new[] {"00000", "00000", "00001", "00001"}, 30)]
    [TestCase(new[] {"00000", "00000", "00001", "00001", "00001"}, 30)]
    [TestCase(new[] {"00000", "00001", "00001"}, 30)]
    [TestCase(new[] {"00001", "00001", "00000"}, 30)]
    [TestCase(new[] {"00010", "00000", "00000"}, 31)]
    [TestCase(new[] {"00010", "00010", "00000"}, 29)]
    [TestCase(new[] {"00010", "00010", "00010"}, 29)]
    [TestCase(new[] {"00100", "00100", "00010"}, 27)]
    [TestCase(new[] {"01100", "01100", "00010"}, 19)]
    [TestCase(new[] {"11100", "11100", "00010"}, 3)]
    public void
        Epsilon_rate_is_int_parsed_from_the_binary_found_from_identifying_all_the_least_common_bits_across_values(
            string[] inputs, int expectedGammaRate)
    {
        var calculator = new DayThreeCalculator();
        var gammaRate = calculator.CalculateEpsilonRate(inputs);
        Assert.That(gammaRate, Is.EqualTo(expectedGammaRate));
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

    [TestCase(new[] {"00001", "00001", "00001"}, 30)]
    [TestCase(new[] {"00010", "00010", "00010"}, 58)]
    [TestCase(new[] {"0001000010", "0001000010", "0001000010"}, 63162)]
    [TestCase(new[] {"000100010", "000100010", "000100010"}, 16218)]
    public void Power_consumption_should_be_gamma_rate_times_epsilon_rate(string[] inputs, int expectedPowerConsumption)
    {
        var calculator = new DayThreeCalculator();
        var gammaRate = calculator.CalculatePowerConsumption(inputs);
        Assert.That(gammaRate, Is.EqualTo(expectedPowerConsumption));
    }

    [TestCase(new[]
    {
        "00100",
        "11110",
        "10110",
        "10111",
        "10101",
        "01111",
        "00111",
        "11100",
        "10000",
        "11001",
        "00010",
        "01010"
    }, 23)]
    public void oxygen_generator_rating(
        string[] inputs, int expectedGammaRate)
    {
        var calculator = new DayThreeCalculator();
        var oxygenGeneratorRating = calculator.CalculateOxygenGeneratorRating(inputs);
        Assert.That(oxygenGeneratorRating, Is.EqualTo(expectedGammaRate));
    }
    
    [TestCase(new[]
    {
        "00100",
        "11110",
        "10110",
        "10111",
        "10101",
        "01111",
        "00111",
        "11100",
        "10000",
        "11001",
        "00010",
        "01010"
    }, 10)]
    public void co2_scrubber_rating(
        string[] inputs, int expectedRating)
    {
        var calculator = new DayThreeCalculator();
        var rating = calculator.CalculateCO2ScrubberRating(inputs);
        Assert.That(rating, Is.EqualTo(expectedRating));
    }    
    
    [TestCase(new[]
    {
        "00100",
        "11110",
        "10110",
        "10111",
        "10101",
        "01111",
        "00111",
        "11100",
        "10000",
        "11001",
        "00010",
        "01010"
    }, 230)]
    public void calculate_life_support_rate(
        string[] inputs, int expectedRating)
    {
        var calculator = new DayThreeCalculator();
        var rating = calculator.CalculateLifeSupportRate(inputs);
        Assert.That(rating, Is.EqualTo(expectedRating));
    }
}