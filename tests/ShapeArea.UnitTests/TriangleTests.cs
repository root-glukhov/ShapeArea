using ShapeArea.Lib.Primitives;

namespace ShapeArea.UnitTests;

public class TriangleTests
{
    /// <summary>
    /// ���� ���������, ��� ������� ������������ ����������� ���������.
    /// </summary>
    [Fact]
    public void TestAreaWithPositiveSides()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.Equal(6, triangle.Area, 3);
    }

    /// <summary>
    /// ���� ���������, ��� �������� IsRightAngled ����� ���������� �������� �� ����������� �������������.
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
    /// ���� ���������, ��� ��� ������� ������� ����������� � �������������� ���������
    /// ������������� ���������� ArgumentException.
    /// </summary>
    [Theory]
    [InlineData(0, 4, 5)]
    [InlineData(-3, 4, 5)]
    public void TestAreaWithNonPositiveSides(double sideA, double sideB, double sideC)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }

    /// <summary>
    /// ���� ���������, ��� ��� ������� ������� ����������� � ������������� ���������
    /// (����� ���� ������ ������ �������) ������������� ���������� ArgumentException.
    /// </summary>
    [Theory]
    [InlineData(1, 2, 4)]
    [InlineData(3, 4, -5)]
    public void TestInvalidTriangle(double sideA, double sideB, double sideC)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }
}