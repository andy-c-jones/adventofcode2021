namespace sonar.DayFive;

public interface IStraightLineFilter
{
    Line[] SelectStraightLines(IEnumerable<Line> expectedLines);
}

public class StraightLineFilter : IStraightLineFilter
{
    public Line[] SelectStraightLines(IEnumerable<Line> expectedLines) =>
        expectedLines.Where(l => l.Start.X == l.End.X || l.Start.Y == l.End.Y).ToArray();
}