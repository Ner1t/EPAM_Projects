using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tree
{
    public static class TreeExtension
    {
        public static DateTime GetFirstExamDate(this IEnumerable<StudentTestResult> data)
        {
            var list = data.OrderBy(p => p).Select(p => p.ExamDate.Date);

            return list.First();
        }

        public static int GetTestsPerYear(this IEnumerable<StudentTestResult> data, DateTime date)
        {
            var result = data.Count(p => p.ExamDate.Year == date.Year);

            return result;
        }

        public static IEnumerable<int> GetThreeMaxGrades(this IEnumerable<StudentTestResult> data)
        {
            var result = data.Select(p => p.Grade).OrderByDescending(p => p).Take(3);
            return result;
        }

        public static IEnumerable<string> GetAllStudentsNames(this IEnumerable<StudentTestResult> data)
        {
            var result = data.Select(p => p.GetFullName).OrderBy(p => p).Distinct();
            return result;
        }

        public static IEnumerable<string> GetStudentsFourFiveGrades(this IEnumerable<StudentTestResult> data)
        {
            var result = data.GroupBy(x => x.GetFullName).Where(x => x.All(y => y.Grade >= 4)).Select(p => p.Key);
            return result;
        }

        public static IEnumerable<string> GetTwoScoreTests(this IEnumerable<StudentTestResult> data)
        {
            var result = data.Where(p => p.Grade == 2).Select(p => p.TestName).Distinct();
            return result;
        }

        public static IEnumerable<(string, double)> GetAverageScoreEachStudent(this IEnumerable<StudentTestResult> data)
        {
            var result = data
                     .GroupBy(p => p.GetFullName)
                     .Select(g => new
                     {
                         Name = g.Key,
                         Average = g.Average(p => p.Grade)
                     });

            // var result = data.GroupBy(p => p.FirstName + p.LastName, g=>g.Grade ,(Name, Grade) => new {StudName = Name, Average = Grade.Average()  });

            foreach (var item in result)
            {
                yield return (item.Name, item.Average);
            }
        }

        public static IEnumerable<int> GetTestResultsSpecificMonth(this IEnumerable<StudentTestResult> data, DateTime date)
        {
            var result = data.Where(p => p.ExamDate.Month == date.Month && p.ExamDate.Year == date.Year)
                .Select(p => p.Grade);
            return result;
        }

        public static IEnumerable<string> GetPatternMismatchTestName(this IEnumerable<StudentTestResult> data)
        {
            var rx = new Regex(@"^<[^<>\s]{2,}>-<(100|200|300)>$");

            var result = data
                .Where(p => !rx.IsMatch(p.TestName))
                .Select(p => p.TestName).Distinct();
            return result;
        }

        public static IEnumerable<(string, string[])> GetTestsTakenStudent(this IEnumerable<StudentTestResult> data)
        {
            var result = data.GroupBy(x => x.GetFullName, t => t.TestName,
                (Name, Tests) => new
                {
                    StudentName = Name,
                    TestName = Tests.Distinct()
                });

            foreach (var item in result)
            {
                yield return (item.StudentName, item.TestName.ToArray());
            }
        }

        public static IEnumerable<(string, string[])> GetTestsRetaken(this IEnumerable<StudentTestResult> data)
        {
            var resultTests = data.GroupBy(n => n.GetFullName, t => t.TestName,
               (Name, Tests) =>
               {
                   var testsRetaken = Tests.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key).ToArray();

                   return (Name, testsRetaken);

               }).Where(x => x.testsRetaken != Array.Empty<string>());

            return resultTests;
        }

        public static IEnumerable<string> GetTestsNotThisYear(this IEnumerable<StudentTestResult> data, DateTime date)
        {
            var result = data.Where(q => q.ExamDate.Year != date.Year).Select(q => q.TestName).Distinct();
            return result;
        }
    }
}
