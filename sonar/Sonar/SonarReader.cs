using System.Text;

namespace sonar.Sonar;

public class SonarReader : ISonarReader
{
    public async Task<int[]> ReadSonarMeasurementsFromFile(string filePath)
    {
        var lines = await File.ReadAllLinesAsync(filePath, Encoding.UTF8);
        return lines.Select(int.Parse).ToArray();
    }
}

public interface ISonarReader
{
    Task<int[]> ReadSonarMeasurementsFromFile(string filePath);
}