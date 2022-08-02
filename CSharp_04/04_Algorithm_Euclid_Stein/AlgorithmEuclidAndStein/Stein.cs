using System.Diagnostics;

namespace AlgorithmEuclidAndStein
{
    public class Stein
    {
        public static int CalculateGcd(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }
            if (a == b)
            {
                return a;
            }

            bool val1IsEven = (a & 1) == 0;
            bool val2IsEven = (b & 1) == 0;

            if (val1IsEven && val2IsEven)
            {
                return CalculateGcd(a >> 1, b >> 1) << 1;
            }

            else if (val1IsEven && !val2IsEven)
            {
                return CalculateGcd(a >> 1, b);
            }

            else if (val2IsEven)
            {
                return CalculateGcd(a, b >> 1);
            }

            else if (a > b)
            {
                return CalculateGcd((a - b) >> 1, b);
            }

            else
            {
                return CalculateGcd(a, (b - a) >> 1);
            }
        }

        public static int CalculateGcd(int a, int b, int c)
        {
            int gcd = CalculateGcd(a, b);
            gcd = CalculateGcd(gcd, c);
            return gcd;
        }
        public static int CalculateGcd(int a, int b, int c, int d)
        {
            int gcd = CalculateGcd(a, b, c);
            gcd = CalculateGcd(gcd, d);
            return gcd;
        }
        public static int CalculateGcd(int a, int b, int c, int d, int e)
        {
            int gcd = CalculateGcd(a, b, c, d);
            gcd = CalculateGcd(gcd, e);
            return gcd;
        }
        public static int CalculateGcd(params int[] values)
        {
            if (values.Length < 2)
            {
                return default;
            }

            int gcd = values[0];

            for (int i = 1; i < values.Length; i++)
            {
                gcd = CalculateGcd(gcd, values[i]);
            }

            return gcd;
        }
        public static int CalculateGcd(out string elapsedTime, params int[] values)
        {
            elapsedTime = default;

            if (values.Length < 2)
            {
                return default;
            }

            Stopwatch stopwatch = new();
            stopwatch.Start();

            int gcd = CalculateGcd(values);

            stopwatch.Stop();

            elapsedTime = stopwatch.Elapsed.TotalMilliseconds.ToString();
            return gcd;
        }
    }
}
