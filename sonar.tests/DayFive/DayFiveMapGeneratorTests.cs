using NUnit.Framework;
using sonar.DayFive;

namespace sonar.tests.DayFive;

public class DayFiveMapGeneratorTests
{
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
            
            Assert.That(map[0,0].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[1,0].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[2,0].NumberOfVents, Is.EqualTo(0));
            Assert.That(map[1,1].NumberOfVents, Is.EqualTo(3));
            Assert.That(map[2,2].NumberOfVents, Is.EqualTo(0));
            Assert.That(map[0,1].NumberOfVents, Is.EqualTo(3));
            Assert.That(map[0,2].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[2,1].NumberOfVents, Is.EqualTo(2));
            Assert.That(map[1,2].NumberOfVents, Is.EqualTo(1));
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
            
            Assert.That(map[0,0].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[0,50].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[0,100].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[0,101].NumberOfVents, Is.EqualTo(0));
            
            Assert.That(map[99,0].NumberOfVents, Is.EqualTo(0));
            Assert.That(map[100,0].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[110,0].NumberOfVents, Is.EqualTo(1));
            Assert.That(map[120,0].NumberOfVents, Is.EqualTo(1));

        });
    }
}