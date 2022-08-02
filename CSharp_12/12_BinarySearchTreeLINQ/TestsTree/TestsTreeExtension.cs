using NUnit.Framework;
using System;
using System.Collections.Generic;
using Tree;
using static Tree.TreeExtension;

namespace TestsTree
{
    public class TestsTreeExtension
    {
        public readonly static List<StudentTestResult> data = new()
        {
            new StudentTestResult("Roman", "Goriachev", "<SQL>-<200>", new DateTime(2021, 05, 11), 2),
            new StudentTestResult("Karsten", "Brill", "<HTML>-<200>", new DateTime(2021, 05, 15), 4),
            new StudentTestResult("Evgeny", "Egorov", "<HTML>-<100>", new DateTime(2022, 05, 11), 3),
            new StudentTestResult("Maxim", "Pokrovsky", "<SQL>-<300>", new DateTime(2022, 05, 14), 2),
            new StudentTestResult("Valery", "Kipelov", "<C#>-<200>", new DateTime(2022, 05, 15), 5),
            new StudentTestResult("Karsten", "Brill", "<HTML>-<200>", new DateTime(2022, 06, 12), 1),
            new StudentTestResult("Roman", "Goriachev", "<SQL>-<200>", new DateTime(2022, 06, 13), 5),
            new StudentTestResult("Maxim", "Pokrovsky", "<PYTH<>N>-<300>", new DateTime(2022, 05, 14), 2),
            new StudentTestResult("Maxim", "Pokrovsky", "<1 C>-<300>", new DateTime(2022, 05, 14), 1),
            new StudentTestResult("Roman", "Goriachev", "<1 C>-<300>", new DateTime(2021, 05, 11), 4),

        };

        [Test]
        public void Tree_DateOfTests_Success()
        {
            RecursiveTree<StudentTestResult> recursiveTree = new();
            recursiveTree.AddRange(data);

            var expected = new DateTime(2021, 05, 11);
            var actual = recursiveTree.GetFirstExamDate();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_TestsPerYear_Success()
        {
            RecursiveTree<StudentTestResult> recursiveTree = new();
            recursiveTree.AddRange(data);

            int expected = 7;
            int actual = recursiveTree.GetTestsPerYear(DateTime.Now);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_ThreeMaxGrades_Success()
        {
            RecursiveTree<StudentTestResult> recursiveTree = new();
            recursiveTree.AddRange(data);

            string expected = "554";
            string actual = "";

            foreach (var grade in recursiveTree.GetThreeMaxGrades())
            {
                actual += grade;
            }

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_NameAllStudents_Success()
        {
            RecursiveTree<StudentTestResult> recursiveTree = new();
            recursiveTree.AddRange(data);

            string expected = "Evgeny EgorovKarsten BrillMaxim PokrovskyRoman GoriachevValery Kipelov";
            string actual = "";

            foreach (var names in recursiveTree.GetAllStudentsNames())
            {
                actual += names;
            }

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_StudentsFourFiveGrades_Success()
        {
            RecursiveTree<StudentTestResult> recursiveTree = new();
            recursiveTree.AddRange(data);

            string expected = "Valery Kipelov";
            string actual = "";

            foreach (var i in recursiveTree.GetStudentsFourFiveGrades())
            {
                actual += i;
            }

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_TwoscoreTests_Success()
        {
            RecursiveTree<StudentTestResult> recursiveTree = new();
            recursiveTree.AddRange(data);

            string expected = "<PYTH<>N>-<300><SQL>-<300><SQL>-<200>";


            string actual = default;

            foreach (var testsName in recursiveTree.GetTwoScoreTests())
            {
                actual += testsName;
            }
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_AverageScoreEachStudent_Success()
        {
            RecursiveTree<StudentTestResult> recursiveTree = new();
            recursiveTree.AddRange(data);

            string expected = "(Roman Goriachev, 3,6666666666666665)(Maxim Pokrovsky, 1,6666666666666667)(Karsten Brill, 2,5)(Valery Kipelov, 5)(Evgeny Egorov, 3)";
            string actual = "";

            foreach (var nameAndAverage in recursiveTree.GetAverageScoreEachStudent())
            {
                actual += nameAndAverage;
            }

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_TestResultsSpecificMonth_Success()
        {
            RecursiveTree<StudentTestResult> recursiveTree = new();
            recursiveTree.AddRange(data);

            string expected = "15";
            string actual = "";

            foreach (var grade in recursiveTree.GetTestResultsSpecificMonth(DateTime.Now))
            {
                actual += grade;
            }

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_PatternMismatchTestName_Success()
        {
            RecursiveTree<StudentTestResult> recursiveTree = new();
            recursiveTree.AddRange(data);

            string expected = "<1 C>-<300><PYTH<>N>-<300>";
            string actual = "";

            foreach (var testName in recursiveTree.GetPatternMismatchTestName())
            {
                actual += testName;
            }

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_TestsTakenStudent()
        {
            RecursiveTree<StudentTestResult> recursiveTree = new();
            recursiveTree.AddRange(data);

            string expected = "Roman Goriachev<1 C>-<300><SQL>-<200>Maxim Pokrovsky<1 C>-<300><PYTH<>N>-<300><SQL>-<300>" +
                "Karsten Brill<HTML>-<200>Valery Kipelov<C#>-<200>Evgeny Egorov<HTML>-<100>";
            string actual = default;

            foreach (var item1Name_Item2Tests in recursiveTree.GetTestsTakenStudent())
            {
                actual += item1Name_Item2Tests.Item1;
                foreach (var test in item1Name_Item2Tests.Item2)
                {
                    actual += test;
                }
            }
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_TestsRetaken_Success()
        {
            RecursiveTree<StudentTestResult> recursiveTree = new();
            recursiveTree.AddRange(data);

            string expected = "Roman Goriachev<SQL>-<200>Karsten Brill<HTML>-<200>";
            string actual = "";

            foreach (var item1Name_Item2Tests in recursiveTree.GetTestsRetaken())
            {
                actual += item1Name_Item2Tests.Item1;
                foreach (var test in item1Name_Item2Tests.Item2)
                {
                    actual += test;
                }
            }

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Tree_TestsNotThisYear_Success()
        {
            RecursiveTree<StudentTestResult> recursiveTree = new();
            recursiveTree.AddRange(data);

            string expected = "<1 C>-<300><HTML>-<200><SQL>-<200>";
            string actual = "";

            foreach (var testName in recursiveTree.GetTestsNotThisYear(DateTime.Now))
            {
                actual += testName;
            }

            Assert.AreEqual(expected, actual);
        }
    }
}








