using System;
using System.Text;
using static NumeralSystem.FromDecimalToOther;

namespace NumeralSystemUI
{
    class Program
    {

        public static void ConsoleProcessor()
        {
            StringBuilder baseSystem = new();

            foreach (BaseSystem b in Enum.GetValues<BaseSystem>())
            {
                baseSystem.Append(b + " ");
            }

            Console.WriteLine($"The program for converting numbers from the decimal system to {baseSystem}");
            Console.WriteLine("Enter the number to be converted:");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                foreach (int i in Enum.GetValues<BaseSystem>())
                {

                    ToBase(number, i, out string result, out string resultStandard);

                    if (string.IsNullOrEmpty(resultStandard))
                    {
                        Console.WriteLine($"{(BaseSystem)i}. Only own implementation: " + result);
                    }

                    else if (Equals(result, resultStandard))
                    {
                        Console.WriteLine(string.Concat($"{(BaseSystem)i}. Own implementation: " + result + " " + "Standart: " + resultStandard + " Results are equal."));
                    }
                    else
                    {
                        Console.WriteLine(string.Concat($"{(BaseSystem)i}. Own implementation: " + result + " " + "Standart: " + resultStandard + " Results are not equal."));
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect input");
                return;
            }
        }
        public static void ToBase(int number, int option, out string result, out string resultStandart)
        {
            result = default;
            resultStandart = default;

            switch (option)
            {
                case 0:

                    {
                        result = ToBin(number);
                        resultStandart = ToBinBase(number);
                        break;
                    }

                case 1:

                    {
                        result = ToOct(number);
                        resultStandart = ToOctBase(number);
                        break;
                    }
                case 2:

                    {
                        result = ToHex(number);
                        resultStandart = ToHexBase(number);
                        break;
                    }
                case 3:

                    {
                        result = ToBase32(number);
                        resultStandart = default;
                        break;
                    }

                case 4:

                    {
                        result = ToBase64(number);
                        resultStandart = ToBase64Standard(number);
                        break;
                    }
            }

        }
        static void Main(string[] args)
        {
            ConsoleProcessor();

        }
    }
}
