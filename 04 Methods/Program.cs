using System;
using System.Globalization;

/* Данная программа вычисляет возраст человека
*  по дате рождения, причём делает это двумя методами
*  один возвращает значение, а другой делает это через
*  параметр */

namespace Methods
{
    class Program
    {
        // Через возвращение значения
        static int Age(string birthDayDateString) {
            var ruCulture = new CultureInfo("ru-RU");
            DateTime birthDayDate =  DateTime.Parse(birthDayDateString, ruCulture);

            // Задание переменных текущей даты
            DateTime currentDayDate = DateTime.Today;
            int currentDay = currentDayDate.Day;
            int currentMonth = currentDayDate.Month;
            int currentYear = currentDayDate.Year;

            // Задание переменных даты рождения
            int birthDay = birthDayDate.Day;
            int birthMonth = birthDayDate.Month;
            int birthYear = birthDayDate.Year;

            // Вычисление возраста
            int age = currentYear - birthYear;
            if (currentMonth - birthMonth < 0) age--;
            if (currentMonth == birthMonth && currentDay < birthDay) age--;

            return age;
        }

        // Через параметр
        static void Age(string birthDayDateString, out int age) {
            var ruCulture = new CultureInfo("ru-RU");
            DateTime birthDayDate =  DateTime.Parse(birthDayDateString, ruCulture);

            // Задание переменных текущей даты
            DateTime currentDayDate = DateTime.Today;
            int currentDay = currentDayDate.Day;
            int currentMonth = currentDayDate.Month;
            int currentYear = currentDayDate.Year;

            // Задание переменных даты рождения
            int birthDay = birthDayDate.Day;
            int birthMonth = birthDayDate.Month;
            int birthYear = birthDayDate.Year;

            // Вычисление возраста
            age = currentYear - birthYear;
            if (currentMonth - birthMonth < 0) age--;
            if (currentMonth == birthMonth && currentDay < birthDay) age--;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите дату рождения (дд.мм.гггг)");
            string birthDayDateString = Console.ReadLine();

            Console.WriteLine("(Через имя) Возраст: " + Age(birthDayDateString));

            Age(birthDayDateString, out int age);
            Console.WriteLine($"(Через параметры) Возраст: " + age);
        }
    }
}
