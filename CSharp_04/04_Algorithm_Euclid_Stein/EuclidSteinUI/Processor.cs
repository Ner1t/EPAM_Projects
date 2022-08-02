using System;

namespace AlgorithmEuclidAndStein

{
    public class Processor
    {
        const int minimalNumber = 2;
        public static void ProcessorSelector()
        {
            Console.WriteLine("The program for calculating the greatest common divisor using the Euclid and Stein algorithms for an arbitrary number" +
                " of digits and also measuring the execution time (in seconds)");
            Console.WriteLine();
            Console.WriteLine("Enter at least two values in one line separate by space:");

            string[] input = Console.ReadLine().Split(" ");

            if (input.Length < minimalNumber)
            {
                Console.WriteLine("The number of input values must be at least two");
                return;
            }

            int[] array = ProcessorParser(input);

            ProcessorLogic(array, out string elapsedTimeClassic, out string elapsedTimeBinary, out int resultClassic, out int resultBinary);

            Console.WriteLine($"GCD Euclid for {array.Length} values is: {resultClassic}, elapsed time: {elapsedTimeClassic} " +
                $"\nGCD Stein for {array.Length} values is: {resultBinary}, elapsed time: {elapsedTimeBinary}");
        }

        public static int[] ProcessorParser(string[] input)
        {
            int[] mass = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                if (!int.TryParse(input[i], out mass[i]))
                {
                    return default;
                }
            }
            return mass;
        }

        public static void ProcessorLogic(int[] mass, out string elapsedTimeClassic, out string elapsedTimeBinary, out int resultClassic, out int resultBinary)
        {
            resultClassic = Euclid.CalculateGcd(out elapsedTimeClassic, mass);
            resultBinary = Stein.CalculateGcd(out elapsedTimeBinary, mass);
        }
    }
}