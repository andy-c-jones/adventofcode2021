using System.Text;

namespace sonar.DayThree;

public class DayThreeReader : IDayThreeReader
{
    public async Task<string[]> Read(string filePath) => await File.ReadAllLinesAsync(filePath, Encoding.UTF8);
}

public interface IDayThreeReader
{
    Task<string[]> Read(string filePath);
}