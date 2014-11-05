//Given a sorted array and a target value, 
//return the index if the target is found. 
//If not, return the index where it would be if it were inserted in order.
//
//You may assume no duplicates in the array.
//
//Here are few examples.
//[1,3,5,6], 5 → 2
//[1,3,5,6], 2 → 1
//[1,3,5,6], 7 → 4
//[1,3,5,6], 0 → 0

//use a modified binary search, 
//only add code to handle ifa[mid-1] < target < a[mid]

using System;
using System.Collections.Generic;
using System.Collections;

namespace SearchInsertPosition
{
	class Finder
	{
		public static int FindInsertPosition(int[] arr, int n)
		{
			int l = 0;
			int r = arr.Length - 1;
			while (l <= r) {
				int mid = (l + r) / 2;
				if (arr [mid] == n)
					return mid;
				//modify binary search here
				else if (mid > 1 && arr [mid - 1] < n && arr [mid] > n)
					return mid;
				else if (arr [mid] > n)
					r = mid - 1;
				else
					l = mid + 1;
			}
			return l;
		}
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] test = new int[]{ 1, 3, 5, 6 };
			Console.WriteLine (Finder.FindInsertPosition (test, 0));
			Console.WriteLine (Finder.FindInsertPosition (test, 18));
			Console.WriteLine (Finder.FindInsertPosition (test, 5));
			Console.WriteLine (Finder.FindInsertPosition (test, 4));
		}
	}
}
