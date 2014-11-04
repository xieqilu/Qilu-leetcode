//Find the minimum window in T that contains all elements in S
//Example:
//S: "ADOBECODEBANC"  T: "ABC"  
//output: "BANC"

//We need to clarify which characters the string can contain?
//In this solution we suppose the string contains ASCII characters.


using System;
using System.Collections.Generic;
using System.Collections;

namespace SmallestWindowInT
{
	public class Finder
	{
		public static string FindMinimumWindow(string strs, string strt)
		{
			int minBegin = 0;
			int minEnd = 0;
			if (CheckMinimumWindow (strs, strt, ref minBegin, ref minEnd)) {

				//string.Substring(startingIndex,LengthOfSubstr)
				string minWindow = strs.Substring (minBegin, minEnd -minBegin+1);
				return minWindow;
			}
			else return "Window not Found";

		}

		private static bool CheckMinimumWindow(string strs, string strt, ref int minBegin,ref int minEnd)
		{
			int[] hasFound = new int[256];
			int[] toBeFound = new int[256];
			int begin = 0;
			int minWindowLen = int.MaxValue;
			for (int i = 0; i < strt.Length; i++) { //initialize according to strt
				toBeFound [strt [i]]++;
			}
			int count = 0;

			for (int end = 0; end < strs.Length; end++) { //loop through strs
				if (toBeFound [strs [end]] != 0) { //if find a matching element
					hasFound [strs [end]]++;
					if (hasFound [strs [end]] <= toBeFound [strs [end]]) //update count only if the element is needed
						count++; 

					if (count == strt.Length) {
						//push the begin pointer forward as far as possible while maintaining the valid window
						while (toBeFound [strs [begin]] == 0 || hasFound [strs [begin]] > toBeFound [strs [begin]]) {
							if (hasFound [strs [begin]] > toBeFound [strs [begin]])
								hasFound [strs [begin]]--;
							begin++;
						}

						int windowLen = end - begin + 1; //update the minimum window if necessary
						if (windowLen < minWindowLen) {
							minBegin = begin;
							minEnd = end;
							minWindowLen = windowLen;
						}
					}
				}
			}

			return count == strt.Length ? true : false; //if no window found, return false
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			string source = "adfgtyacdew";
			string target = "gcd";
			Console.WriteLine (Finder.FindMinimumWindow (source, target));

		}
	}
}
