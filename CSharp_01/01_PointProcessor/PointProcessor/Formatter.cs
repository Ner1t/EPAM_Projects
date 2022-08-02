using System.Globalization;

namespace PointProcessor
{
    public class Formatter
    {
        public static string Format(Point point)
        {
            if (point == null)
            {
                return default;
            }

            string points = string.Format(CultureInfo.CreateSpecificCulture("ru-RU"), "X: {0,4:###0}{1,-5:.0###}" + " " + "Y: {2,4:###0}{3,-5:.0###}",
                decimal.Truncate(point.X), point.X % 1,
                decimal.Truncate(point.Y), point.Y % 1);

            return points;
        }
    }
}
