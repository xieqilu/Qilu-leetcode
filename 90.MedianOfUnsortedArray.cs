/**
 * Find the median of an unsorted array
 * 
 * Use QuickSelect to find kth smallest element in array
 * 
 * two cases:
 * 1, the number of elements in given array is even
 * 2, the number of elements in given array is odd
 * 
 * */

using System;
using System.Collections.Generic;

namespace MedianInUnsortedArray
{
	class Finder{

		public static int FindMedian(int[] arr){ //time: O(n)
			List<int> temp = new List<int> ();
			foreach (int i in arr)
				temp.Add (i);

			int length = temp.Count;
			int median = 0;
			if (length % 2 == 0) {  //number of elements in arr is even
				int first = FindMedianHelper (length / 2, temp);
				int second = FindMedianHelper (length / 2 + 1, temp);
				median = (first + second) / 2;
			} 
			//number of elements in arr is odd
			else
				median = FindMedianHelper (length / 2 + 1, temp);
			return median;

		}

		//find kth smallest element in list using QuickSelect
		private static int FindMedianHelper(int k, List<int> list){ //time: average O(n), F(n) = O(n) + F(n/2);  Worst: likely O(n^2)
			List<int> left = new List<int> ();
			List<int> right = new List<int> ();
			int pivot = list [0];
			foreach (int i in list) { //O(n)
				if (i < pivot)
					left.Add (i);
				if (i > pivot)
					right.Add (i);
			}
			if (left.Count < k - 1)
				return FindMedianHelper (k - left.Count - 1, right); 
			else if (left.Count > k - 1)
				return FindMedianHelper (k, left);
			else
				return pivot;

		}
	}


	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] test = new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }; //4
			int[] test1 = new int[]{ 1 }; //1
			int[] test2 = new int[]{ 1, 2, 3, 4, 5}; //3
			int[] test3 = new int[]{ 1, 2, 3, 4, 6, 7, 8,9 }; //5
			int[] test4 = new int[]{ 10,11,12,14,15,16};//13

			Console.WriteLine (Finder.FindMedian (test));
			Console.WriteLine (Finder.FindMedian (test1));
			Console.WriteLine (Finder.FindMedian (test2));
			Console.WriteLine (Finder.FindMedian (test3));
			Console.WriteLine (Finder.FindMedian (test4));
		}
	}
}
