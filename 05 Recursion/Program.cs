using System;

namespace Recursion
{
    public class Program
    {
        static double NestedRoot(double n) {

            // Сообщение об ошибке
            if (n < 2) {
                Console.WriteLine("Введите значение больше единицы!");
                return 0;
            }

            // Введение переменной максимального коэффициента
            // Присвоение n начального коэффициента
            double max = n;
            n = 2;
            
            // Локальный метод рассчёта вложенного корня
            double RecursCalc(double n) {

                // "Хвост" вложеннного корня
                if (n == max) {
                    return Math.Sqrt(1 + n);
                }

                return Math.Sqrt(1 + (n * RecursCalc(n + 1)));
            }

            return RecursCalc(n);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Введите число n(>1): ");
            double n = double.Parse(Console.ReadLine()); 

            Console.WriteLine("Значение функции: " + NestedRoot(n));
        }

    }
}