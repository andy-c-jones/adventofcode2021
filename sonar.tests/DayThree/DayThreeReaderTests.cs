using NUnit.Framework;
using sonar.DayThree;

namespace sonar.tests.DayThree;

public class DayThreeReaderTests
{
    [Test]
    public async Task ShouldReadInputFromFile()
    {
        var reader = new DayThreeReader();
        var result = await reader.Read("./DayThree/daythreetestinput.txt");

        CollectionAssert.AreEquivalent(new[]
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        },result);
    }
}