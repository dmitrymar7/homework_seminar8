// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт 
// номер строки с наименьшей суммой элементов: 1 строка

int[,] GetMatrix(int rows, int columns, int minRandom, int maxRandom){
    int[,] matrix = new int[rows, columns];

    for (int i = 0; i < rows; i++){
        for (int j = 0; j < columns; j++){
            matrix[i, j] = new Random().Next(minRandom, maxRandom + 1);
        }
    }

    return matrix;
}

void PrintMatrix(int[,] matrix){
    int countRows = matrix.GetLength(0);
    int countColumns = matrix.GetLength(1);
    for (int i = 0; i < countRows; i++){
        for (int j = 0; j < countColumns; j++){
            Console.Write(matrix[i,j] + "\t");
        }
        Console.WriteLine();
    }
}

int NumberOfRowWithMinSum(int[,] matrix){
    
    int countRows = matrix.GetLength(0);
    int countColumns = matrix.GetLength(1);

    int number = -1;
    int minSum = 0;

    for (int i = 0; i < countRows; i++){
        int currentSum = 0;
        for (int j = 0; j < countColumns; j++){
            currentSum += matrix[i, j];
        }
        if (i == 0){
            number = 0;
            minSum = currentSum;
        }else if (minSum > currentSum){
            number = i;
            minSum = currentSum;
        }
    }

    return number;
}

Console.WriteLine("Введите данные для формирования матрицы: ");
Console.Write("Количество строк: ");
int rows = Convert.ToInt32(Console.ReadLine());

Console.Write("Количество столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());

int[,] matrix = GetMatrix(rows, columns, 0, 10); 
PrintMatrix(matrix);

int number = NumberOfRowWithMinSum(matrix);
Console.WriteLine($"номер строки с наименьшей суммой элементов: {number} строка");
