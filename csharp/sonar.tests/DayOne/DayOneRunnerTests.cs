using Moq;
using NUnit.Framework;
using sonar.DayOne;

namespace sonar.tests.DayOne;

public class RunnerTests
{
    [Test]
    public async Task When_sonar_should_read_file_from_input_path_calculate_increases_then_write_to_output(
        [Values("day1Input.txt", "a", "some other")]
        string filePath,
        [Values(new[] { 1, 2 }, new[] { 1, 2, 3 }, new int[] { })]
        int[] expectedReaderInput,
        [Values(1, 3, 5, 12334)]
        int expectedIncreaseCount)
    {
        var reader = new Mock<ISonarReader>();
        var calculator = new Mock<IDepthIncreaseCalculator>();
        var writer = new Mock<IOutputWriter>();

        reader
            .Setup(r => r.ReadSonarMeasurementsFromFile(filePath))
            .Returns(Task.FromResult(expectedReaderInput));

        calculator
            .Setup(c => c.CountIncreases(expectedReaderInput))
            .Returns(expectedIncreaseCount);

        var runner = new DayOneRunner(reader.Object, calculator.Object, writer.Object);

        await runner.Run(new[] { "sonar", filePath });

        writer.Verify(w => w.WriteLine(expectedIncreaseCount.ToString()));
    }
    
}