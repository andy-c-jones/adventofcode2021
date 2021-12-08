namespace sonar.DayFive;

public interface IDayFiveScoreCalculator
{
    int CountWhereThereAreXOrGreaterVents(int x, Node[,] map);
}

public class DayFiveScoreCalculator : IDayFiveScoreCalculator
{
    public int CountWhereThereAreXOrGreaterVents(int x, Node[,] map) => map.Flatten().Count(n => n.NumberOfVents >= x);
}

public static class ArrayExtensions
{
    public static IEnumerable<T> Flatten<T>(this T[,] array)
    {
        for (var i = 0; i < array.GetLength(0); i++)
        {
            for (var j = 0; j < array.GetLength(1); j++)
            {
                yield return array[i, j];
            }
        }
    }
}