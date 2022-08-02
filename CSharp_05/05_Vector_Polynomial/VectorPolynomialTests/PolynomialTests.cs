using NUnit.Framework;
using Polynomial;

namespace VectorPolynomialTests
{
    public class PolynomialTests
    {

        [TestCase(0, int.MinValue, int.MaxValue)]

        public void Vector3D_BoundaryValues_Success(int first, int second, int third)
        {
            PolynomialOneVariable actual = new(new int[] { first, second, third });

            Assert.AreEqual(actual[0], 0);
            Assert.AreEqual(actual[1], int.MinValue);
            Assert.AreEqual(actual[2], int.MaxValue);
        }

        [Test]
        public void Polynomial_ToString_Success()
        {
            int[] koefFirst = { 11, 1 };

            PolynomialOneVariable first = new(koefFirst);

            string expected = "x+11";
            string actual = first.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Polynomial_Addition_Success()
        {
            int[] koefFirst = { 11, 1 };
            int[] koefSecond = { 1, 12 };

            PolynomialOneVariable first = new(koefFirst);
            PolynomialOneVariable second = new(koefSecond);

            PolynomialOneVariable thirdActual = first + second;

            string expected = "1213";
            string actual = string.Concat(thirdActual[0], thirdActual[1]);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Polynomial_Subtraction_Success()
        {
            int[] koefFirst = { 12, 2 };
            int[] koefSecond = { 10, 4 };

            PolynomialOneVariable first = new(koefFirst);
            PolynomialOneVariable second = new(koefSecond);

            PolynomialOneVariable thirdActual = first - second;

            string expected = "2-2";
            string actual = string.Concat(thirdActual[0], thirdActual[1]);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Polynomial_Multiplication_Success()
        {
            int[] koefFirst = { 12, 2 };

            PolynomialOneVariable first = new(koefFirst);
            PolynomialOneVariable thirdActual = first * 2;

            string expected = "244";
            string actual = string.Concat(thirdActual[0], thirdActual[1]);

            Assert.AreEqual(expected, actual);
        }
    }
}