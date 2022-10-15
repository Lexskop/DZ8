/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
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

void printMatrix(int rowsAndColumns)
{
    printColorData($"Получили двумерный массив размером [{rowsAndColumns}, {rowsAndColumns}] со спиральным заполнением -> ");
    int[,] table = new int[rowsAndColumns, rowsAndColumns];

    table[0, 0] = 1;
    for (int count = 2, i = 0, j = 0; count <= rowsAndColumns * rowsAndColumns;)
    {
        while (j + 1 < rowsAndColumns && table[i, j + 1] == 0)
        {
            table[i, ++j] = count++;
        }
        while (i + 1 < rowsAndColumns && table[i + 1, j] == 0)
        {
            table[++i, j] = count++;
        }
        while (j - 1 > -1 && table[i, j - 1] == 0)
        {
            table[i, --j] = count++;
        }
        while (i - 1 > -1 && table[i - 1, j] == 0)
        {
            table[--i, j] = count++;
        }
    }

    for (int i = 0; i < table.GetLength(0); i++)
    {
        for (int j = 0; j < table.GetLength(1); j++)
        {
            Console.Write($"{table[i, j]:d2}\t");
        }
        Console.WriteLine("");
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
    printMatrix(randomNum(2, 6));

}

Console.Clear();
Console.WriteLine("Приветствую! Эта программа заполнит спирально массив.");
userData();