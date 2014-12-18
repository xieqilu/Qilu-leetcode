//Given an unsorted array, find the k smallest elements
//
//Array {9, 5, 1, 4, 13, 6}
//k = 3
//Output: 1, 4, 5 

//Note: use QuickSelect, which can select the kth smallest element in linear time
//Then iterate the original array again, add all elements smaller than kth smallest
//element into the result list

//QuickSelect:
//Find the kth (not kth smallest) element in the original array,use it as pivot
//create two lists, left and right, to store left subarray and right subarray
//iterate through array, put all elements smaller than pivot to left subarray
//and put all elements greater than pivot to right subarray

//compare length of left subarray to K. if length < k-1, means the kth smallest element
//is in the right subarray. Then recursively do QuickSelect to the right subarray
//if length > k-1, menas the kth smallest element is in the left subarray, then recursively
//do QuickSelect on the left subarray
//if length == k-1, return pivot.


using System;
using System.Collections.Generic;

namespace KSmallestElementsUnsortedArray
{
	public class Finder
	{
		private static int QuickSelect(List<int> Input, int k) //find kth smallest element in array, Time: O(n)
		{
			List<int> left = new List<int> ();
			List<int> right = new List<int> ();

			int middle = (Input.Count / 2);
			int pivot = Input [middle];

			foreach (int i in Input) {  //O(n)
				if (i < pivot)
					left.Add (i);
				if(i>pivot)          //remember do not put pivot itself to left or right again!!!!
					right.Add (i);
			}

			if (left.Count < k - 1)
				return QuickSelect (right, k - left.Count - 1); //O(n)
			else if (left.Count > k - 1)
				return QuickSelect (left, k); //O(n)
			else
				return pivot;

		}

		public static List<int> FindElements(List<int> Input, int k)
		{
			int kth = QuickSelect (Input, k);  //O(n)
			List<int> result = new List<int> ();
			foreach (int i in Input) {  //O(n)
				if (i <= kth)
					result.Add (i);
			}
				
			return result;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			List<int> test = new List<int>{ 9, 5, 1,8,2, 4, 13, 6,15,7,3 };
			List<int> result = Finder.FindElements (test, 9);
			foreach (int i in result) {
				Console.Write (i + " ");
			}
		}
	}
}
