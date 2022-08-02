using System;
using static _08_FileWorker.FileWorker;

namespace _08_FileWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "[01] Привет мир!";

            FileWorker file = Create("test.txt", text.Length);
            try
            {
                for (int i = 0; i < text.Length; i++)
                {
                    file[i] = text[i];
                }
            }
            finally
            {
                file?.Dispose();
            }

            using (file = Read())
            {
                for (int i = 0; i < text.Length; i++)
                {
                    Console.Write(file[i]);
                }
                Console.WriteLine();
            }

            using (file = Read())
            {
                file[2] = '2';
            }

            using (file = Read())
            {
                for (int i = 0; i < text.Length; i++)
                {
                    System.Console.Write(file[i]);
                }
            }
        }
    }
}
