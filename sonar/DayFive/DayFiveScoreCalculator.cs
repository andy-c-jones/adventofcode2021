namespace sonar.DayFive;

public interface IDayFiveScoreCalculator
{
    int CountWhereThereAreXVents(int x, Node[,] map);
}

public class DayFiveScoreCalculator : IDayFiveScoreCalculator
{
    public int CountWhereThereAreXVents(int x, Node[,] map)
    {
        var nodes = new List<Node>();
        for (var i = 0; i < map.GetLength(0); i++)
        {
            for (var j = 0; j < map.GetLength(1); j++)
            {
                nodes.Add(map[i, j]);
            }
        }

        return nodes.Count(n => n.NumberOfVents == x);
    }
}