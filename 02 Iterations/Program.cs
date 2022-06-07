/* Данная программа расчитывает сумму сходящегося ряда 
*  и корень функции на промежутке итерационным методом */

namespace Iterations 
{
	class Program
	{
		// Метод расчёта факториала
		public static int Factorial (int n)
		{
			int factorial = 1;

			for (int i = 1; i <= n; i++)
			{
				factorial *= i;
			}

			return factorial;
		}

		// Метод расчёта суммы сходящегося ряда
		public static double ConvergentSeriesSum (double x, double e = 0.0001)
		{
			double startVal = 1, sum = 0, term, temp;
			
			do 
			{
				term = Math.Pow(-x, startVal) / Factorial((int)Math.Pow(2, startVal - 1));
				temp = Math.Pow(-x, startVal + 1) / Factorial((int)Math.Pow(2, startVal));
				sum += term;

				startVal++;
			} while (Math.Abs(term - temp) > e);

			return sum;
		}
		
		// Метод расчёта корня на заданном промежутке методом хорд
		public static double ChordMethod(double x0, double x1, double e = 0.0001)
		{
			double x2 = 0, fx0, fx1, fx2;

			while (Math.Abs(x1 - x0) > e) 
			{
				fx0 = Math.Sqrt(2 - Math.Pow(x0, 2)) - Math.Pow(Math.E, x0);
				fx1 = Math.Sqrt(2 - Math.Pow(x1, 2)) - Math.Pow(Math.E, x1);

				x2 = x0 - (((x1 - x0) / (fx1 - fx0)) * fx0);
				fx2 = Math.Sqrt(2 - Math.Pow(x2, 2)) - Math.Pow(Math.E, x2);

				if ((fx0 * fx2) < 0) { x1 = x2; } { x0 = x2; }
				if (Math.Abs(fx2) <= e) { break; }
			}

			return x2;
		}

		static void Main(string[] args)
		{
			Console.Write("Введите число x: ");
			double x = double.Parse(Console.ReadLine());

			Console.Write("Введите x0: ");
			double x0 = double.Parse(Console.ReadLine());

			Console.Write("Введите x1: ");
			double x1 = double.Parse(Console.ReadLine());

			Console.WriteLine($"\nСумма сходящегося ряда: " + 
				ConvergentSeriesSum(x).ToString("N7"));

			Console.WriteLine($"Значение корня на заданном числовом промежутке = " + 
				ChordMethod(x0, x1).ToString("N7"));
		}

	}
}
