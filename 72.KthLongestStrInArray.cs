//find kth longest string in a string array
//assume that all strings in the input array have different length

//similiar to find kth smallest element in an array, use QuickSelect to solve it 
//in O(n) time

using System;
using System.Collections.Generic;
using System.Collections;

namespace KthLongestStrInArray
{
	public class Finder
	{
		public static string FindKthLongestStr(List<string> strs, int k) //O(n)
		{
			if (strs.Count < k)
				return null;

			List<string> left = new List<string> ();
			List<string> right = new List<string> ();

			int middle = strs.Count / 2;
			string pivot = strs [middle];

			foreach (string s in strs) {
				if (s.Length > pivot.Length)
					right.Add (s);
				else if (s.Length < pivot.Length)
					left.Add (s);
			}

			if (right.Count > k - 1)
				return FindKthLongestStr (right, k);
			else if (right.Count < k - 1)
				return FindKthLongestStr (left, k - right.Count - 1);
			else
				return pivot;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			List<string> strs = new List<string> (){ "a", "ab", "abc", "abcd", "abcdefg" };
			for (int i = 1; i < 6; i++) {
				Console.WriteLine (Finder.FindKthLongestStr (strs,i));
			}
		}
	}
}
