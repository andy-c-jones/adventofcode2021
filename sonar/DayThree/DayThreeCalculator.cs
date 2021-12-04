namespace sonar.DayThree;

public class DayThreeCalculator : IDayThreeCalculator
{
    public int CalculatePowerConsumption(string[] input)
    {
        return 0;
    }

    public int CalculateGammaRate(string[] input)
    {
        var inputLength = input.Length;

        var result = "";

        for (var i = 0; i < 5; i++)
        {
            var column = input.Aggregate("", (current, s) => current + s[i]);

            var count = column.Count(c => c == '1');
            var halfRoundedDown = inputLength / 2;
            if (count >= halfRoundedDown + 1)
            {
                result += "1";
            }
            else
            {
                result += "0";
            }
        }

        return Convert.ToInt32(result, 2);
        ;
    }
}

public interface IDayThreeCalculator
{
    int CalculatePowerConsumption(string[] input);
}