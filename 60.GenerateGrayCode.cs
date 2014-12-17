//Given an int n, generate n-bit Gray Code
//Example: n=2. result = {0,1,3,2}  (00,01,11,10)
//n=3, result = {0,1,3,2,6,7,5,4} (000,001,011,010,110,111,101,100)


//Note: We can find a very useful pattern for this problem:
//To generate result for n, we first have the result for n-1
//Then use the reverse sequence of the list of result for n-1
//For each element, add 1<<n-1 to it, then we got 4 new elements
//combine the result of n-1 and the 4 new elements, then we got result of n

using System;
using System.Collections.Generic;

namespace GenerateGrayCode
{
	public class Finder
	{
		public static List<int> GenerateGray(int n)  //Time: O(n^2)
		{
			List<int> result = new List<int> ();
			result.Add (0); //add the base result for n=0 to list
			for (int i = 0; i < n; i++) {  //iterate from 0 to n-1
				int highestBit = 1 << i;  //In each level, highestBit is i << (current n -1)
				int length = result.Count;

				for (int j = length - 1; j >= 0; j--) { // iterate the list reversely
					result.Add (result [j] + highestBit); 
				}
			}
			return result;
		}

		public static List<int> GenerateGrayMath(int n) //Time: O(n), clearly the math solution is way faster
		{
			List<int> result = new List<int> ();
			int size = 1 << n;  //size is the number of elements for the specific n
			for (int i = 0; i < size; i++) {
				result.Add ((i >> 1) ^ i);
			}
			return result;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			List<int> result1 = Finder.GenerateGray (3);
			List<int> result2 = Finder.GenerateGrayMath (3);
			foreach (int i in result1)
				Console.WriteLine (i);
			Console.WriteLine (" ");
			foreach (int i in result2)
				Console.WriteLine (i);
		}
	}
}
