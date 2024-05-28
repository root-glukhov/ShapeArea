namespace ShapeArea.Lib.Primitives;

public class Circle : Shape
{
    private readonly double _radius;
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

    public Circle(double radius)
    {
        ValidateRadius(radius);
        _radius = radius;
    }

    private double CalculateArea()
    {
        return Math.PI * _radius * _radius;
    }

    private static void ValidateRadius(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Radius of a circle must be positive.");
        }
    }
}

