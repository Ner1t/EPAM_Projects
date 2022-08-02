using System;

namespace Tree
{
    public class StudentTestResult : IComparable<StudentTestResult>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string TestName { get; init; }
        public DateTime ExamDate { get; init; }
        public int Grade { get; init; }

        public StudentTestResult(string firstName, string lastName, string testName, DateTime examDate, int grade)
        {
            FirstName = firstName;
            LastName = lastName;
            TestName = testName;
            ExamDate = examDate;
            Grade = grade;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode() + TestName.GetHashCode();
        }

        public override string ToString()
        {
            return FirstName + ' ' + LastName + ' ' + TestName + " Grade:" + Grade.ToString() + ' ' + ExamDate.ToLongDateString();
        }

        public int CompareTo(StudentTestResult other)
        {
            return FirstName == other.FirstName &&
                LastName == other.LastName &&
                TestName == other.TestName &&
                ExamDate == other.ExamDate &&
                Grade == other.Grade ? 0
            : Grade < other.Grade ? -1 :
            string.Compare(FirstName, other.FirstName) == -1 ? -1 :
            string.Compare(LastName, other.LastName) == -1 ? -1 :
            string.Compare(TestName, other.TestName) == -1 ? -1 :
            ExamDate < other.ExamDate ? -1 : 1;

            //  return Grade == other.Grade ? 0 : Grade < other.Grade ? -1 : 1;
        }

    }
}
