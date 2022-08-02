using System;
using System.Collections.Generic;
using Tree;

namespace TreeProcessor
{
    class Program
    {
        public static void PrintTree(Node<StudentTestResult> startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                string nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data}");
                indent += new string(' ', 3);

                PrintTree(startNode.LeftNode, indent, Side.Left);
                PrintTree(startNode.RightNode, indent, Side.Right);
            }
        }

        static void Main(string[] args)
        {
            //RecursiveTree<StudentTestResult> recursiveTree = new();
            //IterativeTree<StudentTestResult> iterativeTree = new();

            //List<StudentTestResult> data = new()
            //{
            //    new StudentTestResult("Roman", "Goriachev", "SQL-200", new DateTime(2022, 05, 11), 2),
            //    new StudentTestResult("Maria", "Goriacheva", "C#-100", new DateTime(2022, 05, 15), 4),
            //    new StudentTestResult("Evgeny", "Egorov", "HTML-100", new DateTime(2022, 05, 11), 3),
            //    new StudentTestResult("Maxim", "Pokrovsky", "SQL-300", new DateTime(2022, 05, 14), 9),
            //    new StudentTestResult("Valery", "Kipelov", "C#-100", new DateTime(2022, 05, 15), 7),
            //    new StudentTestResult("Attila", "Dorn", "HTML-200", new DateTime(2022, 05, 12), 8),
            //    new StudentTestResult("Natalia", "O'Shea", "SQL-200", new DateTime(2022, 05, 13), 10)
            //};

            //recursiveTree.AddRange(data);
            //PrintTree(recursiveTree.RootNode);

            //Console.WriteLine(recursiveTree.Remove(data[1]));
            //PrintTree(recursiveTree.RootNode);
        }
    }
}
