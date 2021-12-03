using NUnit.Framework;
using sonar.Sonar;

namespace sonar.tests.Sonar;

public class SonarReaderTests
{
    [TestCase("./TestFileInput/one.txt", new[] { 1, 2, 3, 4 })]
    [TestCase("./TestFileInput/two.txt", new[] { 324, 423, 654, 2434, 5435, 4, 234234 })]
    public async Task Should_read_file(string filePath, int[] expectedNumbers)
    {
        var numbers = await new SonarReader().ReadSonarMeasurementsFromFile(filePath);
        CollectionAssert.AreEquivalent(expectedNumbers, numbers);
    }
}