// Задача 47: Задайте двумерный массив размером m×n, заполненный случайными 
// вещественными числами.
// Уточнение задачи:
// 1. Размерность массива, границы значений элементов и количество знаков 
//      после запятой задаются пользователем
// 2. Массив выводится на экран


int CheckPositiveInt (string messageForUser)
{
    int number = 0, i = 0;
    string userNumber = string.Empty;
    bool success = false;
    while(i == 0) 
    {
        Console.Write(messageForUser);
        userNumber = Console.ReadLine();
        success = int.TryParse(userNumber, out number);
        if(success)
        {
            number = int.Parse(userNumber);
            if(number > 0) i = 1;
            else PrintErrorMessageInt(userNumber); 
        }
        else 
        {
            PrintErrorMessageInt(userNumber);
        } 
        Console.WriteLine();
    }
    return number;
}

void PrintErrorMessageInt (string userNumber)
{
    Console.WriteLine("Уважаемый пользователь, вы ошиблись при вводе! "); 
    Console.Write($"Введённое Вами значение: {userNumber},");
    Console.WriteLine(" не является целым положительным числом.");
}

double CheckValuesDouble (string messageForUser)
{
    double number = 0;
    int i = 0;
    string userNumber = string.Empty;
    bool success = false;
    while(i == 0) 
    {
        Console.Write(messageForUser);
        userNumber = Console.ReadLine();
        success = double.TryParse(userNumber, out number);
        if(success) 
        {
            i = 1;
        }
        else 
        {
            Console.WriteLine("Уважаемый пользователь, вы ошиблись при вводе! "); 
            Console.Write($"Введённое Вами значение: {userNumber},");
            Console.WriteLine(" не является вещественным числом.");
        }
        Console.WriteLine();
    }
    return number;
}

void FillArrayRandomRealNumbers(double[,] array, double minValue, 
                                double maxValue, int rounding)
{
    int minValueInt = Convert.ToInt32(minValue * Math.Pow(10, rounding));
    int maxValueInt = Convert.ToInt32(maxValue * Math.Pow(10, rounding)); 
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = new Random().Next(minValueInt, maxValueInt) 
                        / Math.Pow(10, rounding);
}

void PrintArray(double[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write(array[i, j] + " ");
        Console.WriteLine();
    }
}


Console.WriteLine("Создание двумерного массива случайных вещественных " +
                    "чисел с выводом на экран.");
string messegeForUser = string.Empty;
// Определение размерности массива
int m = 0, n = 0;
messegeForUser = "Введите количество строк (m): ";
m = CheckPositiveInt(messegeForUser);
messegeForUser = "Введите количество столбцов (n): ";
n = CheckPositiveInt(messegeForUser);
// Определение диапазона значений элементов массива
double minRangeValue, maxRangeValue;
messegeForUser = "Введите минимальное значение для элементов массива: ";
minRangeValue = CheckValuesDouble(messegeForUser);
maxRangeValue = minRangeValue - 1;
while(minRangeValue >= maxRangeValue)
{
    messegeForUser = "Введите максимальное значение для элементов массива: ";
    maxRangeValue = CheckValuesDouble(messegeForUser);
    if(minRangeValue >= maxRangeValue)
    {
        Console.WriteLine("Уважаемый пользователь, вы ошиблись при вводе! "); 
        Console.Write($"Введённое Вами максимальное значение: {maxRangeValue},");
        Console.Write(" меньше или равно ранее введённому ");
        Console.WriteLine($"минимальному значению: {minRangeValue}.");
    }
    Console.WriteLine();
}
// Определение количества знаков после запятой
int rounding = 0;
messegeForUser = "Введите количество десятичных знаков после запятой: ";
rounding = CheckPositiveInt(messegeForUser);

double[,] array = new double[m, n];
FillArrayRandomRealNumbers(array, minRangeValue, maxRangeValue, rounding);
PrintArray(array);
Console.WriteLine();
