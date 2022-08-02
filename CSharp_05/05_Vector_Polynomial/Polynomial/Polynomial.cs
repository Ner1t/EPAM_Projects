using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polynomial
{
    public class PolynomialOneVariable
    {
        readonly SortedList<int, int> array = new();

        public PolynomialOneVariable() { }

        public PolynomialOneVariable(int[] coefficients)
        {
            for (int i = 0; i < coefficients.Length; i++)
            {
                this[i] = coefficients[i];
            }
        }

        public PolynomialOneVariable(PolynomialOneVariable polynomial)
        {
            foreach (var element in polynomial.array)
            {
                array[element.Key] = element.Value;
            }
        }

        public int this[int index]
        {
            get
            {
                return array.ContainsKey(index) ? array[index] : 0;
            }
            set
            {
                if (value != 0)
                {
                    array[index] = value;
                }
            }
        }

        public override string ToString()
        {
            if (array.Count == 0)
            {
                return "0";
            }

            StringBuilder result = new();

            foreach (var element in array.Reverse())
            {
                string format = element.Value < 0 ? "-{0}" : "+{0}";

                if (element.Key > 0 && element.Value == -1)
                {
                    format = "-";
                }
                else if (element.Key > 0 && element.Value == 1)
                {
                    format = "+";
                }

                result.AppendFormat(format, Math.Abs(element.Value));

                format = "x^{0}";
                if (element.Key == 0)
                {
                    format = "";
                }
                else if (element.Key == 1)
                {
                    format = "x";
                }
                result.AppendFormat(format, element.Key);
            }

            if (result[0] == '+')
            {
                result.Remove(0, 1);
            }

            return result.ToString();
        }

        public static PolynomialOneVariable operator +(PolynomialOneVariable polynomialFirst, PolynomialOneVariable polynomialSecond)
        {
            PolynomialOneVariable result = new(polynomialFirst);
            foreach (var element in polynomialSecond.array)
            {
                result[element.Key] += element.Value;
            }
            return result;
        }

        public static PolynomialOneVariable operator -(PolynomialOneVariable polynomialFirst, PolynomialOneVariable polynomialSecond)
        {
            return polynomialFirst + polynomialSecond * -1;
        }

        public static PolynomialOneVariable operator *(PolynomialOneVariable polynomial, int number)
        {
            PolynomialOneVariable result = new();
            foreach (var element in polynomial.array)
            {
                result[element.Key] = element.Value * number;
            }
            return result;
        }
    }
}