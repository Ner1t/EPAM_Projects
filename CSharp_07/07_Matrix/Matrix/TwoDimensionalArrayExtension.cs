namespace Matrix
{
    public static class TwoDimensionalArrayExtension
    {
        public static void GetDimensions(this double[,] array, out int rows, out int columns)
        {
            rows = array.GetUpperBound(0) + 1;
            columns = array.Length / rows;
        }
    }
}
