//Given a string s and a dictionary of words dict, 
//determine if s can be segmented into a space-separated sequence of one or more dictionary words.

//For example, given
//s = "leetcode",
//dict = ["leet", "code"].

//Return true because "leetcode" can be segmented as "leet code".

//This file contains two solutions: Naive/Recursive Approach And DP Approach

using System;
using System.Collections.Generic;
using System.Collections;

namespace WordBreak
{
	class Finder
	{
		//Naive and Recursive Approach, Time: O(2^n), T(n) = m*T(n-a)
		//similar to T(n) = T(n-1)+T(n-2), totally n levels of the recursive tree. so O(2^n)
		public static bool RecursiveWordBreak(string str, HashSet<string> dict)
		{
			return RecursiveHelper (str, dict, 0);
		}

		private static bool RecursiveHelper(string str, HashSet<string> dict, int start)
		{
			if (start == str.Length) //Base Case, when reaching the end of str, return true
				return true;

			foreach (string s in dict) {
				int len = s.Length;
				int end = start + len;

				if (end <= str.Length) {
					if (str.Substring (start, len).Equals (s) && RecursiveHelper (str, dict, end))
						return true;					
				}
			}
			return false;
		}


		//Dynamic Programming Approach, much better than recursive one. Time: O(n*m)
		//n is the length of str, m is the length of dict
		public static bool WordBreakDP(string str, HashSet<string> dict)
		{
			bool[] temp = new bool[str.Length+1];
			temp [0] = true;   //set initial state

			for (int i = 0; i < str.Length; i++) {
				if (temp [i]) {
					foreach (string s in dict) {
						int len = s.Length;
						int end = i + len;
						if (end <= str.Length && !temp [end]) {
							if (str.Substring (i, len).Equals (s)) {
								temp [end] = true;
								if (end == str.Length)
									break;
								}
							}
					}
					if (temp [str.Length] == true)
						break;
				}
			}
			return temp [str.Length]; //last element of temp indicate if the whole str can be matched
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			HashSet<string> dict = new HashSet<string> (){ "ab", "le", "etcode", "ghj", "leet","code", "cod" };
			string str = "leetcode";
			Console.WriteLine (Finder.RecursiveWordBreak (str, dict));
			Console.WriteLine (Finder.WordBreakDP (str, dict));
		}
	}
}
