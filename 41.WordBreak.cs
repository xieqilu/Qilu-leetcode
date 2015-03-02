/**
 * Given a string s and a dictionary of words dict, 
 * determine if s can be segmented into a space-separated sequence of one or more dictionary words.

For example, given
s = "leetcode",
dict = ["leet", "code"].

Return true because "leetcode" can be segmented as "leet code".
*/

/**
 * Solution:
 * Do not use Recursive solution to solve the problem, it's very inefficient.
 * Use Iterative Dynamic Programming approach as follows:
 * 
 * Use a bool array dp to keep track of which part of the input string is already matched.
 * The size of bool array is the size of Set+1. And dp[i] is true means all the chars of 
 * s (input string) before s[i] is already matched. So initiliaze dp[0] as true, then we
 * can start matching from s[0].
 * 
 * Then iterate through each char of s, for each char s[i], check if dp[i] is true. If dp[i]
 * is false, no need to do match from current position. If dp[i] is true, which means all the
 * chars before s[i] are already matched. So we try to match chars from s[i].
 * 
 * To match chars from s[i], we iterate through dict. For each string str, try to match
 * s.substring(i,i+str.length()) with str. If matched, set dp[i+str.length()] to true and 
 * check if i+str.length() is equal to s.length(), if it is, then all chars of s are matched,
 * we break the loop. If not matched, continue.
 * 
 * After the above nested loop, return dp[s.length()], which indicates if all chars of s are matched
 * or not.
 * 
 * 
 * Time Complexity: O(n*m), n is the size of input string, m is the size of input dict
 * Space Complexity: O(n), n is the size of input string.
 * 
 * */


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
									return true;
								}
							}
					}
				}
			}
			return false; //last element of temp indicate if the whole str can be matched
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
