using System;
using System.Runtime.Serialization;

namespace Matrix
{
    [Serializable]
    public class Matrix2DException : ApplicationException
    {
        public int FirstMatrixRows { get; set; }
        public int FirstMatrixColumns { get; set; }
        public int SecondMatrixRows { get; set; }
        public int SecondMatrixColumns { get; set; }

        public Matrix2DException(int firstMatrixRows, int firstMatrixColumns, int secondMatrixRows, int secondMatrixColumns)
        {
            FirstMatrixRows = firstMatrixRows;
            FirstMatrixColumns = firstMatrixColumns;
            SecondMatrixRows = secondMatrixRows;
            SecondMatrixColumns = secondMatrixColumns;
        }

        public Matrix2DException(string message, int firstMatrixRows, int firstMatrixColumns, int secondMatrixRows, int secondMatrixColumns)
             : base(message + $" Size of first matrix is {firstMatrixRows}x{firstMatrixColumns} and second is {secondMatrixRows}x{secondMatrixColumns}")
        {

            FirstMatrixRows = firstMatrixRows;
            FirstMatrixColumns = firstMatrixColumns;
            SecondMatrixRows = secondMatrixRows;
            SecondMatrixColumns = secondMatrixColumns;
        }

        public Matrix2DException(string message, Exception inner, int firstMatrixRows, int firstMatrixColumns, int secondMatrixRows, int secondMatrixColumns)
            : base(message, inner)
        {

            FirstMatrixRows = firstMatrixRows;
            FirstMatrixColumns = firstMatrixColumns;
            SecondMatrixRows = secondMatrixRows;
            SecondMatrixColumns = secondMatrixColumns;
        }

        protected Matrix2DException(SerializationInfo info,
        StreamingContext context) : base(info, context) { }
    }
}
