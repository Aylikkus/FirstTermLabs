using System;

namespace TwoDimArr
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            double sumDiag = 0, sumI = 0, mult;

            Console.WriteLine("Введите размер двумерного массива (n x n)");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine($"Введите строку i (1-{n})");
            int i  = int.Parse(Console.ReadLine()) - 1;

            // В случае если пользователь ввёл несуществующую строку
            while (i + 1 > n) {
                Console.WriteLine($"Такой строки нет, введите заново! (1-{n})");
                i  = int.Parse(Console.ReadLine()) - 1;
            }

            Console.WriteLine("Введите начало интервала чисел массива");
            int intStart = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите конец интервала чисел массива (>{intStart})");
            int intEnd = int.Parse(Console.ReadLine());

            // В случае, если пользователь неправильно ввёл конец интервала
            while ( intEnd < intStart ) {
                Console.WriteLine($"Введите значение больше начального интервала! ({intStart})");
                intEnd = int.Parse(Console.ReadLine());
            }

            // Объявление двумерного (квадратного) массива
            double[,] array = new double[n, n];

            // Заполнение массива случайными числами
            Console.WriteLine("\nМассив представлен в виде:");
            for (int row = 0; row < n; row++) {
                array.SetValue(rand.Next(intStart, intEnd) + rand.NextDouble(), 0, row);
                for (int column = 0; column < n; column++) {
                    array.SetValue(rand.Next(intStart, intEnd) + rand.NextDouble(), row, column);
                    Console.Write(array[row, column] + "\t");
                }
                Console.WriteLine();
            }
            
            // Нахождение суммы главной диагонали
            for (int mainDiag = 0; mainDiag < n; mainDiag++) {
                sumDiag += array[mainDiag, mainDiag];
            }
            Console.WriteLine($"\nСумма главной диагонали: {sumDiag}");

            // Нахождение суммы строки, введённой пользователем
            for (int row = 0; row < n; row++) {
                sumI += array[i, row];
            }
            Console.WriteLine($"Сумма строки {i + 1}: {sumI}");

            // Нахождение произведения сумм и последующий вывод на экран
            mult = sumDiag * sumI;
            Console.WriteLine($"Произведение двух сумм: {mult}");
        }
    }
}
