/* Данная программа рассчитывает систему уравнений
*  на определённом промежутке по шагам */

namespace IfStatements
{
	class Program 
	{
		static void Main(string[] args)
		{
			double start, 	// Начало промежутка
				   end,  	// Конец промежутка
				   step,  	// Шаг
				   fx, 		// Функция
				   x; 		// Неизвестная переменная  

			Console.Write("Введите начало промежутка: ");
			string strStart = Console.ReadLine();

			Console.Write("Введите конец промежутка: ");
			string strEnd = Console.ReadLine();

			Console.Write("Введите шаг: ");
			string strStep = Console.ReadLine();

			Console.WriteLine();
			
			// Пытаемся пропарсить строки
			bool parsedStart = double.TryParse(strStart, out start);
			bool parsedEnd   = double.TryParse(strEnd, out end);
			bool parsedStep  = double.TryParse(strStep, out step); 

			if (parsedStart && parsedEnd && parsedStep)
			{
				for (x = start; x <= end; x += step)
				{
					if (x < 0) 
						fx = Math.Pow(Math.Sin(2 * x), 3) - Math.Sqrt(Math.Pow(x, 5) + 10);
					else if (x > 0) 
						fx = Math.Abs(8 - Math.Pow(x, 3)) - 10 * x;
					else 
						fx = 100;
		
					Console.WriteLine($"x = {x} \t fx = {fx.ToString("N3")}");
				}
			}
			// Выводим сообщения об ошибках
			else
			{
				if (!parsedStart || !parsedEnd)
					Console.Write("Значение интервала должно быть числом. ");
		
				if (!parsedStep)
					Console.Write("Значение шага должно быть числом. ");
		
				if (step == 0) 
					Console.Write("Шаг не может быть нулевым. ");

				if (strStart == "" || strEnd == "") 
					Console.Write("Значение интервала не может быть пустым. ");
			}
		}
	}
}
