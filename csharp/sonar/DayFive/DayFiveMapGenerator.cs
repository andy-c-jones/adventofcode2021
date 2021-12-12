namespace sonar.DayFive;

public interface IDayFiveMapGenerator
{
    Node[,] CreateMap(IEnumerable<Line> lines);
}

public class DayFiveMapGenerator : IDayFiveMapGenerator
{
    public Node[,] CreateMap(IEnumerable<Line> lines) => Map.InitialiseFromLines(lines);
}