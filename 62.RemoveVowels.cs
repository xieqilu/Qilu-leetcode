//Remove all vowels from a given string
//Example: Given "abcdefg"  Result: "bcdfg";

//Note: In Java, get a char from a string using its position is str.CharAt(position)
//but in C#, we can directly use str[position] to get the char

//str.IndexOf(char), return the index of first occurennce of input char in the str
//if input char does not exist in the str, return -1


//So we can create a string including all vowels like "aeiou", then check if a specific
//char of the given string exists in the vowel string, if it exist, remove it, otherwise, 
//keep it


using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RemoveVowels
{
	public class Finder
	{
		public static string RemoveVowels(string str)
		{
			string v = "aeiou";
			string str1 = str.ToLower ();
			StringBuilder sb = new StringBuilder ();
			for (int i = 0; i < str1.Length; i++) {
				if (v.IndexOf (str1 [i]) == -1)
					sb.Append (str1 [i]);
			}
			return sb.ToString ();
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			string test = "abcdefgicdkoub";
			Console.WriteLine (Finder.RemoveVowels (test));
		}
	}
}
