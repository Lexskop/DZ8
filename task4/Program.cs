/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
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

void printOriginalMatrix(int length, int width, int height)
{
    printColorData($"Получили случайный трёхмерный массив размером [{length}, {width}, {height}], -> ");
    int[,,] table = new int[length, width, height];
    int count = 1;
    for (int i = 0; i < table.GetLength(0); i++)
    {
        for (int j = 0; j < table.GetLength(1); j++)
        {
            for (int q = 0; q < table.GetLength(2); q++)
            {
                Console.Write($"{table[i, j, q] = randomNum(5 * count + 5, 5 * (count + 1) + 5)} ({j},{q},{i}) ");
                count++;
            }
            Console.WriteLine("");
        }
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
    int userLength = randomNum(1, 3);
    int userWidth = randomNum(1, 3);
    int userHeight = randomNum(1, 3);
    printOriginalMatrix(userLength, userWidth, userHeight);
}

Console.Clear();
Console.WriteLine("Приветствую! Эта программа на вход принимает позицию элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.");
userData();