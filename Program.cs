using System;

class MyMatrix
{
    private int[,] matrix;
    private int rows;
    private int columns;
    private Random random;

    public MyMatrix(int rows, int columns, int minValue, int maxValue)
    {
        this.rows = rows;
        this.columns = columns;
        matrix = new int[rows, columns];
        random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue);
            }
        }
    }

    public void Print()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public int this[int row, int column]
    {
        get
        {
            if (row >= 0 && row < rows && column >= 0 && column < columns)
            {
                return matrix[row, column];
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс за пределами матрицы");
            }
        }
        set
        {
            if (row >= 0 && row < rows && column >= 0 && column < columns)
            {
                matrix[row, column] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс за пределами матрицы");
            }
        }
    }

    public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
    {
        

        MyMatrix result = new MyMatrix(matrix1.rows, matrix1.columns, 0, 0);

        for (int i = 0; i < matrix1.rows; i++)
        {
            for (int j = 0; j < matrix1.columns; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    public static MyMatrix operator -(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.rows != matrix2.rows || matrix1.columns != matrix2.columns)
        {
            throw new InvalidOperationException("Невозможно выполнить вычитание матриц разных размеров.");
        }

        MyMatrix result = new MyMatrix(matrix1.rows, matrix1.columns, 0, 0);

        for (int i = 0; i < matrix1.rows; i++)
        {
            for (int j = 0; j < matrix1.columns; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }

        return result;
    }

    public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.columns != matrix2.rows)
        {
            throw new InvalidOperationException("Невозможно выполнить умножение матриц. Количество столбцов первой матрицы должно равняться количеству строк второй матрицы.");
        }

        MyMatrix result = new MyMatrix(matrix1.rows, matrix2.columns, 0, 0);

        for (int i = 0; i < matrix1.rows; i++)
        {
            for (int j = 0; j < matrix2.columns; j++)
            {
                for (int k = 0; k < matrix1.columns; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return result;
    }

    public static MyMatrix operator *(MyMatrix matrix, int scalar)
    {
        MyMatrix result = new MyMatrix(matrix.rows, matrix.columns, 0, 0);

        for (int i = 0; i < matrix.rows; i++)
        {
            for (int j = 0; j < matrix.columns; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }

        return result;
    }

    public static MyMatrix operator /(MyMatrix matrix, int divisor)
    {
        if (divisor == 0)
        {
            throw new InvalidOperationException("Деление на ноль невозможно.");
        }

        MyMatrix result = new MyMatrix(matrix.rows, matrix.columns, 0, 0);

        for (int i = 0; i < matrix.rows; i++)
        {
            for (int j = 0; j < matrix.columns; j++)
            {
                result[i, j] = matrix[i, j] / divisor;
            }
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество строк: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Введите количество столбцов: ");
        int columns = int.Parse(Console.ReadLine());

        MyMatrix matrix1 = new MyMatrix(rows, columns, -10, 10);
        MyMatrix matrix2 = new MyMatrix(rows, columns, -10, 10);

        Console.WriteLine("Матрица 1:");
        matrix1.Print();

        Console.WriteLine("Матрица 2:");
        matrix2.Print();

        Console.WriteLine("Сложение матриц:");
        (matrix1 + matrix2).Print();

        Console.WriteLine("Вычитание матриц:");
        (matrix1 - matrix2).Print();

        Console.WriteLine("Умножение матриц:");
        (matrix1 * matrix2).Print();

        Console.Write("Введите число для умножения матрицы: ");
        int scalar = int.Parse(Console.ReadLine());
        Console.WriteLine("Умножение матрицы на число:");
        (matrix1 * scalar).Print();

        Console.Write("Введите число для деления матрицы: ");
        int divisor = int.Parse(Console.ReadLine());
        Console.WriteLine("Деление матрицы на число:");
        (matrix1 / divisor).Print();

        Console.Write("Введите индекс строки: ");
        int rowIndex = int.Parse(Console.ReadLine());
        Console.Write("Введите индекс столбца: ");
        int colIndex = int.Parse(Console.ReadLine());
        //Индексатор обращается к матрице 1;
        Console.WriteLine("Значение по индексам (" + rowIndex + ", " + colIndex + ") у первой матрицы: " + matrix1[rowIndex, colIndex] +" у второй матрицы: " + matrix2[rowIndex, colIndex]);
    }
}