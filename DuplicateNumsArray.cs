//Find duplicate elements in an array
//value of elements is positive and between 0 to n-1, n is the size of array
//all duplicate elements cannot occur more than twice in the array
//O(n) time and O(1) space

using System;
using System.Collections.Generic;
using System.Collections;

namespace FindDuplicateInArray
{
	class Finder
	{
		public static void FindDuplicate(int[] arr) //O(n) time, O(1) space
		{                   						//elements value cannot be 0
													// duplicate elements cannot occur more than twice
			int n = arr.Length;
			foreach (int i in arr) {
				if (arr [Math.Abs (i)] > 0)
					arr [Math.Abs (i)] = -arr [Math.Abs (i)];
				else if (arr [Math.Abs (i)] < 0)
					Console.Write (Math.Abs(i) + " ");
			}
		}

		public static void FindTest(int[] arr) // O(n) time, O(n) space
		{									   // arr can have elements value equals to 0
											   // duplicate elements can occur more than twice
			int n = arr.Length;
			List<int> temp = new List<int> ();
			for (int i = 0; i < n; i++)
				temp.Add (0);
			foreach (int i in arr) {
				if (temp [i] == 0)
					temp [i]++;
				else if (temp [i] == 1) {
					Console.Write (i + " ");
					temp [i]++;
				}
			}
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] test = new int[7] {1, 1, 1, 6, 6, 4, 6};
			Finder.FindTest (test);
			Console.WriteLine (" ");
			Finder.FindDuplicate (test);
		}
	}
}
