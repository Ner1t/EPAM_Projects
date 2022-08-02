using System;

namespace TriangleProcessor
{

    public class Triangle
    {
        private Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public static Triangle CreationTriangle(double a, double b, double c)
        {
            if ((a + b < c
                   || b + c < a
                   || c + a < b)
                   || ((a == 0 | b == 0 | c == 0)))
            {
                return null;
            }
            else
            {
                return new Triangle(a, b, c);
            }
        }

        public double A { get; init; }
        public double B { get; init; }
        public double C { get; init; }

        public double GetArea()
        {
            double p = GetPerimeter() / 2;
            double temp = p * (p - A) * (p - B) * (p - C);
            return Math.Sqrt(temp);

        }
        public double GetPerimeter()
        {
            return A + B + C;
        }

        public override string ToString()
        {
            return string.Concat($"Triangle: side a = {A} side b = {B} side c = {C} Area -> {GetArea()} Perimeter -> {GetPerimeter()}");
        }
    }
}
