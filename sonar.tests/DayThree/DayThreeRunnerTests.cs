using Moq;
using NUnit.Framework;
using sonar.DayThree;

namespace sonar.tests.DayThree;

public class DayThreeRunnerTests
{
    [Test]
    public void Should_parse_input_calculate_power_consumption_and_output_result()
    {
        var reader = new Mock<IDayThreeReader>();
        var calculator = new Mock<IDayThreeCalculator>();
        var writer = new Mock<IOutputWriter>();

        var dayThreeRunner = new DayThreeRunner(reader.Object, writer.Object, calculator.Object);
        const string filePath = "somefilepath";
        var strings = new[] {"01101"};
        const int expectedOutput = 123;
        
        reader.Setup(r => r.Read(filePath)).Returns(Task.FromResult(strings));
        calculator.Setup(c => c.CalculatePowerConsumption(strings)).Returns(expectedOutput);

        dayThreeRunner.Run(new[] {"day3", filePath});

        writer.Verify(w => w.WriteLine(expectedOutput.ToString()));
    }
}