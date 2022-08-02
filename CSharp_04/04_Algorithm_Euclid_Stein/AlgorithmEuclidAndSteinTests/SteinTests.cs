using NUnit.Framework;


namespace AlgorithmEuclidAndSteinTests
{
    public class SteinTests
    {
        [Test]
        public void TestProcessorLogic_FirstEqualsSecondEuclid_Success()
        {

            int[] mass = new int[] { 4, 4 };

            int expected = 4;
            int actual = AlgorithmEuclidAndStein.Stein.CalculateGcd(mass[0], mass[1]);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestProcessorLogic_FirstGreaterSecond_Success()
        {
            int[] mass = new int[2] { 8, 4 };

            var expected = 4;
            var actual = AlgorithmEuclidAndStein.Stein.CalculateGcd(mass[0], mass[1]);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestProcessorLogic_FirstLessSecond_Success()
        {
            int[] mass = new int[2] { 4, 8 };

            var expected = 4;
            var actual = AlgorithmEuclidAndStein.Stein.CalculateGcd(mass[0], mass[1]);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestProcessorLogic_InputBoundaryParameters_Failure()
        {
            int[] massMin = new int[1] { 4 };
            int[] massMax = new int[21] { 4, 8, 15, 16, 23, 42, 4, 8, 15, 16, 23, 42, 4, 8, 15, 16, 23, 42, 4, 8, 15 };

            var actualMin = AlgorithmEuclidAndStein.Stein.CalculateGcd(massMin);
            var actualMax = AlgorithmEuclidAndStein.Stein.CalculateGcd(massMax);
            int expectedMin = default;
            int expectedMax = default;

            Assert.AreEqual(expectedMin & expectedMax, actualMin & actualMax);
        }
        [Test]
        public void TestProcessorLogic_AllNumbersEven_Success()
        {
            int[] mass = new int[10] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

            var actual = AlgorithmEuclidAndStein.Stein.CalculateGcd(mass);
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestProcessorLogic_AllNumbersOdd_Success()
        {
            int[] mass = new int[10] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };

            var actual = AlgorithmEuclidAndStein.Stein.CalculateGcd(mass);
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestProcessorLogic_FirstFivePrimeNumbersWithoutOne_Success()
        {
            int[] mass = new int[5] { 2, 3, 5, 7, 11 };

            var actual = AlgorithmEuclidAndStein.Stein.CalculateGcd(mass[0], mass[1], mass[2], mass[3], mass[4]);
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestProcessorLogic_ThreeNumbers_Success()
        {
            int[] mass = new int[3] { 1, 3, 8 };

            var actual = AlgorithmEuclidAndStein.Stein.CalculateGcd(mass[0], mass[1], mass[2]);
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestProcessorLogic_FourNumbers_Success()
        {
            int[] mass = new int[4] { 2, 9, 9, 7 };

            var actual = AlgorithmEuclidAndStein.Stein.CalculateGcd(mass[0], mass[1], mass[2], mass[3]);
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestProcessorLogic_FiveNumbers_Success()
        {
            int[] mass = new int[5] { 1, 6, 7, 2, 6 };

            var actual = AlgorithmEuclidAndStein.Stein.CalculateGcd(mass[0], mass[1], mass[2], mass[3], mass[4]);
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestProcessorLogic_FifteenNumbers_Success()
        {
            int[] mass = new int[15] { 4, 6, 6, 9, 2, 0, 1, 6, 0, 9, 1, 0, 2, 9, 9 };

            var actual = AlgorithmEuclidAndStein.Stein.CalculateGcd(mass);
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }
    }
}