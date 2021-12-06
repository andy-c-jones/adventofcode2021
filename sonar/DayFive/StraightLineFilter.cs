namespace sonar.DayFive;

public interface IStraightLineFilter
{
    Line[] SelectStraightLines(Line[] expectedLines);
}