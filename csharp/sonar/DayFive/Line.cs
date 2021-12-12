namespace sonar.DayFive;

public record Line(Point Start, Point End);

public record struct Point(int X, int Y);