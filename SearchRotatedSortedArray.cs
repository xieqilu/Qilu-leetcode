//Searching an element in a rotated sorted array
//Find how many times an sorted array has been rotated

using System;
using System.Collections.Generic;
using System.Collections;

namespace SearchRotatedSortedArray
{
	public class Finder
	{
		public static int FindElement(int[] A, int key) //Time: O(logn)
		{
			int length = A.Length;
			int left = 0;
			int right = length - 1;

			while (left<= right) {
				int middle = left + (right - left) / 2;
				if (A [middle] == key)
					return middle;
				if (A [middle] <= A [left]) { 
					if (key > A [middle] && key <= A [right]) //key is at right sub array
						left = middle + 1;
					else
						right = middle - 1;
				} 

				else {
					if (key < A [middle] && key >= A [left]) //key is at left sub array
						right = middle - 1;
					else
						left = middle + 1;
				}
			}

			return -1; // cannot find the element

		}

		public static int FindRotationTimes(int[] A) //return how many times the array is rotated
		{
			int length = A.Length;
			int left = 0;
			int right = length - 1;

			while (left < right) {
				int middle = left + (right - left) / 2;
				if (A [middle] > A [right])//pivot is at the right sub array
					left = middle + 1;
				else 
					right = middle;
			}
			return left;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] test = new int[8]{ 5, 6, 7, 0, 1, 2, 3,4 };
			Console.WriteLine (Finder.FindElement (test, 3));
			Console.WriteLine (Finder.FindRotationTimes (test));
		}
	}
}
