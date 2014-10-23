//Given a string, find the longest substring
//with no repeating character.


using System;
using System.Collections;
using System.Collections.Generic;

namespace LongestSubstrNoRepeat
{
	public class Finder
	{
		public int LenOfLongestSubstr(string s)
		{
			int n = s.Length;
			int i = 0;
			int j = 0;
			int maxLen = 0;
			bool[] existList = new bool[256];
			for (int a = 0; a < 256; a++) {
				existList [a] = false;
			}
				
			while (i < n) {
				if (existList [s[i]]) {
					maxLen = Math.Max (maxLen, i - j);
					while (s [j] != s [i]) {
						existList[s[j]] = false;
						j++;
					}
					j++;
					i++;
				} 
				else {
					existList [s[i]] = true;
					i++;
				}
			}
			maxLen = Math.Max (maxLen, n - j);
			return maxLen;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			string testString = "abcdeadafc";
			Finder finder = new Finder ();
			int result = finder.LenOfLongestSubstr (testString);
			Console.WriteLine ("The length of the longest substring is " + result);
		}
	}
}
