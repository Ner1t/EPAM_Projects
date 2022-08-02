using System;
using System.Collections.Generic;
using Tree;


namespace Generic_Filter
{
    public class Program
    {
        private readonly static List<StudentTestResult> data = new()
        {
            new StudentTestResult("Roman", "Goriachev", "<SQL>-<200>", new DateTime(2021, 05, 11), 2),
            new StudentTestResult("Karsten", "Brill", "<C#>-<100>", new DateTime(2021, 05, 15), 4),
            new StudentTestResult("Evgeny", "Egorov", "<HTML>-<100>", new DateTime(2022, 05, 11), 3),
            new StudentTestResult("Maxim", "Pokrovsky", "<SQL>-<300>", new DateTime(2022, 05, 14), 2),
            new StudentTestResult("Valery", "Kipelov", "<C#>-<200>", new DateTime(2022, 05, 15), 5),
            new StudentTestResult("Karsten", "Brill", "<HTML>-<200>", new DateTime(2022, 06, 12), 1),
            new StudentTestResult("Roman", "Goriachev", "<SQL>-<200>", new DateTime(2022, 06, 13), 5),
            new StudentTestResult("Maxim", "Pokrovsky", "<PYTH<>N>-<300>", new DateTime(2022, 05, 14), 2),
            new StudentTestResult("Maxim", "Pokrovsky", "<1 C>-<300>", new DateTime(2022, 05, 14), 2),
        };

        static void Main(string[] args)
        {
             GenericFilter<StudentTestResult> filter = new();

            var sorces = filter.IsGreaterThan(test => test.FirstName,"rom").Apply(data);

            // var sorces = filter.IsBetween(x => x.Grade, 2, 5).IsEqual(x=>x.Grade,3).Apply(data);       

            // var sorces = filter.PartStringSame(x => x.FirstName, "ro").Apply(data);

            foreach (var i in sorces)
            {
                Console.WriteLine(i);
            }
        }
    }
}