//3 Find longest Palindrome in a given string
//
//Example: “abba” and “abbcbba” are both palindrome.
//We can solve this problem in O(n^2) time with O(1) space using the following steps:
//
//Step1: Notice a palindrome can be expanded from center to left and right in equal speed to find a longer palindrome. 
//So we need a method to expand an existed palindrome.
//
//Step2: In the Expand Method, the input are the original string, the leftmost index and rightmost index of the given palindrome. 
//Then we compare if the chars of leftmost index and rightmost index are equal, 
//it it is, then move leftmost one index left and rightmost one index right; 
//if it is not, we break the while loop. Also each time in the loop we need 
//to check if the leftmost and rightmost index are out of range.
//
//Step3: In the find method, we use Expand method to find the longest palindrome. 
//we set the longest palindrome as the first char of the original string.
//Then we start from the first char of the original string and iterate the whole string.
//Each time we use Expand method with (i,i) and (i, i+1), try to expand from the center and find palindrome. 
//The reason is a center can be a specific char or the space between two specific chars. 
//Everytime we use expand method, we compare the result with existing longest palindrome, 
//if result is longer, we set longest palindrome as result.
//
//Step4: After iterate the whole string, we return the longest palindrome.

using System;

namespace LongestPalindrom
{

	public class PalindromFinder
	{
		private string ExpandAroundCenter(string s, int left, int right) //helper method to expand a palindrom 
		{																//from its center (either a char or space between two chars)
			int n = s.Length;
			while (left >= 0 && right <= n - 1 && s[left] == s[right]) { //O(n)
				left--;
				right++;
			
			}
			return s.Substring (left + 1, right - left - 1); //(right -1) - (left+1)+1 = right-left-1
		}


		public string LongestPalindrom(string s)
		{
			int n = s.Length;
			if (n == 0)
				return "";
			string longest = s.Substring (0, 1);//a single char itself is a plaindrom
			for (int i = 0; i < n - 1; i++) { //O(n)
				string tmp1 = this.ExpandAroundCenter (s, i, i);
				if (tmp1.Length > longest.Length)
					longest = tmp1;
				string tmp2 = this.ExpandAroundCenter (s, i, i + 1);
				if (tmp2.Length > longest.Length)
					longest = tmp2;
			}
			return longest;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			string testString = "adedbaccabdfhy";
			var testFinder = new PalindromFinder ();
			string result = testFinder.LongestPalindrom (testString);
			Console.WriteLine (result);
		}
	}
}
