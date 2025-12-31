namespace ProblemsInLINQINCSharp.FactoryPattern
{
     public interface IShape
    {
        void Draw();
        double CalculateArea();
    }

    // Concrete Products
    public class Circle : IShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing Circle with radius {Radius}");
        }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Rectangle : IShape
    {
        public double Width { get; }
        public double Height { get; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing Rectangle {Width}x{Height}");
        }

        public double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Triangle : IShape
    {
        public double Base { get; }
        public double Height { get; }

        public Triangle(double @base, double height)
        {
            Base = @base;
            Height = height;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing Triangle with base {Base} and height {Height}");
        }

        public double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
    }

    public class ShapeFactory
    {
        public IShape CreateShape(string shapeType, params double[] dimensions)
        {
            return shapeType.ToLower() switch
            {
                "circle" => dimensions.Length >= 1 
                    ? new Circle(dimensions[0]) 
                    : throw new ArgumentException("Circle requires radius"),
                    
                "rectangle" => dimensions.Length >= 2 
                    ? new Rectangle(dimensions[0], dimensions[1]) 
                    : throw new ArgumentException("Rectangle requires width and height"),
                    
                "triangle" => dimensions.Length >= 2 
                    ? new Triangle(dimensions[0], dimensions[1]) 
                    : throw new ArgumentException("Triangle requires base and height"),
                    
                _ => throw new ArgumentException($"Unknown shape type: {shapeType}")
            };
        }
    }
}