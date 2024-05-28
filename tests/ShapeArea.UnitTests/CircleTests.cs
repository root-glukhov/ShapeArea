using ShapeArea.Lib.Primitives;

namespace ShapeArea.UnitTests;

public class CircleTests
{
    /// <summary>
    /// Тест проверяет, что площадь окружности вычисляется правильно.
    /// </summary>
    [Fact]
    public void TestAreaWithPositiveRadius()
    {
        var circle = new Circle(5);
        Assert.Equal(78.540, circle.Area, 3);
    }

    /// <summary>
    /// Тест проверяет, что при попытке создать окружность с отрицательным радиусом
    /// выбрасывается исключение ArgumentException.
    /// </summary>
    [Fact]
    public void TestAreaWithNonPositiveSides()
    {
        Assert.Throws<ArgumentException>(() => new Circle(-3));
    }
}
