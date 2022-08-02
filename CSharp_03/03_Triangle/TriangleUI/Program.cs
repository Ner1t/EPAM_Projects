using System;
using TriangleProcessor;
using static TriangleProcessor.Triangle;

namespace TriangleUI
{
    public class Program
    {
        public static void TriangleConsole()
        {
            string sides;
            do
            {
                Console.WriteLine("Enter the values of the three sides of the triangle separated by a space or Enter to exit the program:");

                sides = Console.ReadLine();
                sides = sides.Trim();
                string[] sidesArray = sides.Split(" ");

                if (string.IsNullOrEmpty(sides))
                {
                    break;
                }

                if (sidesArray.Length == 3)
                {
                    if (!double.TryParse(sidesArray[0], out double a)
                    || !double.TryParse(sidesArray[1], out double b)
                    || !double.TryParse(sidesArray[2], out double c))
                    {
                        Console.WriteLine("Incorrect input");
                        continue;
                    }

                    Triangle triangle = CreationTriangle(a, b, c);

                    if (triangle is null)
                    {
                        Console.WriteLine("A triangle with specified sides cannot exist");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Triangle created:");
                        Console.WriteLine(triangle.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                    continue;
                }

            } while (!string.IsNullOrEmpty(sides));
        }
        static void Main(string[] args)
        {
            TriangleConsole();
        }
    }
}
