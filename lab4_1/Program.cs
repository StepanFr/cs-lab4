namespace lab4_1
{

    public class MyMatrix
    {
        private int[,] data;

        public int Rows { get; }
        public int Columns { get; }

        public MyMatrix(int rows, int columns, int minValue, int maxValue)
        {
            Rows = rows;
            Columns = columns;
            data = new int[rows, columns];
            Random rand = new();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    data[i, j] = rand.Next(minValue, maxValue);
                }
            }
        }

        public int this[int row, int column]
        {
            get
            {
                return data[row, column];
            }
            set
            {
                data[row, column] = value;
            }
        }

        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            MyMatrix result = new(a.Rows, a.Columns, 0, 1);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

        public static MyMatrix operator -(MyMatrix a, MyMatrix b)
        {
            MyMatrix result = new(a.Rows, a.Columns, 0, 1);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }

        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            MyMatrix result = new(a.Rows, b.Columns, 0, 1);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    for (int k = 0; k < a.Columns; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }

        public static MyMatrix operator *(MyMatrix a, int scalar)
        {
            MyMatrix result = new(a.Rows, a.Columns, 0, 1);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] * scalar;
                }
            }
            return result;
        }

        public static MyMatrix operator /(MyMatrix a, int scalar)
        {
            if (scalar == 0)
                throw new DivideByZeroException("Деление на ноль недопустимо.");

            MyMatrix result = new(a.Rows, a.Columns, 0, 1);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] / scalar;
                }
            }
            return result;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(data[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Введите количество строк: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов: ");
            int columns = int.Parse(Console.ReadLine());

            Console.Write("Введите минимальное значение: ");
            int minValue = int.Parse(Console.ReadLine());

            Console.Write("Введите максимальное значение: ");
            int maxValue = int.Parse(Console.ReadLine())+1;

            MyMatrix matrix = new(rows, columns, minValue, maxValue);

            Console.WriteLine("\nСгенерированная матрица:");
            matrix.PrintMatrix();

            MyMatrix matrixB = new(rows, columns, minValue, maxValue);
            Console.WriteLine("\nВторая матрица:");
            matrixB.PrintMatrix();

            MyMatrix sumMatrix = matrix + matrixB;
            Console.WriteLine("\nСумма двух матриц:");
            sumMatrix.PrintMatrix();

            MyMatrix differenceMatrix = matrix - matrixB;
            Console.WriteLine("\nРазность двух матриц:");
            differenceMatrix.PrintMatrix();

            int n = 2;
            MyMatrix productMatrix = matrix * n;
            Console.WriteLine("\nУмножение первой матрицы на 2:");
            productMatrix.PrintMatrix();

            int n1, n2;
            Console.WriteLine("Введите строку:");
            n1 = int.Parse(Console.ReadLine())-1;
            Console.WriteLine("Введите столбец:");
            n2 = int.Parse(Console.ReadLine())-1;
            Console.WriteLine($"Элемент ({n1+1}, {n2+1}) исходной матрицы: {matrix[n1, n2]}");
        }
    }
}