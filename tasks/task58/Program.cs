// Задача 58: Задайте две матрицы. 
// Напишите программу, которая будет находить 
// произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] GetMatrix(int rows, int columns, int minRandom, int maxRandom){
    int[,] matrix = new int[rows, columns];

    for (int i = 0; i < rows; i++){
        for (int j = 0; j < columns; j++){
            matrix[i, j] = new Random().Next(minRandom, maxRandom + 1);
        }
    }

    return matrix;
}

int[,] multiplyMatrix(int[,] matrix1, int[,] matrix2){
    int[,] matrixResult;
    if (matrix1.GetLength(1) != matrix2.GetLongLength(0)){
        matrixResult = new int[0,0];
        return matrixResult;
    }
    matrixResult = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrixResult.GetLength(0); i++){
        for (int j = 0; j < matrixResult.GetLength(1); j++){
            int sumElem = 0;
            for (int k = 0; k < matrix1.GetLength(1); k++){
                sumElem += matrix1[i, k] * matrix2[k,j];
            }
            matrixResult[i, j] = sumElem; 
        }
    }
    
    return matrixResult;
}

void Print2Matrix(int[,] matrix1, int[,] matrix2){
    int rows1 = matrix1.GetLength(0);
    int rows2 = matrix2.GetLength(0);
    int columns1 = matrix1.GetLength(1);
    int columns2 = matrix2.GetLength(1);
    int rows = Math.Max(rows1, rows2);
    int columns = Math.Max(columns1, columns2);
    for (int i = 0; i < rows; i++){
        for (int j = 0; j < columns; j++){
            if (i < rows1 && j < columns1){
                Console.Write(matrix1[i, j] + "\t");
            }
        }
        Console.Write("| ");
        for (int j = 0; j < columns; j++){
            if (i < rows2 && j < columns2){
                Console.Write(matrix2[i, j] + "\t");
            }            
        }
        Console.WriteLine();
    }
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

Console.WriteLine("Введите данные для формирования первой матрицы: ");
Console.Write("Количество строк: ");
int rows1 = Convert.ToInt32(Console.ReadLine());

Console.Write("Количество столбцов: ");
int columns1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Введите данные для формирования второй матрицы: ");
Console.Write("Количество строк: ");
int rows2 = Convert.ToInt32(Console.ReadLine());

Console.Write("Количество столбцов: ");
int columns2 = Convert.ToInt32(Console.ReadLine());

int[,] matrix1 = GetMatrix(rows1, columns1, 0, 10);
int[,] matrix2 = GetMatrix(rows2, columns2, 0, 10);
Print2Matrix(matrix1, matrix2);
Console.WriteLine();
if (matrix1.GetLength(1) == matrix2.GetLength(0)){
    int[,] matrix = multiplyMatrix(matrix1, matrix2);
    PrintMatrix(matrix);
}else{
    Console.WriteLine("Для умножения матриц число столбцов первой матрицы должно совпадать с числом строк второй матрицы.");
}
