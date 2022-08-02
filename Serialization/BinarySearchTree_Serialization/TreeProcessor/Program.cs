using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Tree;

namespace TreeProcessor
{
    class Program
    {
        public static void BinarySerializationNumbers()
        {
            List<int> data = new()
            {
                1,
                2,
                3,
                4
            };

            IterativeTree<int> treeNumbers = new();

            treeNumbers.AddRange(data);

            BinaryFormatter formatter = new();

            using (FileStream fs = new("treeNumbers.dat", FileMode.OpenOrCreate))
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                formatter.Serialize(fs, treeNumbers);
#pragma warning restore SYSLIB0011 // Type or member is obsolete

                Console.WriteLine("Object has been serialized");
            }

            using (FileStream fs = new("treeNumbers.dat", FileMode.OpenOrCreate))
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                IterativeTree<int> newTreeNumbers = (IterativeTree<int>)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011 // Type or member is obsolete

                Console.WriteLine("Object has been deserialized");
                Console.WriteLine("Tree data:");
                foreach (var i in newTreeNumbers)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void BinarySerializationStudentTestResult()
        {
            List<StudentTestResult> data = new()
            {
                new StudentTestResult("Roman", "Goriachev", "LogicTest", DateTime.Now, 2),
                new StudentTestResult("Roman", "Goriachev", "CommunicationTest", DateTime.Now, 5),
                new StudentTestResult("Roman", "Goriachev", "Testo", DateTime.Now, 6),
                new StudentTestResult("Roman", "Goriachev", "IQTest", DateTime.Now, 3),
                new StudentTestResult("Roman", "Goriachev", "HikkaTest", DateTime.Now, 4)
            };

            IterativeTree<StudentTestResult> treeTests = new();

            treeTests.AddRange(data);

            BinaryFormatter formatter = new();

            using (FileStream fs = new("treeTests.dat", FileMode.OpenOrCreate))
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                formatter.Serialize(fs, treeTests);
#pragma warning restore SYSLIB0011 // Type or member is obsolete

                Console.WriteLine("Object has been serialized");
            }

            using (FileStream fs = new("treeTests.dat", FileMode.OpenOrCreate))
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                IterativeTree<StudentTestResult> newTreeTests = (IterativeTree<StudentTestResult>)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011 // Type or member is obsolete

                Console.WriteLine("Object has been deserialized");
                Console.WriteLine("Tree data:");
                foreach (var i in newTreeTests)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void XmlSerializationIterativeTree()
        {
            List<StudentTestResult> data = new()
            {
                new StudentTestResult("Roman", "Goriachev", "LogicTest", DateTime.Now, 2),
                new StudentTestResult("Roman", "Goriachev", "CommunicationTest", DateTime.Now, 5),
                new StudentTestResult("Roman", "Goriachev", "Testo", DateTime.Now, 6),
                new StudentTestResult("Roman", "Goriachev", "IQTest", DateTime.Now, 3),
                new StudentTestResult("Roman", "Goriachev", "HikkaTest", DateTime.Now, 4)
            };

            IterativeTree<StudentTestResult> iterativeTree = new();

            iterativeTree.AddRange(data);

            XmlSerializer xmlSerializer = new(typeof(IterativeTree<StudentTestResult>));

            using (FileStream fs = new("iterativeTree.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, iterativeTree);

                Console.WriteLine("Object has been serialized");
            }

            using (FileStream fs = new("iterativeTree.xml", FileMode.OpenOrCreate))
            {
                IterativeTree<StudentTestResult> newIterativeTree = xmlSerializer.Deserialize(fs) as IterativeTree<StudentTestResult>;

                Console.WriteLine("Object has been deserialized");
                Console.WriteLine($"RootNode: {newIterativeTree.RootNode}  MinNode: {newIterativeTree.GetMin()} MaxNode: {newIterativeTree.GetMax()}");
            }
        }

        public static void XmlSerializationRecursiveTree()
        {
            List<StudentTestResult> data = new()
            {
                new StudentTestResult("Roman", "Goriachev", "LogicTest", DateTime.Now, 2),
                new StudentTestResult("Roman", "Goriachev", "CommunicationTest", DateTime.Now, 5),
                new StudentTestResult("Roman", "Goriachev", "Testo", DateTime.Now, 6),
                new StudentTestResult("Roman", "Goriachev", "IQTest", DateTime.Now, 3),
                new StudentTestResult("Roman", "Goriachev", "HikkaTest", DateTime.Now, 4)
            };

            RecursiveTree<StudentTestResult> recursiveTree = new();

            recursiveTree.AddRange(data);

            XmlSerializer xmlSerializer = new(typeof(RecursiveTree<StudentTestResult>));

            using (FileStream fs = new("recursiveTree.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, recursiveTree);

                Console.WriteLine("Object has been serialized");
            }

            using (FileStream fs = new("recursiveTree.xml", FileMode.OpenOrCreate))
            {
                RecursiveTree<StudentTestResult> newRecursiveTree = xmlSerializer.Deserialize(fs) as RecursiveTree<StudentTestResult>;

                Console.WriteLine("Object has been deserialized");
                Console.WriteLine($"RootNode: {newRecursiveTree.RootNode}  MinNode: {newRecursiveTree.GetMin()} MaxNode: {newRecursiveTree.GetMax()}");
            }
        }

        static void Main(string[] args)
        {
            BinarySerializationNumbers();

            BinarySerializationStudentTestResult();

            XmlSerializationIterativeTree();

            XmlSerializationRecursiveTree();
        }
    }
}
