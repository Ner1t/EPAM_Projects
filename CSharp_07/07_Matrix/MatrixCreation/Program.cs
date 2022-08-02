using Matrix;
using System;
using static Matrix.TwoDimensionalArrayExtension;
using static MatrixCreation.Matrix2D;


namespace MatrixCreation
{
    public class Program
    {
        public static void MatrixProcessor()
        {
            Console.WriteLine("The program performs addition, subtraction and multiplication operations between two input matrices.\n");
            Console.WriteLine("Enter the dimensions SEPARATED BY A SPACE of the first matrix : the first is the number of rows and the second is the number of" +
                " columns, or press Enter to exit the program.\n");
            Console.WriteLine("Attention! For successful addition and subtraction, the size of the matrices must be equal," +
                " and for successful multiplication, the number of columns of the first matrix must be exactly the number of" +
                " rows of the second matrix!");
            Console.WriteLine();
            string dimensionsFirst = Console.ReadLine();
            Console.WriteLine();
            if (dimensionsFirst != "")
            {
                Console.WriteLine("Enter the dimensions SEPARATED BY A SPACE of the second matrix:");
                string dimensionsSecond = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter the numbers SEPARATED BY A SPACE to be stored in the first matrix.");
                string numbersFirst = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter the numbers SEPARATED BY A SPACE to be stored in the second matrix.");

                string numbersSecond = Console.ReadLine();

                Parser(numbersFirst, dimensionsFirst, out int[,] arrayFirst);
                Parser(numbersSecond, dimensionsSecond, out int[,] arraySecond);

                try
                {
                    _ = arrayFirst ?? throw new ArgumentNullException(" is null", nameof(arrayFirst));
                    _ = arraySecond ?? throw new ArgumentNullException(" is null", nameof(arraySecond));

                    Matrix2D matrixFirst = new(arrayFirst);
                    Matrix2D matrixSecond = new(arraySecond);

                    matrixFirst.MatrixArray.GetDimensions(out int rowsFirst, out int columnsFirst);

                    matrixSecond.MatrixArray.GetDimensions(out int rowsSecond, out int columnsSecond);

                    Console.WriteLine("Result of multiplication");
                    Console.WriteLine(Multiplication(matrixFirst, matrixSecond).ToString());

                    Console.WriteLine("Result of addition:");
                    Console.WriteLine(Addition(matrixFirst, matrixSecond).ToString());

                    Console.WriteLine("Result of subtraction:");
                    Console.WriteLine(Subtraction(matrixFirst, matrixSecond).ToString());
                }
                catch (Matrix2DException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void Parser(string numbersStr, string dimensionsStr, out int[,] array)
        {
            string[] arrayNumbers = numbersStr.Split(" ");
            string[] arrayDimensions = dimensionsStr.Split(" ");

            if (arrayDimensions.Length == 2)
            {
                if (int.TryParse(arrayDimensions[0], out int row) && int.TryParse(arrayDimensions[1], out int column))
                {
                    array = new int[row, column];
                    int arrayNumbersIndex = 0;

                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < column; j++)
                        {
                            if (arrayNumbers.Length > arrayNumbersIndex)
                            {
                                if (int.TryParse(arrayNumbers[arrayNumbersIndex], out array[i, j]))
                                {
                                    arrayNumbersIndex++;
                                }
                                else
                                {
                                    array = default;
                                    break;
                                }
                            }
                        }
                        if (array is null)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    array = default;
                }
            }
            else
            {
                array = default;
            }
        }

        static void Main(string[] args)
        {
            MatrixProcessor();
        }
    }
}
