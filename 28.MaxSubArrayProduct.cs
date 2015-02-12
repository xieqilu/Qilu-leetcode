//Find the contiguous subarray within an array
//that has the largest product
//Example: input: {1,4,5,3,-1,-6} output:360

/**
 * Solution:
 * use two int maxHere and minHere to keep track of the current
 * max and min value.
 * make sure that maxHere is alwasys >=1 and minHere is always <=1.
 * 
 * foreach int i in array:
 * if i>0: maxHere = maxHere*i, minHere = minHere*i
 * if minHere*i >1, minHere = 1; then try to update
 * finalMax using maxHere.
 * 
 * if i=0: reset both minHere and maxHere to 1, because 0 cannot
 * be included. 
 * 
 * if i<0: int temp = maxHere,maxHere = minHere*i, minHere = temp*i
 * if maxHere*i<1, maxHere=1; then try to update
 * finalMax using maxHere
 * 
 * Note two important edge case:
 * 1, the Max product is 0. {0,0,-2}, {0,-2,0,-3,0,-5}, {0,0,0};
 * 2, the Max product is a negative number. occurs when array has
 * only one element and it's a negative number. {-3}, {-4};
 * 
 * So we need to do a pretest to exclude the above two edge cases.
 * Then if the pretest fail, we manually check if it's edge case#1,
 * if it is, return a[0], otherwise, return 0;
 * */

using System;
using System.Collections.Generic;

namespace MaxSubArrayProduct
{
	public class Finder
	{
	
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

		public static int FindMaxProductEasy(List<int> a){
			if (!PreTest (a)) {
				if (a.Count == 1 && a [0] < 0)
					return a [0];
				else
					return 0;
			}

			int maxHere = 1, minHere = 1, finalMax = 1;
			foreach (int i in a) {
				if (i > 0) {
					maxHere = maxHere * i;
					minHere = minHere * i;
					if (minHere > 1)
						minHere = 1;
				} else if (i == 0) {
					maxHere = 1;
					minHere = 1;
				} else {  //i<0
					int temp = maxHere;
					maxHere = minHere * i;
					minHere = temp * i;
					if (maxHere < 1)
						maxHere = 1;
				}
				if (maxHere > finalMax)
					finalMax = maxHere;
			}
			return finalMax;
		}


		private static int Max(int x, int y)
		{
			return (x > y) ? x : y;
		}

		private static int Min(int x, int y)
		{
			return (x < y) ? x : y;
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
			} else {
				if (a.Count == 1 && a [0] < 0)
					return a [0];
				else
					return 0;
			}

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
			List<int> test6 = new List<int> (){-4,-3};
			Console.WriteLine (Finder.FindMaxProduct (test));
			Console.WriteLine (Finder.FindMaxProduct (test2));
			Console.WriteLine (Finder.FindMaxProduct (test3));
			Console.WriteLine (Finder.FindMaxProduct (test4));
			Console.WriteLine (Finder.FindMaxProduct (test5));
			Console.WriteLine (Finder.FindMaxProduct (test6));
			Console.WriteLine (Finder.FindMaxProductEasy (test));
			Console.WriteLine (Finder.FindMaxProductEasy (test2));
			Console.WriteLine (Finder.FindMaxProductEasy (test3));
			Console.WriteLine (Finder.FindMaxProductEasy (test4));
			Console.WriteLine (Finder.FindMaxProductEasy (test5));
			Console.WriteLine (Finder.FindMaxProductEasy (test6));
		}
	}
}
