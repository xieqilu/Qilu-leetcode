//A peak element is an element that is GREATER than its neighbors.
//
//The array may contain multiple peaks, in that case return the index to any one of the peaks is fine.
//
//You may imagine that num[-1] = num[n] = -∞.
//
//For example, in array [1, 2, 3, 1], 3 is a peak element and your function should return the index number 2.
//
//In this case, there could be no peak element in an array. And in the worst case, we need to visit each 
//element to determine if there is a peak element in the array.

//Therefore, in the worst case, the time complexity could not be better than O(n)

using System;
using System.Collections;
using System.Collections.Generic;

namespace FindPeakInArray
{
	class Finder
	{
		public static int FindPeak(int[] Input) //Worst Case: O(n), Average Case is better than that
		{
			int low = 0;
			int high = Input.Length - 1;
			int PeakIndex = FindPeakRecursive (Input, high, low);
			return PeakIndex;
		}

		//recursive call
		public static int FindPeakRecursive(int[] Input, int high, int low)
		{
			int n = Input.Length;
			int mid = (high + low) / 2; // do not use high == low, or infinite iteration call
			if (high-low <2)
				return -1;
			else {
				if ((mid == 0 || Input [mid - 1] < Input [mid]) && (mid == n - 1 || Input [mid + 1] < Input [mid]))
					return mid;
				else {
					int temp1 = FindPeakRecursive (Input, mid, low);
					if (temp1 != -1)
						return temp1;
					else {
						int temp2 = FindPeakRecursive (Input, high, mid);
						return temp2;
					}
				}
			}
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] test = new int[]{ 1,4,5,7,2,5,7,6,1};
			int[] test1 = new int[]{1,2,3,4,5,4,3,2,1};
			int[] test2 = new int[]{ 1, 2, 3, 1,4,5, 2, 1 };
			int[] test3 = new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 5 };

			Console.WriteLine (Finder.FindPeak (test));
			Console.WriteLine (Finder.FindPeak (test1));
			Console.WriteLine (Finder.FindPeak (test2));
			Console.WriteLine (Finder.FindPeak (test3));
		}
	}
}

