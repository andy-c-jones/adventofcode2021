namespace sonar.DayFive;

public static class Map
{
    public static Node[,] InitialiseFromLines(IEnumerable<Line> lines)
    {
        var linePoints = lines.SelectMany(line => CreateListOfLineCoordinates(line.Start, line.End).ToList()).ToList();

        var maxX = linePoints.Max(p => p.X);
        var maxY = linePoints.Max(p => p.Y);
        var max = (maxX > maxY ? maxX : maxY) + 1;
        var map = new Node[max, max];

        for (var index0 = 0; index0 < map.GetLength(0); index0++)
        for (var index1 = 0; index1 < map.GetLength(1); index1++)
        {
            map[index0, index1] = new Node();
        }

        foreach (var point in linePoints) map[point.X, point.Y].NumberOfVents += 1;
        
        return map;
    }

    private static IEnumerable<Point> CreateListOfLineCoordinates(Point lineStart, Point lineEnd)
    {
        var points = new List<Point>();
        if (lineStart.X <= lineEnd.X && lineStart.Y <= lineEnd.Y)
            for (var x = lineStart.X; x <= lineEnd.X; x++)
            {
                for (var y = lineStart.Y; y <= lineEnd.Y; y++)
                {
                    points.Add(new Point(x, y));
                }
            }
        else if (lineStart.X >= lineEnd.X && lineStart.Y <= lineEnd.Y)
        {
            for (var x = lineEnd.X; x <= lineStart.X; x++)
            {
                for (var y = lineStart.Y; y <= lineEnd.Y; y++)
                {
                    points.Add(new Point(x, y));
                }
            }
        }
        else if (lineStart.X >= lineEnd.X && lineStart.Y >= lineEnd.Y)
        {
            for (var x = lineEnd.X; x <= lineStart.X; x++)
            {
                for (var y = lineEnd.Y; y <= lineStart.Y; y++)
                {
                    points.Add(new Point(x, y));
                }
            }
        }
        else if (lineStart.X <= lineEnd.X && lineStart.Y >= lineEnd.Y)
        {
            for (var x = lineStart.X; x <= lineEnd.X; x++)
            {
                for (var y = lineEnd.Y; y <= lineStart.Y; y++)
                {
                    points.Add(new Point(x, y));
                }
            }
        }

        return points;
    }
}

public class Node
{
    public int NumberOfVents { get; set; }
}