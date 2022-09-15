using System.Data.Common;

interface IReverse{
    public double[,] doReverse(double[,] matrix);
}

class IReverse_impl: IReverse{
    double[,] IReverse.doReverse(double[,] matrix){
        var rows = matrix.GetLength(0);
        var columns = matrix.GetLength(1);
        var max = double.MinValue;
        int maxI = 0;
        int maxJ = 0;
        var min = double.MaxValue;
        int minI = 0;
        int minJ = 0;
        for (int i = 0; i < rows; i++){
            for (int j = 0; j < columns; j++){
                if (matrix[i,j] < min) {
                    min = matrix[i, j];
                    minI = i;
                    minJ = j;
                }
                if (matrix[i,j] > max) {
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

class Matrix{
    private int rows;
    private int columns;
    public double[,] matrix;

    public Matrix(int _rows, int _columns){
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
    public void displayMatrix()
    {
        int rowLength = matrix.GetLength(0);
        int colLength = matrix.GetLength(1);

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                Console.Write(string.Format("{0} ", matrix[i, j]));
            }
            Console.Write(Environment.NewLine + Environment.NewLine);
        }
    }
}

class MainClass{
    static void Main(string[] args){
        int rows = 4;
        int columns = 5;
        Matrix matrix = new Matrix(rows, columns);
        IReverse reverse = new IReverse_impl();
        Console.WriteLine("Your Matrix: ");
        matrix.displayMatrix();
        matrix.matrix = reverse.doReverse(matrix.matrix);
        Console.WriteLine("Result: ");
        matrix.displayMatrix();
    }
}

