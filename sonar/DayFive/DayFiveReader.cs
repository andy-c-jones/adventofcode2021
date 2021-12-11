using System.Collections.Immutable;
using System.Text;
using System.Text.RegularExpressions;

namespace sonar.DayFive;

public class DayFiveReader : IDayFiveReader
{
    private readonly Regex _lineRegex = new(@"^(\d+),(\d+)\s->\s(\d+),(\d+)$", RegexOptions.Compiled);

    public async Task<ImmutableArray<Line>> ReadLinesFrom(string filePath)
    {
        var fileLines = await File.ReadAllLinesAsync(filePath, Encoding.UTF8);

        return fileLines
            .Select(fileLine => _lineRegex.Split(fileLine)
                .Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse)
                .ToArray())
            .Select(values => new Line(new Point(values[0], values[1]), new Point(values[2], values[3])))
            .ToImmutableArray();
    }
}

public interface IDayFiveReader
{
    Task<ImmutableArray<Line>> ReadLinesFrom(string filePath);
}