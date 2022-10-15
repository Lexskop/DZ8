/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
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

void printOriginalMatrix(int rows, int columns)
{
    printColorData($"Получили случайный двумерный массив размером [{rows}, {columns}], -> ");
    int[,] table = new int[rows, columns];
    for (int i = 0; i < table.GetLength(0); i++)
    {
        for (int j = 0; j < table.GetLength(1); j++)
        {
            Console.Write($"{table[i, j] = randomNum(-10, 10)}\t");
        }
        Console.WriteLine("");
    }
    calcAndPrint(table);
}

void calcAndPrint(int[,] currentTable)
{
    printColorData("Получили новый массив -> ");
    for (int i = 0; i < currentTable.GetLength(0); i++)
    {
        for (int j = 0; j < currentTable.GetLength(1); j++)
        {
            int temp = currentTable[i, j];
            int max = currentTable[i, j];
            int indexMax = 0;
            for (int count = 0; count + j < currentTable.GetLength(1); count++)
            {
                if (max < currentTable[i, j + count])
                {
                    max = currentTable[i, j + count];
                    indexMax = j + count;
                }
            }
            currentTable[i, j] = max;
            currentTable[i, indexMax] = temp;
            Console.Write($"{currentTable[i, j]}\t");
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
    int userRows = randomNum(2, 5);
    int userColumns = randomNum(2, 5);
    printOriginalMatrix(userRows, userColumns);
}

Console.Clear();
Console.WriteLine("Приветствую! Эта программа задаёт двумерный массив и потом упорядочит по убыванию элементы каждой строки двумерного массива.");
userData();