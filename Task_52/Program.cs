// Задача 52: Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов 
//            в каждом столбце.
// Уточнение задания:
// 1. Размерность массива по умолчанию задаётся рандомно из диапазона от 1 до 100. Опционально 
//     пользователь может изменить максимальную границу диапазона, а также самостоятельно  
//     задать количество строк и столбцов.
// 2. Значения элементов массива по умолчанию задаются рандомно из диапазона от -999 до 999. 
//      Опционально пользователь может изменить границы диапазона, модуль значений границ 
//      не должен быть больше 5 разрядов.
// 3. Результат представляет собой одномерный массив.
// 4. По желанию пользователя исходный массив и результат могут быть выведены на экран.

void TitleInputErrorMessage()
{
    Console.WriteLine("Уважаемый пользователь, вы ошиблись при вводе! ");
}

void PrintErrorMessageEnterNumber (string userNumber, string definitionNumber)
{
    TitleInputErrorMessage();
    Console.Write($"Введённое Вами значение: {userNumber},");
    Console.WriteLine($" не является {definitionNumber} числом.");
}

int GenerationRandomIntegerNumbers(int minRangeValue, int maxRangeValue)
{
    int number = new Random().Next(minRangeValue, maxRangeValue + 1);
    return number;
}

void FillArrayRandomintegerNumbers(int[,] createArray, int minRangeValue, int maxRangeValue)
{
    for (int i = 0; i < createArray.GetLength(0); i++)
        for (int j = 0; j < createArray.GetLength(1); j++)
            createArray[i, j] = GenerationRandomIntegerNumbers(minRangeValue, maxRangeValue);
}

void FillArrayArithmeticMeanColumns(double[] createArray, int[,] sourceArray)
{
    double help;
    for (int i = 0; i < sourceArray.GetLength(1); i++)
    {
        help = sourceArray[0, i];
        for (int j = 1; j < sourceArray.GetLength(0); j++)
        {
            help = help + sourceArray[j, i];
        }
        help = help / sourceArray.GetLength(0);
        createArray[i] = help;
    }
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j], 7} ");
        Console.WriteLine();
        Console.WriteLine();
    }
}

void PrintArrayResult(double[] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("{0:f3} ", array[i]);
    }
    Console.WriteLine();
}
int CheckIntegerNumbers (string messageForUser)
{
    int number = 0, i = 0; 
    string userNumber = string.Empty;
    string definitionNumber = "целым";
    bool success = false;
    while(i == 0) 
    {
        Console.Write(messageForUser);
        userNumber = Console.ReadLine();
        success = int.TryParse(userNumber, out number);
        if(success) 
        {
            number = int.Parse(userNumber);
            i = 1;
        }
        else PrintErrorMessageEnterNumber(userNumber, definitionNumber);
        Console.WriteLine();
    }
    return number;
}

int CheckNaturalNumbers (string messageForUser)
{
    int number = 0, i = 0;
    string userNumber = string.Empty;
    string definitionNumber = "натуральным";
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
            else PrintErrorMessageEnterNumber(userNumber, definitionNumber); 
        }
        else 
        {
            PrintErrorMessageEnterNumber(userNumber, definitionNumber);
        } 
        Console.WriteLine();
    }
    return number;
}

int EnterIntegerNumber(string direction, string designation)
{
    string messegeForUser = string.Empty;
    messegeForUser = $"Введите {direction} {designation} массива: ";
    int result = CheckNaturalNumbers(messegeForUser); // проверить
    return result; 
}

// Генерация двумерного массива случайных целых чисел
int minRangeValue = 1, maxRangeValue = 100;
int row, column;
string messegeForUser = string.Empty;
Console.WriteLine("Производится генерация двумерного массива. По умолчанию количество строк " + 
                "и столбцов генерируются автоматически из диапазона от 1 до 100.");
Console.Write("Ели Вы желаете изменить порядок генерации, введите любой символ, если нет," + 
                " просто нажмите Enter");
if(Console.ReadLine() != "")
{
    // Выбор варианта ввода размерности массива
    Console.WriteLine("Выберете вариант определения размерности массива: ");
    Console.WriteLine("Вариант 1. Количество строк и столбцов задаются пользователем.");
    Console.WriteLine("Вариант 2. Пользователь изменяет предустановленный диапазон генерации " + 
                        "случайных чисел.");
    int optionNumber = 0;
    while(optionNumber != 1 && optionNumber != 2)
    {
        messegeForUser = "Введите номер варианта: ";
        optionNumber = CheckNaturalNumbers(messegeForUser);
        if(optionNumber != 1 && optionNumber != 2)
        {
            TitleInputErrorMessage(); 
            Console.Write($"Вами введён не существующий номер варианта: {optionNumber}.");
            Console.WriteLine("Возможные номера вариантов: 1 или 2.");
        }
    }
    if(optionNumber == 1)
    {
        string direction = string.Empty;
        string designation = string.Empty;
        direction = "количество";
        designation = "строк";
        row = EnterIntegerNumber(direction, designation);
        designation = "столбцов";
        column = EnterIntegerNumber(direction, designation);    
    }
    else
    {
        Console.WriteLine("По умолчанию количество строк и столбцов генерируются автоматически " + 
                "из диапазона от 1 до 100.");
        Console.Write("Ели Вы желаете изменить максимальное значение диапазона, введите любой " + 
                    "символ, если нет, просто нажмите Enter");
        if(Console.ReadLine() != "")
        {
            messegeForUser = "Введите новое максимальное значение диапазона: ";
            maxRangeValue = CheckNaturalNumbers(messegeForUser);
        }
            row = GenerationRandomIntegerNumbers(minRangeValue, maxRangeValue);
            column = GenerationRandomIntegerNumbers(minRangeValue, maxRangeValue);
    }
}
else
{
    row = GenerationRandomIntegerNumbers(minRangeValue, maxRangeValue);
    column = GenerationRandomIntegerNumbers(minRangeValue, maxRangeValue);
}
int[,] array = new int[row, column];
double[] arrayResult = new double[column];
// Определение границ генерации значений массива
minRangeValue = -999; 
maxRangeValue = 999;
Console.WriteLine("По умолчанию значения элементов массива генерируются из диапазона " + 
                "от -999 до 999.");
Console.Write("Ели Вы желаете изменить диапазон генерации, введите любой символ, если нет," + 
                " просто нажмите Enter");
if(Console.ReadLine() != "")
{
    Console.WriteLine("Внимание! Модуль значения границы не должны содержать более 5 разрядов.");
    minRangeValue = 100000;
    while(Math.Abs(minRangeValue) >= 100000)
    {
        messegeForUser = "Введите новое минимальное значение диапазона значений: ";
        minRangeValue = CheckIntegerNumbers(messegeForUser);
        if(Math.Abs(minRangeValue) >= 100000)
        {
            TitleInputErrorMessage(); 
            Console.WriteLine($"Модуль введённого значения границы диапазона: {minRangeValue}" + 
                                " содержит более 5 разрядов.");
        }
    }
    maxRangeValue = minRangeValue - 1;
    while(maxRangeValue <= minRangeValue || Math.Abs(maxRangeValue) >= 100000)
    {
        messegeForUser = "Введите новое максимальное значение диапазона значений: ";
        maxRangeValue = CheckIntegerNumbers(messegeForUser);
        if(maxRangeValue <= minRangeValue) 
        {
            TitleInputErrorMessage(); 
            Console.WriteLine($"Введённоe максимальное значение границы диапазона: " + 
                        $"{maxRangeValue}, меньше или равно минимальному: {minRangeValue}.");
        }
        else
        {
            if(Math.Abs(maxRangeValue) >= 100000)
            {
                TitleInputErrorMessage(); 
                Console.WriteLine($"Модуль введённого значения границы диапазона: " + 
                                $"{maxRangeValue} содержит более 5 разрядов.");  
            }
        }
    }
}

FillArrayRandomintegerNumbers(array, minRangeValue, maxRangeValue);
FillArrayArithmeticMeanColumns(arrayResult, array);

// Печать исходного массива на экран (опционально)
Console.Write("Ели Вы не желаете просмотреть заданный массив, введите любой символ, для " + 
                "просмотра просто нажмите Enter");
if(Console.ReadLine() == "")
{
    Console.WriteLine($"Задан двумерный массив ({row}x{column}): ");
    PrintArray(array);
    Console.WriteLine();
}
// Печать итогового массива на экран (опционально)
Console.Write("Ели Вы не желаете просмотреть заданный массив, введите любой символ, для " + 
                "просмотра просто нажмите Enter");
if(Console.ReadLine() == "")
{
    Console.WriteLine($"В результате преобразования получен массив ({column}): ");
    PrintArrayResult(arrayResult);
    Console.WriteLine();
}


