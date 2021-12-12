using System.Collections.Immutable;
using System.Collections.ObjectModel;
using Moq;
using NUnit.Framework;
using sonar.DayFive;

namespace sonar.tests.DayFive;

public class DayFiveRunnerTests
{
    [Test]
    public async Task Should_create_map_score_then_output_results()
    {
        var reader = new Mock<IDayFiveReader>(MockBehavior.Strict);
        var filter = new Mock<IStraightLineFilter>(MockBehavior.Strict);
        var mapGen = new Mock<IDayFiveMapGenerator>(MockBehavior.Strict);
        var scoreCalculator = new Mock<IDayFiveScoreCalculator>(MockBehavior.Strict);
        var writer = new Mock<IOutputWriter>(MockBehavior.Strict);
        const string filePath = "someFilePath";
        const int expectedPartOneScore = 1;
        const int expectedPartTwoScore = 2;

        var expectedLines = ImmutableArray.Create(new Line(new Point(0, 0), new Point(0, 1)),
            new Line(new Point(1, 0), new Point(0, 0)),
            new Line(new Point(0, 0), new Point(1, 1)));

        var expectedStraightLines = new[]
        {
            new Line(new Point(0, 0), new Point(0, 1)),
            new Line(new Point(1, 0), new Point(0, 0))
        };

        reader.Setup(r => r.ReadLinesFrom(filePath))
            .Returns(Task.FromResult(expectedLines));

        filter.Setup(f => f.SelectStraightLines(expectedLines)).Returns(expectedStraightLines);

        var map = new Node[0, 0];
        mapGen.Setup(g => g.CreateMap(expectedStraightLines)).Returns(map);

        scoreCalculator.Setup(c => c.CountWhereThereAreXOrGreaterVents(2, map)).Returns(expectedPartOneScore);

        writer.Setup(w => w.WriteLine($"Part One: {expectedPartOneScore.ToString()}"));

        var mapTwo = new Node[1, 1];
        mapGen.Setup(g => g.CreateMap(expectedLines)).Returns(mapTwo);

        scoreCalculator.Setup(c => c.CountWhereThereAreXOrGreaterVents(2, mapTwo)).Returns(expectedPartTwoScore);

        writer.Setup(w => w.WriteLine($"Part Two: {expectedPartTwoScore.ToString()}"));

        var runner = new DayFiveRunner(reader.Object, filter.Object, mapGen.Object, scoreCalculator.Object,
            writer.Object);
        await runner.Run(new[] {"day5", filePath});
    }
}