using Matrix;
using System;
using System.Text;
using static Matrix.TwoDimensionalArrayExtension;

namespace MatrixCreation
{

    public class Matrix2D : IEquatable<Matrix2D>
    {
        public double[,] MatrixArray { get; private set; }

        public Matrix2D(int row, int column)
        {
            MatrixArray = new double[row, column];
        }

        public Matrix2D(int[,] array)
        {

            int rows = array.GetUpperBound(0) + 1;
            int columns = array.Length / rows;

            MatrixArray = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    MatrixArray[i, j] = array[i, j];
                }
            }
        }
        public double this[int i, int j]
        {
            get
            { return MatrixArray[i, j]; }

            set { MatrixArray[i, j] = value; }
        }
        public string GetDimensions()
        {
            int rows = MatrixArray.GetUpperBound(0) + 1;
            int columns = MatrixArray.Length / rows;

            return $"Number of rows is: {rows} number of columns is: {columns}";
        }

        public Matrix2D Addition(Matrix2D secondMatrix)
        {
            _ = secondMatrix ?? throw new ArgumentNullException(nameof(secondMatrix), "Second matrix is null");

            MatrixArray.GetDimensions(out int rowsFirst, out int columnsFirst);
            secondMatrix.MatrixArray.GetDimensions(out int rowsSecond, out int columnsSecond);

            if (rowsFirst != rowsSecond || columnsFirst != columnsSecond)
            {
                throw new Matrix2DException($"The dimensions of both matrices must be the same!", rowsFirst, columnsFirst, rowsSecond, columnsSecond);
            }

            double[,] result = new double[rowsFirst, columnsSecond];

            for (int row = 0; row < rowsFirst; row++)
            {
                for (int column = 0; column < columnsSecond; column++)
                {
                    result[row, column] = this[row, column] + secondMatrix[row, column];
                }
            }

            return new Matrix2D(rowsFirst, columnsSecond) { MatrixArray = result };

        }

        public static Matrix2D Addition(Matrix2D firstMatrix, Matrix2D secondMatrix)
        {
            _ = firstMatrix ?? throw new ArgumentNullException(nameof(firstMatrix), "First matrix is null");
            _ = secondMatrix ?? throw new ArgumentNullException(nameof(secondMatrix), "Second matrix is null");

            firstMatrix.MatrixArray.GetDimensions(out int rowsFirst, out int columnsFirst);
            secondMatrix.MatrixArray.GetDimensions(out int rowsSecond, out int columnsSecond);

            if (rowsFirst != rowsSecond || columnsFirst != columnsSecond)
            {
                throw new Matrix2DException($"The dimensions of both matrices must be the same!", rowsFirst, columnsFirst, rowsSecond, columnsSecond);
            }

            return firstMatrix.Addition(secondMatrix);
        }


        public Matrix2D Subtraction(Matrix2D secondMatrix)
        {
            _ = secondMatrix ?? throw new ArgumentNullException(nameof(secondMatrix), "Second matrix is null");

            MatrixArray.GetDimensions(out int rowsFirst, out int columnsFirst);
            secondMatrix.MatrixArray.GetDimensions(out int rowsSecond, out int columnsSecond);

            if (rowsFirst != rowsSecond || columnsFirst != columnsSecond)
            {
                throw new Matrix2DException($"The dimensions of both matrices must be the same!", rowsFirst, columnsFirst, rowsSecond, columnsSecond);
            }

            double[,] result = new double[rowsFirst, columnsSecond];
            for (int row = 0; row < rowsFirst; row++)
            {
                for (int column = 0; column < columnsSecond; column++)
                {
                    result[row, column] = this[row, column] - secondMatrix[row, column];
                }
            }
            return new Matrix2D(rowsFirst, columnsSecond) { MatrixArray = result };
        }

        public static Matrix2D Subtraction(Matrix2D firstMatrix, Matrix2D secondMatrix)
        {
            _ = firstMatrix ?? throw new ArgumentNullException(nameof(firstMatrix), "First matrix is null");
            _ = secondMatrix ?? throw new ArgumentNullException(nameof(secondMatrix), "Second matrix is null");

            firstMatrix.MatrixArray.GetDimensions(out int rowsFirst, out int columnsFirst);
            secondMatrix.MatrixArray.GetDimensions(out int rowsSecond, out int columnsSecond);

            if (rowsFirst != rowsSecond || columnsFirst != columnsSecond)
            {
                throw new Matrix2DException($"The dimensions of both matrices must be the same!", rowsFirst, columnsFirst, rowsSecond, columnsSecond);
            }

            return firstMatrix.Subtraction(secondMatrix);
        }

        public Matrix2D Multiplication(Matrix2D secondMatrix)
        {
            _ = secondMatrix ?? throw new ArgumentNullException(nameof(secondMatrix), "Second matrix is null");

            MatrixArray.GetDimensions(out int rowsFirst, out int columnsFirst);
            secondMatrix.MatrixArray.GetDimensions(out int rowsSecond, out int columnsSecond);

            if (columnsFirst != rowsSecond)
            {
                throw new Matrix2DException("The number of rows of the matrix passed in the parameters must be equal to the number of columns " +
                    "of the called matrix", rowsFirst, columnsFirst, rowsSecond, columnsSecond);
            }
            double[,] result = new double[rowsFirst, columnsSecond];

            double temp = 0;

            for (int row = 0; row < rowsFirst; row++)
            {
                for (int column = 0; column < columnsSecond; column++)
                {
                    for (int value = 0; value < rowsSecond; value++)
                    {
                        temp += this[row, value] * secondMatrix[value, column];
                    }
                    result[row, column] = temp;
                    temp = 0;
                }
            }

            return new Matrix2D(rowsFirst, columnsSecond) { MatrixArray = result };
        }


        public static Matrix2D Multiplication(Matrix2D firstMatrix, Matrix2D secondMatrix)
        {
            _ = firstMatrix ?? throw new ArgumentNullException(nameof(firstMatrix), "First matrix is null");
            _ = secondMatrix ?? throw new ArgumentNullException(nameof(secondMatrix), "Second matrix is null");

            firstMatrix.MatrixArray.GetDimensions(out int rowsFirst, out int columnsFirst);
            secondMatrix.MatrixArray.GetDimensions(out int rowsSecond, out int columnsSecond);

            if (columnsFirst != rowsSecond)
            {
                throw new Matrix2DException("The number of rows of the matrix passed in the parameters must be equal to the number of columns" +
                    " of the called matrix", rowsFirst, columnsFirst, rowsSecond, columnsSecond);
            }

            return firstMatrix.Multiplication(secondMatrix);
        }

        public override string ToString()
        {
            StringBuilder result = new();
            MatrixArray.GetDimensions(out int rows, out int columns);

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (column != columns - 1)
                    {
                        result.Append(MatrixArray[row, column] + " ");
                    }
                    else
                    {
                        result.Append(MatrixArray[row, column]);
                    }
                }
                if (row != rows - 1)
                {
                    result.Append('\n');
                }
            }
            return result.ToString();
        }

        public override int GetHashCode()
        {
            MatrixArray.GetDimensions(out int rows, out int columns);
            int hashCode = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    hashCode += MatrixArray[row, column].GetHashCode();
                }
            }
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Matrix2D);
        }

        public bool Equals(Matrix2D matrix)
        {
            if (matrix is null)
            {
                return false;
            }
            if (ReferenceEquals(this, matrix))
            {
                return true;
            }
            if (GetType() != matrix.GetType())
            {
                return false;
            }

            return matrix.MatrixArray == MatrixArray;
        }

        public static bool operator ==(Matrix2D matrixFirst, Matrix2D matrixSecond)
        {
            if (matrixFirst is null)
            {
                if (matrixSecond is null)
                {
                    return true;
                }
                return false;
            }
            return matrixFirst.Equals(matrixSecond);
        }

        public static bool operator !=(Matrix2D matrixFirst, Matrix2D matrixSecond)
        {
            return !(matrixFirst == matrixSecond);
        }
    }
}
