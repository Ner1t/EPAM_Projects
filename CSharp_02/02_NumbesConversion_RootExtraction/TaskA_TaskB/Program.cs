using System;
using static NewtonRoot.CalculateRootTwoWays;

namespace NewtonRootUI
{
    class Program
    {
        static void ConsoleProcessor(out double number, out int degree, out double accuracy)
        {
            degree = default;
            accuracy = default;

            Console.WriteLine("Program for extracting the root of the N-th degree by Newton's method and the \"Standard\" method");

            Console.Write("Enter the number:");
            if (double.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Enter degree:");
                if (int.TryParse(Console.ReadLine(), out degree))
                {
                    Console.Write("Enter the accuracy of the calculation (should be less than 0.11):");
                    do
                    {
                        if (double.TryParse(Console.ReadLine(), out accuracy))
                        {
                            return;
                        }
                        if (accuracy > 0.11)
                        {
                            Console.WriteLine("Should be less than 0,11!");
                        }

                    } while (accuracy > 0.11);
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                    return;
                }
            }

            else
            {
                Console.WriteLine("Incorrect input");
                return;
            }
        }

        public static void ConsoleCalculate()
        {
            ConsoleProcessor(out double number, out int degree, out double accuracy);

            if (!(number == default || degree == default || accuracy == default))
            {
                double resultNewton = RootNewton(number, degree, accuracy);
                double resultStandard = RootStandart(number, degree);

                Console.WriteLine("Result by Newton's method: " + resultNewton);
                Console.WriteLine("Result by standard means: " + resultStandard);
                Console.WriteLine("The specified accuracy is: " + accuracy);

                if (resultNewton != resultStandard)
                {
                    Console.WriteLine($"Results are not equal.");
                }
                else
                {
                    Console.WriteLine($"Results are equal.");
                }
            }
        }
        static void Main(string[] args)
        {
            ConsoleCalculate();
        }
    }
}
