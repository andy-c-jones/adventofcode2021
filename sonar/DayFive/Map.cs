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
        if (LineIsDiagonal(lineStart, lineEnd))
        {
            foreach (var point in CalculatePointsOnADiagonalLine(lineStart, lineEnd)) yield return point;
        }
        else
        {
            foreach (var point in CalculatePointsOnAStraightLine(lineStart, lineEnd)) yield return point;
        }
    }

    private static IEnumerable<Point> CalculatePointsOnADiagonalLine(Point lineStart, Point lineEnd)
    {
        if (lineStart.X == lineStart.Y && lineEnd.X == lineEnd.Y)
        {
            for (var x = lineStart.X; x <= lineEnd.X; x++)
            {
                yield return new Point(x, x);
            }
        }
        else
        {
            if (lineStart.X > lineStart.Y)
            {
                var difference = lineStart.X - lineStart.Y;
                for (var x = 0; x <= difference; x++)
                {
                    var newX = lineStart.X - x;
                    var neY = lineStart.Y + x;
                    yield return new Point(newX, neY);
                }
            }
            else
            {
                var difference = lineStart.Y - lineStart.X;
                for (var x = 0; x <= difference; x++)
                {
                    yield return new Point(lineStart.X + x, lineStart.Y - x);
                }
            }
        }
    }

    private static bool LineIsDiagonal(Point lineStart, Point lineEnd) =>
        lineStart.X == lineStart.Y && lineEnd.X == lineEnd.Y
        || lineStart.X == lineEnd.Y && lineStart.Y == lineEnd.X;

    private static IEnumerable<Point> CalculatePointsOnAStraightLine(Point lineStart, Point lineEnd)
    {
        if (lineStart.X <= lineEnd.X && lineStart.Y <= lineEnd.Y)
            for (var x = lineStart.X; x <= lineEnd.X; x++)
            {
                for (var y = lineStart.Y; y <= lineEnd.Y; y++)
                {
                    yield return new Point(x, y);
                }
            }
        else if (lineStart.X >= lineEnd.X && lineStart.Y <= lineEnd.Y)
        {
            for (var x = lineEnd.X; x <= lineStart.X; x++)
            {
                for (var y = lineStart.Y; y <= lineEnd.Y; y++)
                {
                    yield return new Point(x, y);
                }
            }
        }
        else if (lineStart.X >= lineEnd.X && lineStart.Y >= lineEnd.Y)
        {
            for (var x = lineEnd.X; x <= lineStart.X; x++)
            {
                for (var y = lineEnd.Y; y <= lineStart.Y; y++)
                {
                    yield return new Point(x, y);
                }
            }
        }
    }
}

public class Node
{
    public int NumberOfVents { get; set; }
}