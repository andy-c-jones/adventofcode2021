using Moq;
using NUnit.Framework;
using sonar.Submarine;

namespace sonar.tests;

[TestFixture]
public class SubmarineRunnerTests
{
    [TestCase(1, 1, "1")]
    [TestCase(2, 1, "2")]
    [TestCase(2, 2, "4")]
    [TestCase(10, 1231, "12310")]
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
                new SubmarineCommand(CommandType.Forwards, forward),
                new SubmarineCommand(CommandType.Down, down)
            }));

        var runner = new SubmarineRunner(reader.Object, writer.Object);

        await runner.Run(new[] { "movesub", someFilePath });

        writer.Verify(w => w.WriteLine(expectedOutput));
    }
}