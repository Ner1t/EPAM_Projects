using System;

namespace NewtonRoot
{

    public static class CalculateRootTwoWays
    {
        static double Pow(double a, int pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++)
            {
                result *= a;
            }
            return result;
        }

        static double RootNewtonWithoutAccuracy(double number, int degree, double quotient)
        {
            var result = 1.0 / degree * ((degree - 1.0) * quotient + number / Pow(quotient, degree - 1));
            return result;
        }

        public static double RootNewton(double number, int degree, double accuracy)
        {
            double quotient = number / degree;
            double result = RootNewtonWithoutAccuracy(number, degree, quotient);

            while (accuracy != 0 && Math.Abs(result - quotient) > accuracy)
            {
                quotient = result;
                result = RootNewtonWithoutAccuracy(number, degree, quotient);
            }
            return result;
        }

        public static double RootStandart(double number, int degree)
        {
            return Math.Pow(number, 1.0 / degree);
        }
    }
}
