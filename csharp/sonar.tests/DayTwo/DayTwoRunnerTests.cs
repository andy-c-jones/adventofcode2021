using Moq;
using NUnit.Framework;
using sonar.DayTwo;

namespace sonar.tests.DayTwo;

[TestFixture]
public class SubmarineRunnerTests
{
    [TestCase(1, 1, "1")]
    [TestCase(2, 1, "4")]
    [TestCase(2, 2, "8")]
    [TestCase(10, 1231, "123100")]
    public async Task When_movesub_should_read_file_from_input_path_calculate_increases_then_write_to_output(
        int forward, int down, string expectedOutput)
    {
        var writer = new Mock<IOutputWriter>();
        var reader = new Mock<ICommandReader>();
        const string someFilePath = "somePath";

        reader
            .Setup(r => r.ReadCommandsFromFile(someFilePath))
            .Returns(Task.FromResult(new[]
            {
                new SubmarineCommand(CommandType.Down, down),
                new SubmarineCommand(CommandType.Forwards, forward)
            }));

        var runner = new DayTwoRunner(reader.Object, writer.Object);

        await runner.Run(new[] { "movesub", someFilePath });

        writer.Verify(w => w.WriteLine(expectedOutput));
    }
}