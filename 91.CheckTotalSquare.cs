/**
 * Given a positive Integer Number, Check if the number is a totall square number
 * total square number: 1,4,9,16,25,36
 * 
 * use Newton's method to solve this problem:
 * make initial guess: n = (num/2)+1;
 * now n > num/n, so n is not the answer.
 * Then we average n and num/n, n = (n+(num/n))/2;
 * Then check if n is equal to num/n, if it is, n is the sqrt
 * if it is not, we repeat n= (n+(num/n))/2 to make n closer to num/n
 * until we find n=num/n
 * 
 * 
 * 
 * */


using System;

namespace CheckTotalSquare
{
	class Finder{
		public static bool CheckTotalSqrt(int num){
			if (num == 0)
				return true;
			int n = (num / 2) + 1;  //initial guess, now n must be greater than sqrt
			int n1 = (n + (num / n)) / 2; // upperbound: n, lowerbound: num/n=1
			while (n1 < n) {
				n = n1;
				n1 = (n + (num / n)) / 2; //upperbound: 
			}

			if (n * n == num)
				return true;
			else
				return false;
		}

		//easier to understand, key point is to make n closer to num/n at each step
		public static bool IsTotalSqrt(int num){
			if (num == 0)
				return true;
			int n = (num / 2) + 1; //initial guess, upperbound: n, lowerbound: num/n
			while (n > num / n) {
				n = (n + (num / n)) / 2; // make n closer and closer to num/n, eventually find the sqrt
			}
			if (n * n == num)
				return true;
			else
				return false;
		}
			
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (Finder.CheckTotalSqrt(9));
			Console.WriteLine (Finder.CheckTotalSqrt(16));
			Console.WriteLine (Finder.CheckTotalSqrt(17));
			Console.WriteLine (Finder.CheckTotalSqrt(157));
			Console.WriteLine (Finder.CheckTotalSqrt(4356));

			Console.WriteLine (Finder.IsTotalSqrt(9));
			Console.WriteLine (Finder.IsTotalSqrt(16));
			Console.WriteLine (Finder.IsTotalSqrt(17));
			Console.WriteLine (Finder.IsTotalSqrt(157));
			Console.WriteLine (Finder.IsTotalSqrt(4356));
		}
	}
}
