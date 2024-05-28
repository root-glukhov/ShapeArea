using ShapeArea.Lib.Primitives;

namespace ShapeArea.UnitTests;

public class TriangleTests
{
    /// <summary>
    /// Тест проверяет, что площадь треугольника вычисляется правильно.
    /// </summary>
    [Fact]
    public void TestAreaWithPositiveSides()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.Equal(6, triangle.Area, 3);
    }

    /// <summary>
    /// Тест проверяет, что свойство IsRightAngled верно определяет является ли треугольник прямоугольным.
    /// </summary>
    [Fact]
    public void TestIsRightAngledValidReturnValues()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.True(triangle.IsRightAngled);

        triangle = new Triangle(3, 3, 3);
        Assert.False(triangle.IsRightAngled);
    }

    /// <summary>
    /// Тест проверяет, что при попытке создать треугольник с отрицательными сторонами
    /// выбрасывается исключение ArgumentException.
    /// </summary>
    [Theory]
    [InlineData(0, 4, 5)]
    [InlineData(-3, 4, 5)]
    public void TestAreaWithNonPositiveSides(double sideA, double sideB, double sideC)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }

    /// <summary>
    /// Тест проверяет, что при попытке создать треугольник с недопустимыми сторонами
    /// (сумма двух сторон меньше третьей) выбрасывается исключение ArgumentException.
    /// </summary>
    [Theory]
    [InlineData(1, 2, 4)]
    [InlineData(3, 4, -5)]
    public void TestInvalidTriangle(double sideA, double sideB, double sideC)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }
}