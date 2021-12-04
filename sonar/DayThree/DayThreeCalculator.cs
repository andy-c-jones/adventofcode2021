namespace sonar.DayThree;

public class DayThreeCalculator : IDayThreeCalculator
{
    public int CalculatePowerConsumption(string[] input) =>
        CalculateGammaRate(input) * CalculateEpsilonRate(input);

    public int CalculateGammaRate(string[] input) => Calculate(input, Common);
    public int CalculateEpsilonRate(string[] input) => Calculate(input, LeastCommon);


    private static int Calculate(IReadOnlyCollection<string> input, Func<char, bool> countingFunction)
    {
        var result = "";
        for (var i = 0; i < (input.FirstOrDefault()?.Length ?? 1); i++)
        {
            var column = input.Aggregate("", (current, s) => current + s[i]);
            var count = column.Count(countingFunction);
            result += count >= input.Count / 2 + 1 ? "1" : "0";
        }

        return Convert.ToInt32(result, 2);
    }

    private static bool Common(char c) => c == '1';
    private static bool LeastCommon(char c) => c == '0';
}

public interface IDayThreeCalculator
{
    int CalculatePowerConsumption(string[] input);
}