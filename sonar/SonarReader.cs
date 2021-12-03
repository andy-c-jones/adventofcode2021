using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sonar;

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