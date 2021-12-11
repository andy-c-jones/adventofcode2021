using NUnit.Framework;
using sonar.DayFive;

namespace sonar.tests.DayFive;

public class DayFiveMapGeneratorTests
{
    [Test]
    public void Should_draw_a_map_with_one_line()
    {
        var mapGenerator = new DayFiveMapGenerator();

        // 1 0 0
        // 1 0 0
        // 1 0 0
        var map = mapGenerator.CreateMap(new[]
        {
            new Line(new Point(0, 2), new Point(0, 0)), // this line goes top to bottom on Y axis
        });

        Assert.Multiple(() =>
        {
            //The map should be as large as the highest point in a in
            //both dimensions so it is always a square  
            Assert.That(map.GetLength(0), Is.EqualTo(3));
            Assert.That(map.GetLength(1), Is.EqualTo(3));

            Assert.That(map[0, 0].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[0, 1].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[0, 2].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[1, 0].NumberOfVents, Is.EqualTo(0));
            Assert.That(map[2, 0].NumberOfVents, Is.EqualTo(0));
            Assert.That(map[1, 1].NumberOfVents, Is.EqualTo(0));
            Assert.That(map[2, 2].NumberOfVents, Is.EqualTo(0));
            Assert.That(map[2, 1].NumberOfVents, Is.EqualTo(0));
            Assert.That(map[1, 2].NumberOfVents, Is.EqualTo(0));
        });
    }

    [Test]
    public void Should_draw_a_map_with_value_of_how_many_lines_run_along_the_points()
    {
        var mapGenerator = new DayFiveMapGenerator();

        // 1 1 0
        // 3 3 2
        // 1 1 0
        var map = mapGenerator.CreateMap(new[]
        {
            new Line(new Point(0, 2), new Point(0, 0)), // this line goes top to bottom on Y axis
            new Line(new Point(1, 0), new Point(1, 2)), // This line goes bottom to top on Y axis
            new Line(new Point(2, 1), new Point(0, 1)), // This line goes right to left on X axis
            new Line(new Point(0, 1), new Point(2, 1)), // This line goes left to right on X axis
        });

        Assert.Multiple(() =>
        {
            //The map should be as large as the highest point in a in
            //both dimensions so it is always a square  
            Assert.That(map.GetLength(0), Is.EqualTo(3));
            Assert.That(map.GetLength(1), Is.EqualTo(3));

            Assert.That(map[0, 0].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[1, 0].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[2, 0].NumberOfVents, Is.EqualTo(0));
            Assert.That(map[1, 1].NumberOfVents, Is.EqualTo(3));
            Assert.That(map[2, 2].NumberOfVents, Is.EqualTo(0));
            Assert.That(map[0, 1].NumberOfVents, Is.EqualTo(3));
            Assert.That(map[0, 2].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[2, 1].NumberOfVents, Is.EqualTo(2));
            Assert.That(map[1, 2].NumberOfVents, Is.EqualTo(1));
        });
    }

    [Test]
    public void Should_draw_a_map_with_value_of_how_many_lines_run_along_the_points_large()
    {
        var mapGenerator = new DayFiveMapGenerator();

        var map = mapGenerator.CreateMap(new[]
        {
            new Line(new Point(0, 100), new Point(0, 0)),
            new Line(new Point(120, 0), new Point(100, 0)),
        });

        Assert.Multiple(() =>
        {
            //The map should be as large as the highest point in a in
            //both dimensions so it is always a square  
            Assert.That(map.GetLength(0), Is.EqualTo(121));
            Assert.That(map.GetLength(1), Is.EqualTo(121));

            Assert.That(map[0, 0].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[0, 50].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[0, 100].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[0, 101].NumberOfVents, Is.EqualTo(0));

            Assert.That(map[99, 0].NumberOfVents, Is.EqualTo(0));
            Assert.That(map[100, 0].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[110, 0].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[120, 0].NumberOfVents, Is.EqualTo(1));
        });
    }

    [Test]
    public void Should_draw_a_map_with_diagonal_lines()
    {
        var mapGenerator = new DayFiveMapGenerator();

        var map = mapGenerator.CreateMap(new[]
        {
            new Line(new Point(1, 1), new Point(3, 3)),
            new Line(new Point(9, 7), new Point(7, 9)),
            new Line(new Point(4, 6), new Point(6, 4)),
        });

        Assert.Multiple(() =>
        {
            Assert.That(map[1, 1].NumberOfVents, Is.EqualTo(1), "1, 1");
            Assert.That(map[2, 2].NumberOfVents, Is.EqualTo(1), "2, 2");
            Assert.That(map[3, 3].NumberOfVents, Is.EqualTo(1), "3, 3");

            Assert.That(map[9, 7].NumberOfVents, Is.EqualTo(1), "9, 7");
            Assert.That(map[8, 8].NumberOfVents, Is.EqualTo(1), "8, 8");
            Assert.That(map[7, 9].NumberOfVents, Is.EqualTo(1), "7, 9");

            Assert.That(map[9, 7].NumberOfVents, Is.EqualTo(1), "4, 6");
            Assert.That(map[8, 8].NumberOfVents, Is.EqualTo(1), "5, 5");
            Assert.That(map[7, 9].NumberOfVents, Is.EqualTo(1), "6, 4");
        });
    }

    [Test]
    public void Should_draw_a_map_with_diagonal_lines_left_right_bottom_to_top()
    {
        var mapGenerator = new DayFiveMapGenerator();

        var map = mapGenerator.CreateMap(new[]
        {
            new Line(new Point(0, 0), new Point(3, 3)),
        });

        Assert.Multiple(() =>
        {
            Assert.That(map[0, 0].NumberOfVents, Is.EqualTo(1), "0, 0");
            Assert.That(map[1, 1].NumberOfVents, Is.EqualTo(1), "1, 1");
            Assert.That(map[2, 2].NumberOfVents, Is.EqualTo(1), "2, 2");
            Assert.That(map[3, 3].NumberOfVents, Is.EqualTo(1), "3, 3");
        });
    }

    [Test]
    public void Should_draw_a_map_with_diagonal_lines_right_left_top_to_bottom()
    {
        var mapGenerator = new DayFiveMapGenerator();

        var map = mapGenerator.CreateMap(new[]
        {
            new Line(new Point(3, 3), new Point(0, 0)),
        });

        Assert.Multiple(() =>
        {
            Assert.That(map[0, 0].NumberOfVents, Is.EqualTo(1), "0, 0");
            Assert.That(map[1, 1].NumberOfVents, Is.EqualTo(1), "1, 1");
            Assert.That(map[2, 2].NumberOfVents, Is.EqualTo(1), "2, 2");
            Assert.That(map[3, 3].NumberOfVents, Is.EqualTo(1), "3, 3");
        });
    }

    [Test]
    public void Should_draw_a_map_with_diagonal_lines_left_right_top_to_bottom()
    {
        var mapGenerator = new DayFiveMapGenerator();

        var map = mapGenerator.CreateMap(new[]
        {
            new Line(new Point(0, 3), new Point(3, 0)),
        });

        Assert.Multiple(() =>
        {
            Assert.That(map[0, 3].NumberOfVents, Is.EqualTo(1), "0, 3");
            Assert.That(map[1, 2].NumberOfVents, Is.EqualTo(1), "1, 2");
            Assert.That(map[2, 1].NumberOfVents, Is.EqualTo(1), "2, 1");
            Assert.That(map[3, 0].NumberOfVents, Is.EqualTo(1), "3, 0");
        });
    }

    [Test]
    public void Should_draw_a_map_with_diagonal_lines_right_left_bottom_to_top()
    {
        var mapGenerator = new DayFiveMapGenerator();

        var map = mapGenerator.CreateMap(new[]
        {
            new Line(new Point(3, 0), new Point(0, 3)),
        });

        Assert.Multiple(() =>
        {
            Assert.That(map[0, 3].NumberOfVents, Is.EqualTo(1), "0, 3");
            Assert.That(map[1, 2].NumberOfVents, Is.EqualTo(1), "1, 2");
            Assert.That(map[2, 1].NumberOfVents, Is.EqualTo(1), "2, 1");
            Assert.That(map[3, 0].NumberOfVents, Is.EqualTo(1), "3, 0");
        });
    }

    [Test]
    public void Should_draw_a_map_with_diagonal_lines_again()
    {
        var mapGenerator = new DayFiveMapGenerator();

        var map = mapGenerator.CreateMap(new[]
        {
            new Line(new Point(5, 5), new Point(8, 2)),
        });

        Assert.Multiple(() =>
        {
            Assert.That(map[5, 5].NumberOfVents, Is.EqualTo(1), "5, 5");
            Assert.That(map[6, 4].NumberOfVents, Is.EqualTo(1), "6, 4");
            Assert.That(map[7, 3].NumberOfVents, Is.EqualTo(1), "7, 3");
            Assert.That(map[8, 2].NumberOfVents, Is.EqualTo(1), "8, 2");
        });
    }

    [Test]
    public void Should_draw_a_map_with_diagonal_lines_again_and_again()
    {
        var mapGenerator = new DayFiveMapGenerator();

        var map = mapGenerator.CreateMap(new[]
        {
            new Line(new Point(6, 4), new Point(2, 0)),
        });

        Assert.Multiple(() =>
        {
            Assert.That(map[6, 4].NumberOfVents, Is.EqualTo(1), "6, 4");
            Assert.That(map[5, 3].NumberOfVents, Is.EqualTo(1), "5, 4");
            Assert.That(map[4, 2].NumberOfVents, Is.EqualTo(1), "4, 2");
            Assert.That(map[3, 1].NumberOfVents, Is.EqualTo(1), "3, 1");
            Assert.That(map[2, 0].NumberOfVents, Is.EqualTo(1), "2, 0");
        });
    }

    [Test]
    public void Should_draw_a_map_with_diagonal_lines_again_and_again_and_again()
    {
        var mapGenerator = new DayFiveMapGenerator();

        var map = mapGenerator.CreateMap(new[]
        {
            new Line(new Point(1, 3), new Point(6, 8)),
        });

        Assert.Multiple(() =>
        {
            Assert.That(map[1, 3].NumberOfVents, Is.EqualTo(1), "1, 3");
            Assert.That(map[2, 4].NumberOfVents, Is.EqualTo(1), "2, 4");
            Assert.That(map[3, 5].NumberOfVents, Is.EqualTo(1), "3, 5");
            Assert.That(map[4, 6].NumberOfVents, Is.EqualTo(1), "4, 6");
            Assert.That(map[5, 7].NumberOfVents, Is.EqualTo(1), "5, 7");
            Assert.That(map[6, 8].NumberOfVents, Is.EqualTo(1), "6, 8");
        });
    }
}