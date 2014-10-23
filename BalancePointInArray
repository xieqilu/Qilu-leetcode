//Find the balance point in an array
//Example: [2,3,-4,7,0,1] the balance point is index 3
//because sum[left] = sum[right] = 1

using System;
using System.Collections.Generic;

namespace BalancePointInArray
{
	public class Finder
	{
		//native solution: for each element, compute left sum and right sum, then compare. Time: O(n^2)

		public int FindBalancePoint(int[] A) //Time: O(n), Space: O(n)
		{
			int length = A.Length;
			int[] left = new int[length];
			int[] right = new int[length];

			left [0] = A [0];
			for (int i = 1; i < length; i++) { //O(n)
				left [i] = left [i - 1] + A [i];
			}

			right [length - 1] = A [length - 1];
			for (int i = length - 2; i >= 0; i--) { //O(n)
				right [i] = right [i + 1] + A [i];
			}

			for (int i = 0; i < length; i++) {
				if (left [i] == right [i])
					return i; //return index
			}

			return -1; //no balance point
		}
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] test = new int[5]{ 3,99,2, 2, -1 };
			Finder finder = new Finder ();
			Console.WriteLine ("The balance point is Index " + finder.FindBalancePoint (test));

		}
	}
}
