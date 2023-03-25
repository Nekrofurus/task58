// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
//Например, даны 2 матрицы:
//2 4 | 3 4
//3 2 | 3 3
//Результирующая матрица будет:
//18 20
//15 18
int numberLineFirstMatrix = UserInput("Количество строк в первой матрице = ");
int numberColumbFirstMatrix = UserInput("Количество столбцов в первой матрице = ");
int minimumFirstMatrix = UserInput("Введите минимальное значение = ");
int maximumFirstMatrix = UserInput("Введите максимальное значение = ");
int[,] firstmatrix = CreateRandomMatrix(numberLineFirstMatrix, numberColumbFirstMatrix, minimumFirstMatrix, maximumFirstMatrix);
int numberLineSecondMatrix = UserInput("Количество строк во второй матрице = ");
int numberColumbSecondMatrix = UserInput("Количество столбцов во второй матрице = ");
int minimumSecondMatrix = UserInput("Введите минимальное значение = ");
int maximumSecondMatrix = UserInput("Введите максимальное значение = ");
int[,] secondMatrix = CreateRandomMatrix(numberLineSecondMatrix, numberColumbSecondMatrix, minimumSecondMatrix, maximumSecondMatrix);
PrintTwoMatrix(firstmatrix, secondMatrix);
Console.WriteLine("Произведение, представленных выше матриц:");
PrintMultiplicationMatrix(firstmatrix, secondMatrix,MultiplicationMatrix(firstmatrix, secondMatrix));
int[,] CreateRandomMatrix(int line, int columb, int min, int max)
{
    int[,] matrix = new int[line, columb];

    {

        for (int i = 0; i < line; i++)
        {
            for (int j = 0; j < columb; j++)
            {
                matrix[i, j] = new Random().Next(min, max + 1);
            }
        }
    }
    return matrix;
}
void PrintTwoMatrixMaxLineFirstMatrix(int[,] matrix1, int[,] matrix2)
{
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        if (i < matrix2.GetLength(0))
        {
            Console.Write("| ");
            for (int j = 0; j < matrix1.GetLength(1) - 1; j++)
            {
                Console.Write($"{matrix1[i, j]}, ");
            }
            Console.Write($"{matrix1[i, matrix1.GetLength(1) - 1]} | | ");
            for (int k = 0; k < matrix2.GetLength(1) - 1; k++)
            {
                Console.Write($"{matrix2[i, k]}, ");
            }
            Console.WriteLine($"{matrix2[i, matrix2.GetLength(1) - 1]} |");
        }
        else
        {
            Console.Write("| ");
            for (int j = 0; j < matrix1.GetLength(1) - 1; j++)
            {
                Console.Write($"{matrix1[i, j]}, ");
            }
            Console.WriteLine($"{matrix1[i, matrix1.GetLength(1) - 1]} |");
        }
    }
}
void PrintTwoMatrixMaxLineSecondMatrix(int[,] matrix1, int[,] matrix2)
{
    for (int i = 0; i < matrix2.GetLength(0); i++)
    {
        if (i < matrix1.GetLength(0))
        {
            Console.Write("| ");
            for (int j = 0; j < matrix1.GetLength(1) - 1; j++)
            {
                Console.Write($"{matrix1[i, j]}, ");
            }
            Console.Write($"{matrix1[i, matrix1.GetLength(1) - 1]} | | ");
            for (int k = 0; k < matrix2.GetLength(1) - 1; k++)
            {
                Console.Write($"{matrix2[i, k]}, ");
            }
            Console.WriteLine($"{matrix2[i, matrix2.GetLength(1) - 1]} |");
        }
        else
        {
            Console.Write("   ");
            for (int j = 0; j < matrix1.GetLength(1) - 1; j++)
            {
                Console.Write($"   ");
            }
            Console.Write($"   | ");
            for (int k = 0; k < matrix2.GetLength(1) - 1; k++)
            {
                Console.Write($"{matrix2[i, k]}, ");
            }
            Console.WriteLine($"{matrix2[i, matrix2.GetLength(1) - 1]} |");
        }
    }
}
void PrintTwoSquareMatrix(int[,] matrix1, int[,] matrix2)
{
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        Console.Write("| ");
        for (int j = 0; j < matrix1.GetLength(1) - 1; j++)
        {
            Console.Write($"{matrix1[i, j]}, ");
        }
        Console.Write($"{matrix1[i, matrix1.GetLength(1) - 1]} | | ");
        for (int k = 0; k < matrix2.GetLength(1) - 1; k++)
        {
            Console.Write($"{matrix2[i, k]}, ");
        }
        Console.WriteLine($"{matrix2[i, matrix2.GetLength(1) - 1]} |");
    }
}
void PrintTwoMatrix(int[,] matrix1, int[,] matrix2)
{
    if (matrix1.GetLength(0) > matrix2.GetLength(0))
    {
        PrintTwoMatrixMaxLineFirstMatrix(matrix1, matrix2);
    }
    else if (matrix1.GetLength(0) < matrix2.GetLength(0))
    {
        PrintTwoMatrixMaxLineSecondMatrix(matrix1, matrix2);
    }
    else
    {
        PrintTwoSquareMatrix(matrix1, matrix2);
    }
}
int[,] MultiplicationMatrix(int[,] matrix1, int[,] matrix2)
{
    int[,] multiplication = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            for (int k = 0; k < matrix1.GetLength(1); k++)
            {
                multiplication[i, j] = multiplication[i, j] + matrix1[i, k] * matrix2[k, j];
            }

        }
    }
    return multiplication;
}
int UserInput(string massage)
{
    Console.Write(massage);
    string value = Console.ReadLine();
    int result = Convert.ToInt32(value);
    return result;
}
void PrintMultiplicationMatrix(int[,] matrix1, int[,] matrix2, int[,] multiplicationmatrix)
{
    if (matrix1.GetLength(1) != matrix2.GetLength(0))
    {
        Console.WriteLine("Невозможно выполнить произведение! Количество столбцов в первой матрице должно соответствовать количеству строк во втрой матрице!");
    }
    else
    {
        for (int i = 0; i < multiplicationmatrix.GetLength(0); i++)
        {
            Console.Write("| ");
            for (int j = 0; j < multiplicationmatrix.GetLength(1) - 1; j++)
            {
                Console.Write($"{multiplicationmatrix[i, j]}, ");
            }
            Console.WriteLine($"{multiplicationmatrix[i, multiplicationmatrix.GetLength(1) - 1]} |");
        }
    }
}