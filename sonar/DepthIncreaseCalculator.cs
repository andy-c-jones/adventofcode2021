namespace sonar;

public class DepthIncreaseCalculator : IDepthIncreaseCalculator
{
    public int CountIncreases(int[] measurements)
    {
        var counter = 0;
        for (var i = 1; i < measurements.Length; i++)
        {
            var previousMeasurement = measurements[i - 1];
            var measurement = measurements[i];
            if (measurement > previousMeasurement)
            {
                counter++;
            }
        }
        return counter;
    }
}

public interface IDepthIncreaseCalculator
{
    int CountIncreases(int[] measurements);
}