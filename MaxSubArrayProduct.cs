//Find the contiguous subarray within an array
//that has the largest product
//Example: input: {1,4,5,3,-1,-6} output:360

using System;
using System.Collections.Generic;

namespace MaxSubArrayProduct
{
	public class Finder
	{
		private static int Max(int x, int y)
		{
			return (x > y) ? x : y;
		}

		private static int Min(int x, int y)
		{
			return (x < y) ? x : y;
		}

		private static bool PreTest(List<int> a) //handle edge case
		{										 //{0,0,-2,0} or {0,0,0} or{0,-2,0,-4,0,-5}}
			for (int i = 0; i < a.Count; i++) {
				if (a [i] > 0)
					return true;
				if (i != 0 && a [i] < 0 && a [i - 1] < 0)
					return true;
			}
			return false;
		}

		public static int FindMaxProduct(List<int> a)
		{
			if (PreTest (a)) {
				int MaxHere = 1, MinHere = 1, MaxSoFar = 1;
				foreach (int e in a) {
					if (e > 0) {
						MaxHere = MaxHere * e;
						MinHere = Min (MinHere * e, 1); //make sure MinHere <=1
					} else if (e == 0) {
						MaxHere = 1;//reset MaxHere and MinHere
						MinHere = 1;
					} else {
						int temp = MaxHere;
						MaxHere = Max (MinHere * e, 1); //make sure MaxHere >=1
						MinHere = temp * e;
					}
					MaxSoFar = Max (MaxSoFar, MaxHere);
				}
				return MaxSoFar;
			} else
				return 0;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			List<int> test = new List<int> (){ 2, -5, -3, 6, -9 };
			List<int> test2 = new List<int> () { 0, 0, -2, 0 };
			List<int> test3 = new List<int> (){ 0, 0, 0 };
			List<int> test4 = new List<int> (){ 0, 0, 0, 5 };
			List<int> test5 = new List<int> (){ 0, -1,0,0,-4 };
			Console.WriteLine (Finder.FindMaxProduct (test));
			Console.WriteLine (Finder.FindMaxProduct (test2));
			Console.WriteLine (Finder.FindMaxProduct (test3));
			Console.WriteLine (Finder.FindMaxProduct (test4));
			Console.WriteLine (Finder.FindMaxProduct (test5));
		}
	}
}
