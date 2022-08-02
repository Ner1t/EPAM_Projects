using System.Globalization;
using System.Linq;

namespace PointProcessor
{
    public static class Parser
    {
        public static bool TryParsePoint(string line, out Point point)
        {
            point = null;
            if (string.IsNullOrEmpty(line) || line.Any(char.IsLetter))
            {
                return false;
            }

            var strings = line.Split(',');

            if (strings.Length != 2)
            {
                return false;
            }

            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");


            if (decimal.TryParse(strings[0], style, culture, out decimal x) && decimal.TryParse(strings[1], style, culture, out decimal y))
            {
                point = new Point(x, y);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
