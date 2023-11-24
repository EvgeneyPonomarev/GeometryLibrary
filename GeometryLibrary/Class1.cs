using System;

namespace GeometryLibrary
{
    public interface IShape
    {
        double CalculateArea();
    }

    public class Circle : IShape
    {
        public double Radius { get; private set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Triangle : IShape
    {
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double CalculateArea()
        {
            // Используем формулу Герона
            double semiperimeter = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(semiperimeter * (semiperimeter - SideA) * (semiperimeter - SideB) * (semiperimeter - SideC));
        }

        public bool IsRightTriangle()
        {
            // Проверка на прямоугольность треугольника по теореме Пифагора
            double aSquared = SideA * SideA;
            double bSquared = SideB * SideB;
            double cSquared = SideC * SideC;

            return Math.Abs(aSquared + bSquared - cSquared) < 0.0001 ||
            Math.Abs(bSquared + cSquared - aSquared) < 0.0001 ||
            Math.Abs(aSquared + cSquared - bSquared) < 0.0001;
        }
    }

    // Добавление других фигур
    // ...

    public class ShapeCalculator
    {
        public static double CalculateArea(IShape shape)
        {
            return shape.CalculateArea();
        }
    }

    // Пример юнит-тестов
    public class UnitTests
    {
        public static void RunTests()
        {
            CircleTests();
            TriangleTests();
        }

        public static void CircleTests()
        {
            Circle circle = new Circle(5);
            double circleArea = ShapeCalculator.CalculateArea(circle);
            Console.WriteLine("Circle Area: " + circleArea); // Ожидаемый результат: 78.53981633974483
        }

        public static void TriangleTests()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            double triangleArea = ShapeCalculator.CalculateArea(triangle);
            Console.WriteLine("Triangle Area: " + triangleArea); // Ожидаемый результат: 6

            bool isRightTriangle = triangle.IsRightTriangle();
            Console.WriteLine("Is Right Triangle: " + isRightTriangle); // Ожидаемый результат: True
        }
    }

    // Пример использования
    class Program
    {
        static void Main(string[] args)
        {
            UnitTests.RunTests();
        }
    }
}