//find second longest string from a string array
//iterate the array twice, use first iterate to find the 
//longest string
//Then use second iterate to find the second longest string

//clarify question: will the strings in the array have same length?
//if there are two strings having the longest length, then which one
//is the second longest or there is no second longest string?


using System;
using System.Collections.Generic;
using System.Collections;

namespace SecondLongestStringInArray
{

	public class Finder
	{
		public static string FindSecondLongestStr(string[] strs)  //O(n)
		{
			if (strs.Length < 2)
				return null;

			string longestStr = string.Empty; //string.Empty equals to ""
			string SecLongestStr = string.Empty;

			foreach (string s in strs) {   //O(n)
				if (s.Length > longestStr.Length)
					longestStr = s;
			}

			foreach (string s in strs) {   //O(n)
				if (s.Length > SecLongestStr.Length && s.Length != longestStr.Length)
					SecLongestStr = s;
			}

			return SecLongestStr;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			string[] strs = new string[]{ "aa", "bbb", "ccc", "c", "asdasdas", "asdasw", "bdsd" };
			//string[] strs = new string[]{"asdas"};
			string result = Finder.FindSecondLongestStr (strs);
			if (result != null)
				Console.WriteLine (result);
			else
				Console.WriteLine ("input array is too short");
		}
	}
}
