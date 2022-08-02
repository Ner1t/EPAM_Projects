using System;
using System.IO;

namespace PointProcessor
{
    public class Processor
    {
        public static void ProcessFiles(string[] filenames)
        {
            try
            {
                foreach (var file in filenames)
                {
                    var fi1 = new FileInfo(file);

                    using (StreamReader read = fi1.OpenText())
                    {
                        var s = "";
                        while ((s = read.ReadLine()) != null)
                        {
                            Console.WriteLine(ProcessLine(s));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("I/O error\n" + e.Message);
            }
        }
        public static void ProcessConsole()
        {
            Console.WriteLine("Enter a couple of values separated by commas or press Enter to exit the program.");

            string temp;
            string input;
            do
            {

                if ((string.IsNullOrEmpty(input = Console.ReadLine())))

                { break; }

                Console.WriteLine(temp = ProcessLine(input));
                if (temp == null)
                {
                    Console.WriteLine("Invalid input");
                }
            } while (!string.IsNullOrEmpty(temp));


        }

        public static string ProcessLine(string line)
        {

            if (Parser.TryParsePoint(line, out Point point))
            {
                return Formatter.Format(point);
            }

            else if (string.IsNullOrEmpty(line))
            {
                return null;
            }
            else
            {
                return null;
            }

        }
    }
}
