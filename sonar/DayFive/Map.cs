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
            if (lineStart.X <= lineEnd.X)
            {
                for (var x = lineStart.X; x <= lineEnd.X; x++)
                {
                    yield return new Point(x, x);
                }
            }
            else
            {
                for (var x = lineStart.X; x >= lineEnd.X; x--)
                {
                    yield return new Point(x, x);
                }
            }
        }
        else
        {
            if (lineStart.X > lineEnd.X)
            {
                var difference = lineStart.X - lineEnd.X;
                for (var x = 0; x <= difference; x++)
                {
                    if (lineStart.Y > lineEnd.Y)
                    {
                        var newX = lineStart.X - x;
                        var newY = lineStart.Y - x;
                        yield return new Point(newX, newY);
                    }
                    else
                    {
                        var newX = lineStart.X - x;
                        var newY = lineStart.Y + x;
                        yield return new Point(newX, newY);
                    }
                }
            }
            else
            {
                var difference = lineEnd.X - lineStart.X;
                for (var x = 0; x <= difference; x++)
                {
                    var newX = lineStart.X + x;
                    var newY = lineStart.Y - x;
                    yield return new Point(newX, newY);
                }
            }
        }
    }

    private static bool LineIsDiagonal(Point lineStart, Point lineEnd) =>
        Math.Abs(lineStart.X - lineEnd.X) == Math.Abs(lineStart.Y - lineEnd.Y);

    private static IEnumerable<Point> CalculatePointsOnAStraightLine(Point lineStart, Point lineEnd)
    {
        if (lineStart.X == lineEnd.X)
        {
            if (lineStart.Y <= lineEnd.Y)
            {
                for (var y = lineStart.Y; y <= lineEnd.Y; y++)
                {
                    yield return new Point(lineStart.X, y);
                }
            }
            else
            {
                for (var y = lineStart.Y; y >= lineEnd.Y; y--)
                {
                    yield return new Point(lineStart.X, y);
                }
            }
        }
        else if (lineStart.Y == lineEnd.Y)
        {
            if (lineStart.X <= lineEnd.X)
            {
                for (var x = lineStart.X; x <= lineEnd.X; x++)
                {
                    yield return new Point(x, lineStart.Y);
                }
            }
            else
            {
                for (var x = lineStart.X; x >= lineEnd.X; x--)
                {
                    yield return new Point(x, lineStart.Y);
                }
            }
        }
    }
}

public class Node
{
    public int NumberOfVents { get; set; }
}