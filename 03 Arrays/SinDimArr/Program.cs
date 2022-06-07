using System;

namespace SinDimArr
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();

            Console.WriteLine("Введите кол-во элементов массива");
            int length = int.Parse(Console.ReadLine()) + 1, maxValueElement = 0;

            // Высчитывание длины массива
            int arrLength = length - 1;

            Console.WriteLine("Введите начало интервала чисел массива");
            int intStart = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите конец интервала чисел массива (>{intStart})");
            int intEnd = int.Parse(Console.ReadLine());

            // В случае, если пользователь неправильно ввёл конец интервала
            while ( intEnd < intStart ) {
                Console.WriteLine($"Введите значение больше начального интервала! ({intStart})");
                intEnd = int.Parse(Console.ReadLine());
            }

            // Объявление одномерного массива
            double[] array = new double[length];
            double maxValue = double.MinValue, meanValue = 0;

            // Заполнение массива случайными числами
            // Одновременное нахождение максимального значения
            Console.WriteLine("\nНачальный массив: ");
            for (int i = 0; i < arrLength; i++) {
                array[i] = rand.Next(intStart, intEnd);
                if (array[i] > maxValue) { maxValue = array[i]; maxValueElement = i; }
                meanValue += array[i];
                Console.Write(array[i] + " ");
            }

            // Расчёт среднего значения
            meanValue /= length;

            // Преобразование массива, подставление средних значений
            for (int i = maxValueElement + 1; i < arrLength; i++) {
                array[i] = meanValue;
            }

            // Вывод преобразованного массива на экран
            Console.WriteLine("\nПреобразованный массив: ");
            for (int i = 0; i < arrLength; i++) {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine($"\n\nМаксимальное значение массива - {maxValue}\nСреднее значение - {meanValue}");
            Console.Read();
        }
    }
}
