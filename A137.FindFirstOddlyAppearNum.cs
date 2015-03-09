/**
 * Given an array of integer, find the first element in it such the number of appearence
 * of this element is Odd.
 * 
 * Example: 
 * Array: {5,3,3,3,4,2,5,7,5,1,4,5,6,2}
 * Output: 3
 * Because 3 appreas 3 times in this array and it's the first element that appears for odd times
 * 
 * 
 * Solution:
 * We can use a Dictionary to store the number of appearence of each element in the array. Then loop
 * through the array again and check if each element appears for odd times, once we find the first element
 * that appears for odd times, we break the loop and return it.
 * 
 * To reduce the memory space of the Dictionary, we can set the value as bool type. Then use false to
 * represent the key appears for even times and true to represent the key appears for odd times. If we
 * got a new element that doesn't exist in the Dicitionary, put (element, true) into it. Thus we significantly
 * reduce the memory cost of the Dictionary.
 * 
 * Special Note: After constructing the Dictionary, we cannot iterate through the Dictionary to find the first 
 * element that appears for odd times. Because a Dictionary doesn't persve insertion order, actually a Dicitonary
 * sacrifice insertion order to get fast random access. So we need to loop through the array again and find the 
 * first element in array that appears for odd times.
 * 
 * Time: O(n)
 * */


using System;
using System.Collections.Generic;

namespace FindFirstOddlyAppearedNum
{
	class Solution{
		public static int FindFirstOdd(int[] arr){
			Dictionary<int,bool> dict = new Dictionary<int, bool> (); //use bool to reduce memory cost
			foreach (int i in arr) {
				if (dict.ContainsKey (i))
					dict [i] = !dict [i];
				else
					dict.Add (i, true);
			}

			foreach (int i in arr) {
				if (dict [i] == true)
					return i;
			}
			return -1; //edge case: all elements in arr appears for even times, can throw exceptions
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (Solution.FindFirstOdd (new int[]{ 5, 3, 3, 3, 4, 2, 5, 7, 5, 1, 4, 5, 6, 2 })); //3
			Console.WriteLine (Solution.FindFirstOdd (new int[]{ 5, 3, 3, 3, 4, 2, 5, 7, 5, 1, 4, 5, 6, 5 })); //5
			Console.WriteLine (Solution.FindFirstOdd (new int[]{ 5, 3, 3, 3, 4, 3, 5, 7, 5, 7, 4, 5, 6, 2 })); //6
		}
	}
}
