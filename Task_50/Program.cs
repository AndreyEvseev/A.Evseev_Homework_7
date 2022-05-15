// Задача 50: Напишите программу, которая на вход принимает позиции элемента 
// в двумерном массиве, и возвращает значение этого элемента или же указание, 
// что такого элемента нет.
// Уточнение условия:
// 1. Для тестирования дополнительно формируем массив случайных натуральных чисел. 
//    Размерность и значения элементов массива задаются генератором случайных чисел.  
//    Максимум диапазона генерации размерности = 100, значений элементов = 1000. 
//    Опционально возможно выведение размерности массива и / или самого массива.
// 2. Позиции искомого элемента в двумерном массиве могут быть заданы пользователем или 
//    сгенерированы генератором случайных чисел. Во втором случае максимальное значение 
//    диапазона по умолчанию установлено = 100, но может быть изменен пользователем. 
//    Минимальное значение диапазона = 0.

void TitleInputErrorMessage()
{
    Console.WriteLine("Уважаемый пользователь, вы ошиблись при вводе! ");
}

void PrintErrorMessageInt (string userNumber)
{
    TitleInputErrorMessage();
    Console.Write($"Введённое Вами значение: {userNumber},");
    Console.WriteLine(" не является натуральным числом.");
}

int AutoGenerationElementPosition(int minRangeValue, int maxRangeValue)
{
    int number = new Random().Next(minRangeValue, maxRangeValue + 1);
    return number;
}

void CreatArrayRandomNaturalNumbers(int[,] creatArray)
{
    int minRangeValue = 1, maxRangeValue = 100;
    for (int i = 0; i < creatArray.GetLength(0); i++)
        for (int j = 0; j < creatArray.GetLength(1); j++)
            creatArray[i, j] = AutoGenerationElementPosition(minRangeValue, maxRangeValue);
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j], 4} ");
        Console.WriteLine();
    }
}

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

int EnterElementPosition(string direction, string designation)
{
    string messegeForUser = string.Empty;
    messegeForUser = $"Введите номер {direction} искомого элемента ({designation}): ";
    int position = CheckPositiveInt(messegeForUser);
    return position; 
}

void ScrollArray()
{

}


// Автогенерация двумерного массива случайных натуральных чисел
int minRangeValue = 1, maxRangeValue = 100;
int row = AutoGenerationElementPosition(minRangeValue, maxRangeValue);
int column = AutoGenerationElementPosition(minRangeValue, maxRangeValue);
int[,] array = new int[row, column];
CreatArrayRandomNaturalNumbers(array);
// Печать массива на экран (опционально)
Console.Write("Ели Вы желаете просмотреть заданный массив, введите любой символ, если нет," + 
                " просто нажмите Enter");
if(Console.ReadLine() != "")
{
    Console.WriteLine($"Задан двумерный массив ({row}x{column}): ");
    PrintArray(array);
    Console.WriteLine();
}

// Выбор варианта определения позиций искомого элемента
string messegeForUser = string.Empty;
Console.WriteLine("Выберете вариант определения позиции искомого элемента массива: ");
Console.WriteLine("Вариант 1. Позиции элемента задаются пользователем.");
Console.WriteLine("Вариант 2. Позиции элемента задаются генератором случайных чисел.");
int optionNumber = 0;
while(optionNumber != 1 && optionNumber != 2)
{
    messegeForUser = "Введите номер варианта: ";
    optionNumber = CheckPositiveInt(messegeForUser);
    if(optionNumber != 1 && optionNumber != 2)
    {
        TitleInputErrorMessage(); 
        Console.Write($"Вами введён не существующий номер варианта: {optionNumber}.");
        Console.WriteLine("Возможные номера вариантов: 1 или 2.");
    }
}
int m, n;
if(optionNumber == 1)
{
    string direction = string.Empty;
    string designation = string.Empty;
    direction = "строки";
    designation = "m";
    m = EnterElementPosition(direction, designation);
    direction = "столбца";
    designation = "n";
    n = EnterElementPosition(direction, designation);    
}
else
{
    minRangeValue = 0; 
    maxRangeValue = 100;
    Console.WriteLine("По умолчанию выбор позиции искомого элемента происходит из диапазона " +
                    "от 0 до 100.");
    Console.Write("Ели Вы желаете изменить максимальное значение диапазона, введите любой " + 
                "символ, если нет, просто нажмите Enter");
    if(Console.ReadLine() != "")
    {
        messegeForUser = "Введите новое максимальное значение диапазона: ";
        maxRangeValue = CheckPositiveInt(messegeForUser);
    }
        m = AutoGenerationElementPosition(minRangeValue, maxRangeValue);
        n = AutoGenerationElementPosition(minRangeValue, maxRangeValue);
    }
if(m > row || n > column) 
{
    Console.Write($"Заданный двумерный массив имеет размерность ({row}x{column}).");
    Console.WriteLine($"Элемента с позицией ({m}x{n}) в этом массиве не существует.");
}
else
{
    int value = array[m, n];
    Console.Write($"Заданный двумерный массив имеет размерность ({row}x{column}).");
    Console.WriteLine($"Значение элемента с позицией ({m}x{n}) в заданном массиве = {value}.");
}
