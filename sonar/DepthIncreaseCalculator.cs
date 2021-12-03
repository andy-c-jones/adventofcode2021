using System;
using System.Linq;

namespace sonar;

public class DepthIncreaseCalculator : IDepthIncreaseCalculator
{
    public int CountIncreases(int[] measurements)
    {
        var counter = 0;
        for (var i = 1; i < measurements.Length; i++)
        {
            if (i + 3 > measurements.Length)
                return counter;
            
            var previousRange = measurements[new Range(i - 1, i + 2)];
            var sumOfPreviousRange = previousRange.Sum();

            var range = measurements[new Range(i, i + 3)];
            var sumOfRange = range.Sum();

            if (sumOfRange > sumOfPreviousRange) counter++;
        }

        return counter;
    }
}

public interface IDepthIncreaseCalculator
{
    int CountIncreases(int[] measurements);
}