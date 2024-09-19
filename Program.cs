using System;
using System.IO;

namespace MenuProject
{
    class Program
    {
        // Поле loremFilePath: Це приватне статичне поле, яке зберігає шлях до текстового файлу lorem.txt.Воно використовується для доступу до файлу, коли потрібно зчитати текст для виводу кількості слів.
	 	// Метод ShowMenu(): Це статичний метод, який відповідає за відображення меню на екрані та обробку вибору користувача.Він безперервно викликається у циклі, поки користувач не вибере опцію виходу.
        // Опис поля
        // Поле зберігає шлях до файлу з текстом
        private static string loremFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lorem.txt");

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ShowMenu();
        }

        // Опис методу
        // Метод ShowMenu відповідає за виведення меню і обробку вибору користувача
        static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Показати кількість слів із тексту 'Lorem Ipsum'");
                Console.WriteLine("2. Виконати математичну операцію");
                Console.WriteLine("3. Вийти");

                Console.Write("Введіть номер пункту меню: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowLoremWordsCount();
                        break;
                    case "2":
                        PerformMathOperation();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір, спробуйте знову.");
                        break;
                }
            }
        }

        static void ShowLoremWordsCount()
        {
            try
            {
                string text = File.ReadAllText(loremFilePath);
                
                Console.Write("Скільки слів вивести з тексту? ");
                if (int.TryParse(Console.ReadLine(), out int wordCount))
                {
                    string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    double repeatNtimes = wordCount / words.Length;
                    for (int i = 0; i < Math.Ceiling(repeatNtimes); i++)
                    {
                        Console.Write(String.Join(' ', words));
                    }
                    for (int i = 0; i < wordCount % words.Length; i++)
                    {
                        Console.Write(' ' + words[i]);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Будь ласка, введіть коректне число.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл з текстом не знайдено.");
            }
        }

        static void PerformMathOperation()
        {
            Console.WriteLine("Математична операція: додавання двох чисел.");
            Console.Write("Введіть операцію: ");
            string operation = Console.ReadLine() ?? "+";
            Console.Write("Введіть перше число: ");
            if (double.TryParse(Console.ReadLine(), out double num1))
            {
                Console.Write("Введіть друге число: ");
                if (double.TryParse(Console.ReadLine(), out double num2))
                {
                    double result = MathOperationProcess(num1, num2, operation);
                    Console.WriteLine($"Результат: {result}");
                }
                else
                {
                    Console.WriteLine("Невірний формат числа.");
                }
            }
            else
            {
                Console.WriteLine("Невірний формат числа.");
            }
        }

        static private double MathOperationProcess(double num1, double num2, string operation = "+") {
            switch(operation)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                default:
                    Console.WriteLine("Operation is not supported: " + operation);
                    return 0;
            }
        }
    }
}