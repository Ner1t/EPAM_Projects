using Matrix;
using MatrixCreation;
using NUnit.Framework;
using System;
using static MatrixCreation.Matrix2D;

namespace MatrixTests
{
    public class Tests
    {
        Matrix2D firstMatrix;
        Matrix2D secondMatrix;

        [Test]
        public void Matrix2D_ToString_Success()
        {
            firstMatrix = new(2, 2);
            string expected = "0 0\n0 0";

            Assert.AreEqual(expected, firstMatrix.ToString());
        }

        [Test]
        public void Matrix2D_GetDimensions_Success()
        {
            firstMatrix = new Matrix2D(2, 3);

            string expected = "Number of rows is: 2 number of columns is: 3";

            Assert.AreEqual(expected, firstMatrix.GetDimensions());
        }

        [Test]
        public void Matrix2D_Addition_Success()
        {
            int[,] arrayFirst = { { 1, 1 }, { 2, 2 } };
            int[,] arraySecond = { { 2, 2 }, { 1, 1 } };

            firstMatrix = new Matrix2D(arrayFirst);
            secondMatrix = new Matrix2D(arraySecond);

            Matrix2D expected = new(new int[,] { { 3, 3 }, { 3, 3 } });
            Matrix2D actual = Addition(firstMatrix, secondMatrix);

            Assert.AreEqual(expected.MatrixArray, actual.MatrixArray);
        }
        [Test]
        public void Matrix2D_Addition_Faulty()
        {
            int[,] arrayFirst = { { 1, 1, 2 }, { 2, 3, 3 } };
            int[,] arraySecond = { { 2, 2 }, { 1, 1 } };

            firstMatrix = new Matrix2D(arrayFirst);
            secondMatrix = new Matrix2D(arraySecond);

            Assert.Throws<Matrix2DException>(() => Addition(firstMatrix, secondMatrix));
        }
        [Test]
        public void Matrix2D_Subtraction_Success()
        {
            int[,] arrayFirst = { { 2, 2 }, { 1, 1 } };
            int[,] arraySecond = { { 1, 1 }, { 2, 2 } };

            firstMatrix = new Matrix2D(arrayFirst);
            secondMatrix = new Matrix2D(arraySecond);

            Matrix2D expected = new(new int[,] { { 1, 1 }, { -1, -1 } });
            Matrix2D actual = Subtraction(firstMatrix, secondMatrix);

            Assert.AreEqual(expected.MatrixArray, actual.MatrixArray);
        }
        [Test]
        public void Matrix2D_Subtraction_Faulty()
        {
            int[,] arrayFirst = { { 2, 2, 2 }, { 1, 1, 1 } };
            int[,] arraySecond = { { 1, 1 }, { 2, 2 } };

            firstMatrix = new Matrix2D(arrayFirst);
            secondMatrix = new Matrix2D(arraySecond);

            Assert.Throws<Matrix2DException>(() => Subtraction(firstMatrix, secondMatrix));
        }

        [Test]
        public void Matrix2D_Multiplication_Success()
        {
            int[,] arrayFirst = { { 1, 1, 1 }, { 2, 2, 2 } };
            int[,] arraySecond = { { 3, 3 }, { 2, 2 }, { 1, 1 } };

            firstMatrix = new Matrix2D(arrayFirst);
            secondMatrix = new Matrix2D(arraySecond);

            Matrix2D expected = new(new int[,] { { 6, 6 }, { 12, 12 } });
            Matrix2D actual = Multiplication(firstMatrix, secondMatrix);

            Assert.AreEqual(expected.MatrixArray, actual.MatrixArray);
        }

        [Test]
        public void Matrix2D_Multiplication_DifferentSizesFaulty()
        {
            int[,] arraySecond = { { 3, 3, 2 }, { 2, 1, 1 } };
            int[,] arrayFirst = { { 1, 1 }, { 2, 2 } };

            firstMatrix = new Matrix2D(arrayFirst);
            secondMatrix = new Matrix2D(arraySecond);

            Assert.Throws<ArgumentNullException>(() => Multiplication(firstMatrix = null, secondMatrix = null));
        }

        [Test]
        public void Matrix2D_MultiplicationOneOrAllParamsAreNull_Faulty()
        {
            Assert.Throws<ArgumentNullException>(() => Multiplication(firstMatrix = null, secondMatrix = null));
            Assert.Throws<ArgumentNullException>(() => Multiplication(firstMatrix = new Matrix2D(1, 1), secondMatrix = null));
            Assert.Throws<ArgumentNullException>(() => Multiplication(firstMatrix = null, secondMatrix = new Matrix2D(1, 1)));
        }

        [Test]
        public void Matrix2D_AdditionOneOrAllParamsAreNull_Faulty()
        {
            Assert.Throws<ArgumentNullException>(() => Addition(firstMatrix = null, secondMatrix = null));
            Assert.Throws<ArgumentNullException>(() => Addition(firstMatrix = new Matrix2D(1, 1), secondMatrix = null));
            Assert.Throws<ArgumentNullException>(() => Addition(firstMatrix = null, secondMatrix = new Matrix2D(1, 1)));
        }
        [Test]
        public void Matrix2D_SubtractionOneOrAllParamsAreNull_Faulty()
        {
            Assert.Throws<ArgumentNullException>(() => Subtraction(firstMatrix = null, secondMatrix = null));
            Assert.Throws<ArgumentNullException>(() => Subtraction(firstMatrix = new Matrix2D(1, 1), secondMatrix = null));
            Assert.Throws<ArgumentNullException>(() => Subtraction(firstMatrix = null, secondMatrix = new Matrix2D(1, 1)));
        }

    }
}