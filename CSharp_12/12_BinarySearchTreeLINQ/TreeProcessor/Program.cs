using System;
using Tree;

namespace TreeProcessor
{
    public class Program
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
            //recursiveTree.AddRange(data);
            //foreach (var i in recursiveTree.TestsTakenStudent())
            //{
            //    Console.WriteLine(i);
            //}
        }
    }
}
