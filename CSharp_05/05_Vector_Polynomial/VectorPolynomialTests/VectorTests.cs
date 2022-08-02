using NUnit.Framework;
using Vector;

namespace VectorPolynomialTests
{
    public class VectorTests
    {
        private Vector3D firstVector;
        private Vector3D secondVector;

        [SetUp]
        public void Setup()
        {
            firstVector = new Vector3D(1, 2, 3);
            secondVector = new Vector3D(4, 5, 6);
        }

        [Test]
        public void Vector3D_Sum_Success()
        {
            Vector3D newVector = firstVector + secondVector;

            Assert.IsTrue(newVector.X == 5);
            Assert.IsTrue(newVector.Y == 7);
            Assert.IsTrue(newVector.Z == 9);
        }

        [Test]
        public void Vector3D_Subtraction_Success()
        {
            Vector3D newVector = secondVector - firstVector;

            Assert.IsTrue(newVector.X == 3);
            Assert.IsTrue(newVector.Y == 3);
            Assert.IsTrue(newVector.Z == 3);
        }

        [TestCase(0, 0, 0)]
        [TestCase(int.MinValue, int.MinValue, int.MinValue)]
        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue)]
        public void Vector3D_BoundaryValues_Fault(int firstValue, int secondValue, int thirdValue)
        {
            Vector3D actual = new(firstValue, secondValue, thirdValue);
            double coordinatesSum = (actual.X + actual.Y + actual.Z);

            Assert.True(coordinatesSum == 0 ? true : coordinatesSum == 6442450941 ? true : coordinatesSum == -6442450944 ? true : false);
        }

        [Test]
        public void Vector3D_ScalarProduct_Success()
        {
            double actual = firstVector * secondVector;

            Assert.AreEqual(32, actual);
        }
        [Test]
        public void Vector3D_Compare_NotSame()
        {
            bool actual = secondVector == firstVector;

            Assert.False(actual);
        }
        [Test]
        public void Vector3D_Compare_Same()
        {
            bool actual = secondVector == new Vector3D(4, 5, 6);

            Assert.IsTrue(actual);
        }
    }
}