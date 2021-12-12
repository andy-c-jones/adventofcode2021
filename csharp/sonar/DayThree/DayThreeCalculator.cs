namespace sonar.DayThree;

public class DayThreeCalculator : IDayThreeCalculator
{
    public int CalculatePowerConsumption(string[] input) =>
        CalculateGammaRate(input) * CalculateEpsilonRate(input);
    
    public int CalculateLifeSupportRate(string[] input) =>
        CalculateOxygenGeneratorRating(input) * CalculateCO2ScrubberRating(input);

    public int CalculateGammaRate(string[] input) => Calculate(input, OneMoreCommon);
    public int CalculateEpsilonRate(string[] input) => Calculate(input, OnesLessCommon);


    private static int Calculate(IReadOnlyCollection<string> input, Func<int, int, bool> func)
    {
        var result = "";
        for (var i = 0; i < (input.FirstOrDefault()?.Length ?? 1); i++)
        {
            var columnAggregate = input.Aggregate("", (current, s) => current + s[i]);
            var countOnes = columnAggregate.Count(c => c == '1');
            var countZeros = columnAggregate.Count(c => c == '0');
            result += func(countOnes, countZeros) ? "1" : "0";
        }

        return Convert.ToInt32(result, 2);
    }

    private static bool OneMoreCommon(int countOnes, int countZeros) => countOnes > countZeros;
    private static bool OnesLessCommon(int countOnes, int countZeros) => countOnes < countZeros;
    
    private static bool OneMoreCommonOrEqual(int countOnes, int countZeros) => countOnes >= countZeros;
    private static bool OnesLessCommonOrEqual(int countOnes, int countZeros) => countOnes < countZeros;

    public int CalculateOxygenGeneratorRating(string[] input) => Recur(input, 0, OneMoreCommonOrEqual);
    public int CalculateCO2ScrubberRating(string[] input) => Recur(input, 0, OnesLessCommonOrEqual);

    private static int Recur(IReadOnlyCollection<string> inputs, int col, Func<int, int, bool> compFunc)
    {
        var columnAggregate = inputs.Aggregate("", (current, s) => current + s[col]);
        var countOnes = columnAggregate.Count(c => c == '1');
        var countZeros = columnAggregate.Count(c => c == '0');
        var mostCommonBit = compFunc(countOnes, countZeros) ? '1' : '0';

        var remainingInputs = inputs.Where(i => i[col] == mostCommonBit).ToArray();

        var nextCol = col + 1;
        return remainingInputs.Length == 1 || remainingInputs.First().Length == nextCol
            ? Convert.ToInt32(remainingInputs.First(), 2)
            : Recur(remainingInputs, nextCol, compFunc);
    }
}

public interface IDayThreeCalculator
{
    int CalculatePowerConsumption(string[] input);
    int CalculateLifeSupportRate(string[] input);
}