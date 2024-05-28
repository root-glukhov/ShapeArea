namespace ShapeArea.Lib.Primitives;

public class Triangle : Shape
{
    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;
    private readonly double _semiPerimeter;
    private double? _area;

    public override double Area
    {
        get
        {
            if (!_area.HasValue)
            {
                _area = CalculateArea();
            }

            return _area.Value;
        }
    }

    public bool IsRightAngled
    {
        get
        {
            double a = _sideA;
            double b = _sideB;
            double c = _sideC;

            return (a * a + b * b == c * c) ||
                   (a * a + c * c == b * b) ||
                   (b * b + c * c == a * a);
        }
    }

    public Triangle(double sideA, double sideB, double sideC)
    {
        ValidateSides(sideA, sideB, sideC);

        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
        _semiPerimeter = (sideA + sideB + sideC) / 2;
    }

    private double CalculateArea()
    {
        return Math.Sqrt(_semiPerimeter *
            (_semiPerimeter - _sideA) *
            (_semiPerimeter - _sideB) *
            (_semiPerimeter - _sideC));
    }

    private static void ValidateSides(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            throw new ArgumentException("All sides of a triangle must be positive.");
        }

        if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
        {
            throw new ArgumentException("The given sides do not form a valid triangle.");
        }
    }
}

