/**
 * Given an Integer array, find the number of Local Extrema in the array.
 * Local Extrema is Local Maxima or Local minima.
 * 
 * Local Minima: arr[p-1]>arr[p]=...=arr[q]<arr[q+1]
 * Local Maxima: arr[p-1]<arr[p]=...=arr[q]>arr[q+1]
 * 
 * Example: 
 * array: {1,1,2,6,5,4}
 * Local Minima; 1,1; 4;
 * Local Maxima: 6;
 * 
 * Note: 
 * 1，two concecutive 1 in the above array would be considered as one Local maxima
 * 2，For the edge elements(first one and last one), they only need to be compared
 * with one neighbor to decide if they are local maxima or minima.
 * 
 * Solution:
 * Since concecutive duplicate elements will be considered as one local extrema, we
 * can first remove all concecutive duplicate elements. Then the array would only contain
 * distinct elements. Then we can traverse the array and find all local maxima and minima.
 * Note the first and last elements of the array must be two local extrema. Do not forget
 * to add them.
 * 
 * Steps:
 * 1, convert the input array to a list
 * 2, traverse the list, remove all concecutive duplicate elements
 * 3, traverse the list, find and count local extrema
 * 4, add first and last element to the local extrema (add 2 to the number of local extrema)
 * 
 * */

using System;
using System.Collections.Generic;

namespace FindLocalExtrema
{
	class Finder{

		public static int FindLocalExtrema(int[] A){ //time: O(n) space: O(n)
			if (A.Length < 2) //Handle edge case
				return 0;

			List<int> list = new List<int> (); //convert A to list
			foreach (int i in A)
				list.Add (i);

			int prev = list [0];   //remove all concecutive duplicate elements in list
			for (int i = 1; i < list.Count; i++) {  //O(n)
				if (list [i] == prev) {
					list.RemoveAt (i);
					i--;
				} else {
					prev = list [i];
				}
			}

			int num = 0;
			for (int i = 1; i < list.Count-1; i++) { //now list contains only distinct elements
				if (list [i] < list [i - 1] && list [i] < list [i + 1]) //find Local Minima
					num++;
				if (list [i] > list [i - 1] && list [i] > list [i + 1]) //find Local Maxima
					num++;
			}
			num += 2; //add the first and last element as two local extrema

			return num;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (Finder.FindLocalExtrema(new int[]{1,1,2,6,5,4})); //3
			Console.WriteLine (Finder.FindLocalExtrema(new int[]{1})); //0
			Console.WriteLine (Finder.FindLocalExtrema(new int[]{})); //0
			Console.WriteLine (Finder.FindLocalExtrema(new int[]{1,5,3,4,3,4,1,2,3,4,6,2})); //9
			Console.WriteLine (Finder.FindLocalExtrema(new int[]{1,3,5,5,4,2,2,3,7,4,1})); //5
		}
	}
}
