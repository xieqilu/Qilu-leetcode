//Math.abs(b): get the absolute value of b
//Math.Pow(a,b): return a^b

using System;

namespace SelfDefinedPow
{
	public class TestPow
	{
		public static double Pow(double a, int b)
		{
			double result = 1;
			for (int i = 0; i < Math.Abs (b); i++) {
				if (b > 0)
					result *= a;
				else if (b < 0) {
					if (a != 0)
						result /= a;
					else
						return 0;
				} else
					return 1;
			}
			return result;
		}
	}
		

	class MainClass
	{
		public static void Main (string[] args)
		{
			double a = 0;
			int b = 0;
			double result = TestPow.Pow (a, b);
			Console.WriteLine (result);
		}
	}
}
