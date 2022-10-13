/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/
void printColorData(string data)
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine(data);
    Console.ResetColor();
}

int randomNum(int min, int max)
{
    int num = new Random().Next(min, max);
    return num;
}

void printOriginalMatrix(int rows1, int columns1, int rows2, int columns2)
{
    printColorData($"Получили первый случайный двумерный массив размером [{rows1}, {columns1}], -> ");
    int[,] table1 = new int[rows1, columns1];
    for (int i = 0; i < table1.GetLength(0); i++)
    {
        for (int j = 0; j < table1.GetLength(1); j++)
        {
            Console.Write($"{table1[i, j] = randomNum(-10, 10)}\t");
        }
        Console.WriteLine("");
    }
    printColorData($"Получили второй случайный двумерный массив размером [{rows2}, {columns2}], -> ");
    int[,] table2 = new int[rows2, columns2];
    for (int i = 0; i < table2.GetLength(0); i++)
    {
        for (int j = 0; j < table2.GetLength(1); j++)
        {
            Console.Write($"{table2[i, j] = randomNum(-10, 10)}\t");
        }
        Console.WriteLine("");
    }
    if (columns1 == rows2)
    {
        int[,] tableResult = new int[rows1, columns2];
        calcAndPrint(table1, table2, tableResult, columns1);
    }
    if (columns1 != rows2)
    {
        Console.WriteLine("Матрицы не согласованы. Решения нет");
        userAnotherTry();
    }
}

void calcAndPrint(int[,] currentTable1, int[,] currentTable2, int[,] resultTable, int agreedValue)
{
    printColorData("Получили результат произведения -> ");
    int temp = agreedValue;
    for (int i = 0; i < resultTable.GetLength(0); i++)
    {
        for (int j = 0; j < resultTable.GetLength(1); j++)
        {
            agreedValue = temp;
            int count = 0;
            while (agreedValue > 0)
            {
                resultTable[i, j] = resultTable[i, j] + currentTable1[i, count] * currentTable2[count, j];
                count++;
                agreedValue = agreedValue - 1;
            }
            Console.Write($"{resultTable[i, j]}\t");
        }
        Console.WriteLine();
    }
    userAnotherTry();
}

void userAnotherTry()
{
    Console.WriteLine("Вы хотите продолжить работу с программой? Да - Y, Нет - N");
    string? userChoice = Console.ReadLine();
    while (userChoice?.ToLower() != "y" && userChoice?.ToLower() != "n")
    {
        Console.WriteLine("Пожалуйста, введите верное решение. Если хотите продолжить работу - введите Y, если желаете закрыть программу - введите N");
        userChoice = Console.ReadLine();
    }
    if (userChoice == "y")
    {
        userData();
    }
    else
    {
        Console.WriteLine("Bye!");
    }
}

void userData()
{
    printOriginalMatrix(randomNum(1, 4), randomNum(1, 4), randomNum(1, 4), randomNum(1, 4));
}

Console.Clear();
Console.WriteLine("Приветствую! Эта программа на вход принимает позицию элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.");
userData();