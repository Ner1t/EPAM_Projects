using NUnit.Framework;
using TriangleProcessor;
using static TriangleProcessor.Triangle;

namespace TriangleTests
{

    [TestFixture]
    public class ProcessorTests
    {
        [Test]
        public void TestTriangle_CreateTriangleToString_Success()
        {
            string expected = "Triangle: side a = 4 side b = 3 side c = 5 Area -> 6 Perimeter -> 12";

            Triangle actual = CreationTriangle(4, 3, 5);

            Assert.AreEqual(expected, actual.ToString());
        }

        [Test]
        public void TestExistenceCheck_CreateTriangleImpossible_Fault()
        {
            Assert.IsNull(CreationTriangle(3, 1, 5));
        }

        [Test]
        public void TestTriangle_CreateTriangleCheckingSides_Success()
        {
            int[] expected = new[] { 4, 5, 6 };

            Triangle actual = CreationTriangle(4, 5, 6);

            Assert.AreEqual(expected[0], actual.A);
            Assert.AreEqual(expected[1], actual.B);
            Assert.AreEqual(expected[2], actual.C);

        }

        [TestCase(0, int.MinValue, int.MaxValue)]
        [TestCase(int.MinValue, 0, int.MaxValue)]
        [TestCase(int.MaxValue, int.MaxValue, 0)]
        public void TestTriangle_BoundaryValues_Fault(int firstValue, int secondValue, int thirdValue)
        {
            Assert.IsNull(CreationTriangle(firstValue, secondValue, thirdValue));
        }

        [Test]
        public void TestTriangle_GetArea_Success()
        {
            double expected = 9.92;

            Triangle actual = CreationTriangle(4, 5, 6);

            Assert.AreEqual(expected, actual.GetArea(), 0.01);
        }

        [Test]
        public void TestTriangle_GetPerimeter_Success()
        {
            double expected = 15;

            Triangle actual = CreationTriangle(4, 5, 6);

            Assert.AreEqual(expected, actual.GetPerimeter());
        }
    }
}