/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
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
    printColorData("Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов -> ");
    int maxSum = 0;
    int indexMax = 0;
    int sum = 0;
    for (int i = 0; i < currentTable.GetLength(0); i++)
    {
        sum = 0;
        for (int j = 0; j < currentTable.GetLength(1); j++)
        {
            sum = sum + currentTable[i, j];
        }
        Console.WriteLine($"Сумма в {i + 1} строке массива -> {sum}");
        if (i == 0)
        {
            maxSum = sum;
            indexMax = i;
        }
        if (maxSum < sum)
        {
            maxSum = sum;
            indexMax = i;
        }
    }
    Console.WriteLine($"Максимальная сумма находится в {indexMax + 1} строке массива -> {maxSum}");
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
Console.WriteLine("Приветствую! Эта программа на вход принимает позицию элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.");
userData();