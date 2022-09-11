// Задача 54: Задайте двумерный массив. 
// Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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

void SortRowsOfMatrix(int[,] matrix){
    int countRows = matrix.GetLength(0);
    int countColumns = matrix.GetLength(1);

    for (int i = 0; i < countRows; i++){
        for (int j = 0; j < countColumns; j++){
            for (int k = 0; k < countColumns - j - 1; k++){
                if (matrix[i, k] < matrix[i, k + 1]){
                    int temp = matrix[i, k];
                    matrix[i, k] = matrix[i, k + 1];
                    matrix[i, k + 1] = temp;
                }
            }
        }
    }       
}

Console.WriteLine("Введите данные для формирования матрицы: ");
Console.Write("Количество строк: ");
int rows = Convert.ToInt32(Console.ReadLine());

Console.Write("Количество столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());

int[,] matrix = GetMatrix(rows, columns, -10, 10); 
PrintMatrix(matrix);
Console.WriteLine();
SortRowsOfMatrix(matrix);
PrintMatrix(matrix);