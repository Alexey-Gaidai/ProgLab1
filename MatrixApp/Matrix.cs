using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApp
{
    internal class Matrix
    {
        private int rows;
        private int columns;
        public double[,] matrix;

        public Matrix(int _rows, int _columns)
        {
            this.rows = _rows;
            this.columns = _columns;
            matrix = doMatrix(rows, columns);
        }
        private double[,] doMatrix(int n, int m)
        {
            Random rand = new Random();
            double[,] matrix = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rand.Next(0, 100);
                }
            }
            return matrix;
        }
        public double[,] reverseElements()
        {
            var max = double.MinValue;
            int maxI = 0;
            int maxJ = 0;
            var min = double.MaxValue;
            int minI = 0;
            int minJ = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minI = i;
                        minJ = j;
                    }
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxI = i;
                        maxJ = j;
                    }
                }
            }
            matrix[minI, minJ] = max;
            matrix[maxI, maxJ] = min;
            return matrix;
        }
    }
}
