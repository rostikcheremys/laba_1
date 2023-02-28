using System;

namespace Program
{
    internal class Program
    {
        static int[] RandomArray()
        {
            Console.WriteLine("Введiть кiлькiсть елементiв:");
            int number = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[number];
            Random random = new Random();
            for (int i = 0; i < number; i++)
            {
                array[i] = random.Next(-100, 100);
            }
            return array;
        }
        static int[] ArrayInputEnter()
        {
            Console.WriteLine("Введiть кiлькiсть елементiв:");
            int number = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[number];
            Console.WriteLine("Введiть числа через Enter:");
            for (int i = 0; i < number; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            return array;             
        }
        static int[] ArrayInputSpace()
        {
            Console.WriteLine("Введiть числа через Space:");
            string numbers = Console.ReadLine();
            string[] stringArray = numbers.Split(' ');
            int[] array = new int[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                array[i] = Convert.ToInt32(stringArray[i]);
            }
            return array;
        }
        static void PrintArray(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
        }
        static int LastNegativeNumber(int[] array) 
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] < 0)
                {
                    return i;
                }
            }
            return -1;
        }
        static bool LastNegative(int[] array, out int lastNegative)
        {
            bool negativeNumber = false;
            lastNegative = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (!negativeNumber && array[i] < 0)
                {
                    negativeNumber = true;
                    lastNegative = i;
                }
            }
            return negativeNumber;
        }
        static long CalculationArray(int[] array, int lastNegative)
        {
            long result = 1;
            for (int i = lastNegative + 1; i < array.Length; i++)
            {
                result *= array[i];
            }
            return result;
        }
        static void PrintResult(long result)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Добуток елементiв масиву, якi розмiщенi пiсля останнього вiд'ємного числа: {result}");
            Console.ResetColor();
        }
        static void PrintErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("У масивi вiдсутнi вiд'ємнi елементи");
            Console.ResetColor();
        }
        static void CheckNegativeFirst( int[] array)
        {
            PrintArray(array);
            int lastNegative;
            bool negative = LastNegative(array, out lastNegative);
            if (negative)
            {
                long result = CalculationArray(array, lastNegative);
                PrintResult(result);
            }
            else
            {
                PrintErrorMessage();
            }
        }
        static void CheckNegativeSecond( int[] array)
        {
            int lastNegative = LastNegativeNumber(array);
            if (lastNegative >= 0)
            {
                long result = CalculationArray(array, lastNegative);
                PrintResult(result);
            }
            else
            {
                PrintErrorMessage();
            }
        }
        static void CheckNegativeThird( int[] array)
        {
            int lastNegative = LastNegativeNumber(array);
            if (lastNegative != -1)
            {
                long product = CalculationArray(array, lastNegative);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"Добуток елементiв масиву, якi розмiщенi пiсля останнього вiд'ємного числа: {product}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("У масивi вiдсутнi вiд'ємнi елементи");
                Console.ResetColor();
            }
        }
        static void ChoiceUser()
        {
            
        }
        static void BlockFirst()
        {
            int[] array = RandomArray();
            CheckNegativeFirst(array);
        }
        static void BlockSecond()
        {
            int[] array = ArrayInputEnter();
            CheckNegativeSecond(array);
        }
        static void BlockThird()
        {
            int[] array = ArrayInputSpace();
            CheckNegativeThird(array);
            
        }
        public static void Main(string[] args)
        {

            uint choice;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Як бажаєте заповнити масив?");
                Console.WriteLine("Введiть 1 для випадкового заповнення масиву:");
                Console.WriteLine("Введiть 2 для вводу вручну в окремих рядках(через Enter):");
                Console.WriteLine("Введiть 3 для вводу вчучну в одному рядку(через Space):");
                Console.WriteLine("Введiть 0 для виходу з програми!");
                Console.ResetColor();
                choice = Convert.ToUInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        BlockFirst();
                        break;
                    case 2:
                        BlockSecond();
                        break;
                    case 3:
                        BlockThird();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Команда не розпiзнана!");
                        Console.ResetColor();
                        break;
                }
            } while (choice != 0);
        }
    }
}
