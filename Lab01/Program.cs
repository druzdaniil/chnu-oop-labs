namespace Lab01;
using System;

class Program
{
    static void Main(string[] args)
    {
        int a1 = 10;
        Int32 a2 = 11;

        float a3 = 3.14F;
        Single a4 = 3.15F;

        string a5 = "Daniil";
        String a6 = "Druz";

        ulong a7 = 100;
        UInt64 a8 = 10000;

        var a9 = 'd';

        int? nullableVariable = null;

        long b1 = a1;
        decimal b2 = (decimal)a3;

        bool flag = true;

        while (flag)
        { 
            Console.WriteLine("1 - Ввести ім'я");
            Console.WriteLine("2 - Ввести вік (Parse)");
            Console.WriteLine("3 - Ввести вік (TryParse)");
            Console.WriteLine("4 - Інформація про середовище");
            Console.WriteLine("5 - Демонстрація checked/unchecked");
            Console.WriteLine("6 - Завершити виконання програми");
            Console.Write("Оберіть один з доступних варіантів: ");
            
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Помилка: введіть номер опції від 1 до 4.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Введіть ім'я: ");
                    string name = Console.ReadLine();
                    Console.WriteLine($"Ваше ім'я: {name}");
                    Console.WriteLine();
                    break;
                
                case 2:
                    Console.Write("Введіть вік: ");
                    string age1 = Console.ReadLine();
                    Console.WriteLine($"Ваш вік: {int.Parse(age1)}");
                    Console.WriteLine($"Ваш вік, збільшений вдвічі: {int.Parse(age1) * 2}");
                    Console.WriteLine();
                    break;
                
                case 3:
                    Console.Write("Введіть вік: ");
                    string age2 = Console.ReadLine();
                    bool isParsed = int.TryParse(age2, out int ageParsed);

                    if (isParsed)
                    {
                        Console.WriteLine($"Ваш вік: {ageParsed}");
                        Console.WriteLine($"Ваш вік, збільшений вдвічі: {ageParsed * 2}");
                        Console.WriteLine();
                    } else
                    {
                        Console.WriteLine("Error: неправильно введено вік");
                        Console.WriteLine();
                    }
                    break;
                
                case 4:
                    Console.WriteLine($"Операційна система: {Environment.OSVersion}");
                    Console.WriteLine($"Версія .Net: {Environment.Version}");
                    Console.WriteLine($"Чи є система 64-бітною: {Environment.Is64BitOperatingSystem}");
                    Console.WriteLine();
                    break;
                
                case 5:
                    int n = int.MaxValue;
                    Console.WriteLine($"Максимальне значення int: {n}");
                    Console.WriteLine($"unchecked: {unchecked(n + 1)}");
                    Console.WriteLine($"checked: {checked(n + 1)}");
                    Console.WriteLine();
                    break;
                    
                case 6:
                    flag = false;
                    Console.WriteLine("Виконання програми завершено");
                    Console.WriteLine();
                    break;
                
                default:
                    Console.WriteLine("Правильно введіть номер опції");
                    Console.WriteLine();
                    break;
            }
            
        }

        
    }
}