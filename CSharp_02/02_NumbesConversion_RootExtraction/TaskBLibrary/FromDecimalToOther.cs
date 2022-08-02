using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumeralSystem
{
    public static class FromDecimalToOther
    {
        public enum BaseSystem { Bin, Oct, Hex, Base32, Base64 }
        private static readonly Encoding utf8 = Encoding.UTF8;

        public static string FromDecimalTo(int number, int system)
        {
            List<string> result = new();
            do
            {
                if (system == 16)
                {
                    result.Add((number % system).ToString("x"));
                }
                else
                {
                    result.Add((number % system).ToString());
                }
                number /= system;

            } while (number != 0);

            result.Reverse();

            return string.Join("", result);
        }

        public static string ToBin(int number)
        {
            return FromDecimalTo(number, 2);
        }

        public static string ToBinBase(int number)
        {
            return Convert.ToString(number, 2);
        }

        public static string ToOct(int number)
        {
            return FromDecimalTo(number, 8);
        }

        public static string ToOctBase(int number)
        {
            return Convert.ToString(number, 8);
        }


        public static string ToHex(int number)
        {
            return FromDecimalTo(number, 16);
        }

        public static string ToHexBase(int number)
        {
            return Convert.ToString(number, 16);
        }

        public static string ToBase32(int number)
        {
            const string Symbols = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";

            StringBuilder result = new();
            string numberString = Convert.ToString(number);

            if (numberString == null) throw new ArgumentNullException(nameof(numberString));

            ushort bb = 0;
            var bits = 0;
            foreach (var ch in numberString)
            {
                bb |= (ushort)((byte)ch << (8 - bits));
                bits += 8;

                for (; bits >= 5; bb <<= 5, bits -= 5)
                {
                    result.Append(Symbols[bb >> 11]);
                }
            }

            if (bits > 0)
                result.Append(Symbols[bb >> 11]);
            return result.ToString();
        }

        public static string ToBase64(int number)
        {
            char[] base64Table = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O',
                                  'P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d',
                                  'e','f','g','h','i','j','k','l','m','n','o','p','q','r','s',
                                  't','u','v','w','x','y','z','0','1','2','3','4','5','6','7',
                                  '8','9','+','/','=' };

            var stringNumber = Convert.ToString(number);

            byte[] data = new byte[stringNumber.Length];

            for (int i = 0; i < stringNumber.Length; i++)
            {
                data[i] = (byte)stringNumber[i];
            }

            var arrayOfBinaryStrings = data.Select(x => Convert.ToString(x, 2).PadLeft(8, '0'));
            int count = arrayOfBinaryStrings.Count();
            var append = count % 3 == 1 ? "==" : count % 3 == 2 ? "=" : "";
            var allBytes = string.Join("", arrayOfBinaryStrings);
            var countOfBytes = allBytes.Length;
            var remOfDivision = countOfBytes % 6;
            var newList = Enumerable.Range(0, countOfBytes / 6).Select(x => allBytes.Substring(x * 6, 6)).ToList();

            if (remOfDivision != 0)
            {
                newList.Add(allBytes.Substring(countOfBytes / 6 * 6, remOfDivision).PadRight(6, '0'));
            }

            return string.Join("", newList.Select(x => base64Table[Convert.ToByte(x, 2)])) + append;
        }

        public static string ToBase64Standard(int number)
        {

            byte[] base64 = utf8.GetBytes(number.ToString());
            return Convert.ToBase64String(base64);
        }
    }
}
