//Letter combinations of a phone number
//Leetcode: https://oj.leetcode.com/problems/letter-combinations-of-a-phone-number/

using System;
using System.Collections.Generic;

namespace LetterCombinationPhone
{
	public class Finder
	{
		public static List<string> FindCombination(string digits) //Time: O(k^n), Space: O(k^n), n digit number, each digit represent k letter
		{
			List<string> letters = new List<string> (){ "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
			List<string> result = new List<string> ();
			result.Add ("");

			if (digits == null || digits.Length == 0)
				return result;

			for (int i = 0; i < digits.Length; i++) { //iterate digit of input number
				int currNumber = digits [i] - 48; //get int current number
				string currLetter = letters [currNumber]; //get related current letters
				List<string> tempRes = new List<string> ();

				foreach (string s in result){ //iterative current result

					for (int j = 0; j < currLetter.Length; j++) { //iterative current letters
						tempRes.Add (s + currLetter [j]);
					}
				}
				result = tempRes;
			}
			return result;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			string digits = "234";
			List<string> result = Finder.FindCombination (digits);
			foreach (string s in result)
				Console.Write (s + " ");
		}
	}
}
