using Moq;
using NUnit.Framework;
using sonar.DayFive;

namespace sonar.tests.DayFive;

public class DayFiveRunnerTests
{
    [Test]
    public void Should_create_map_score_then_output_results([Values(1, 432, 46)] int expectedPartOneScore)
    {
        var reader = new Mock<IDayFiveReader>();
        var filter = new Mock<IStraightLineFilter>();
        var mapGen = new Mock<IDayFiveMapGenerator>();
        var scoreCalculator = new Mock<IDayFiveScoreCalculator>();
        var writer = new Mock<IOutputWriter>();
        const string filePath = "someFilePath";


        var expectedLines = new[]
        {
            new Line(new Point(0, 0), new Point(0, 1)),
            new Line(new Point(1, 0), new Point(0, 0)),
            new Line(new Point(0, 0), new Point(1, 1))
        };

        var expectedStraightLines = new[]
        {
            new Line(new Point(0, 0), new Point(0, 1)),
            new Line(new Point(1, 0), new Point(0, 0))
        };

        reader.Setup(r => r.ReadLinesFrom(filePath))
            .Returns(Task.FromResult(expectedLines));

        filter.Setup(f => f.SelectStraightLines(expectedLines)).Returns(expectedStraightLines);

        var map = new Map();
        mapGen.Setup(g => g.CreateMap(expectedStraightLines)).Returns(map);

        scoreCalculator.Setup(c => c.CountWhereThereAreXVents(2, map)).Returns(expectedPartOneScore);

        var runner = new DayFiveRunner(reader.Object, filter.Object, mapGen.Object, scoreCalculator.Object,
            writer.Object);
        runner.Run(new[] {"day5", filePath});

        writer.Verify(w => w.WriteLine($"Part One: {expectedPartOneScore.ToString()}"));
    }
}