// Задача 60. Напишите программу, которая заполнит 
// спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

void PrintMatrix(string[,] matrix){
    int countRows = matrix.GetLength(0);
    int countColumns = matrix.GetLength(1);
    for (int i = 0; i < countRows; i++){
        for (int j = 0; j < countColumns; j++){
            Console.Write(matrix[i,j] + "\t");
        }
        Console.WriteLine();
    }
}

string[,] GetMatrix(int rows, int columns, string symbol = "*"){

    int sizeOutput = (rows * columns).ToString().Length;
    string format = "0";
    while (format.Length < sizeOutput){
        format += "0";
    }

    string[,] matrix = new string[rows, columns];

    for (int i = 0; i < rows; i++){
        for (int j = 0; j < columns; j++){
            matrix[i, j] = symbol;
        }
    }

    bool flag = true;
    int mode = 1;
    int ii = 0;
    int jj = 0;
    int current = 1;
    while (flag){
        bool isChange = false;

        if (mode == 1){
            while(jj + 1 < matrix.GetLength(1) && matrix[ii, jj + 1] == "*"){
                matrix[ii, jj] = current.ToString(format);
                jj++;
                current++;
                isChange = true;    
            }
            mode = 2;
        }

        if (mode == 2){
            while(ii + 1 < matrix.GetLength(0) && matrix[ii + 1, jj] == "*"){
                matrix[ii, jj] = current.ToString(format);
                ii++;
                current++;    
                isChange = true;
            }
            mode = 3;
        }

        if (mode == 3){
            while(jj - 1 >= 0 && matrix[ii, jj - 1] == "*"){
                matrix[ii, jj] = current.ToString(format);
                jj--;
                current++;
                isChange = true;    
            }
            mode = 4;
        }

        if (mode == 4){
            while(ii - 1 >= 0 && matrix[ii - 1, jj] == "*"){
                matrix[ii, jj] = current.ToString(format);
                ii--;
                current++;  
                isChange = true;  
            }
            mode = 1;
        }

        if (isChange == false){
            matrix[ii, jj] = current.ToString();
            flag = false;
        }

    }

    return matrix;
}

string[,] matrix = GetMatrix(4, 4);
PrintMatrix(matrix);
