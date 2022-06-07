using System;

namespace Recursion
{
    public class Program
    {
        // Сортировка слиянием с нижней и верхней границей
        static void MergeSort (char[] array, int low, int high) {

            if (low < high) {

                // Нахождение индекса среднего элемента
                int center =  low + (high - low) / 2;

                // Разбиение массива
                MergeSort(array, low, center);
                MergeSort(array, center + 1, high);

                // Слияние упорядоченных массивов
                Merge(array, low, center, high);
            }
        }

        // Сортировка слиянием если задано только имя массива
        static void MergeSort (char[] array) {
            MergeSort(array, 0, array.Length - 1);
        }

        // Метод для слияния массивов
        static void Merge(char[] array, int low, int center, int high) {

            // Объявление индекса левой и правой границы,
            // индекса записи во временный массив, длины массива
            int left = low, right = center + 1, tempPos = 0, length = high - low + 1;

            // Объявление временного массива
            char[] tempArray = new char[length];

            // Слияние, пока есть хоть один элемент в левой и правой части
            while ((left <= center) && (right <= high)) {

                // Условие, определяющее направление сортировки
                if (array[left] < array[right]) {
                    tempArray[tempPos++] = array[left++];
                } else {
                    tempArray[tempPos++] = array[right++];
                }
            }

            // Остаток левой части массива
            while (left <= center) {
                tempArray[tempPos++] = array[left++];
            }

            // Остаток правой части массива
            while (right <= high) {
                tempArray[tempPos++] = array[right++];
            }

            // Заполнение изначального массива
            for (tempPos = 0; tempPos < length; tempPos++) {
                array[low + tempPos] = tempArray[tempPos];
            }
        }

        public static void Main(string[] args)
        {
            var rand = new Random();

            // Нижнияя и верхняя граница прописных латинских букв
            // Длина массива символов
            int bottomBound = 'a', upperBound = 'z' + 1, length;

            Console.WriteLine("Введите кол-во символов в массиве");
            length = int.Parse(Console.ReadLine());

            // Выделение памяти под массив символов
            char[] array = new char[length];
            
            // Заполнение массива случайными прописными
            // латинскими буквами, с выводом на экран
            Console.WriteLine("\nНеупорядоченный массив: ");
            for (int row = 0; row < array.Length; row++) {
                array[row] = (char)(rand.Next(bottomBound, upperBound));
                Console.Write(array[row]);
            }
            
            // Сортировка массива
            MergeSort(array);

            // Вывод упорядоченного массива
            Console.WriteLine("\n\nУпорядоченный массив: ");
            for (int row = 0; row < array.Length; row++) {
                Console.Write(array[row]);
            }

            Console.ReadLine();
        }
    }
}