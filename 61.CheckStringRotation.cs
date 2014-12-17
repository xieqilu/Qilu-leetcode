//Determine if two strings are right rotation of each other
//OR determine if string1 is a right rotation of string2

//Note: if string1 is a right rotation of string2,
//then string2 must also be a right rotaion of string1

//firstly, if the length of two strings are different,
//Then theay cannot be right rotation of each other

//We can concatenate string1 (double string1) and then
//check if the new string1 contains string2.

using System;

namespace StringRotation
{
	public class Finder
	{
		public static bool CheckRotation(string str1, string str2)
		{
			if (str1.Length == str2.Length && str1.Length > 0) { //do not forget to check if two strings are both empty
				string newStr = string.Concat (str1, str1); //string.concat concatenate two strings
				return newStr.Contains (str2);
			} else
				return false;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			string str2 = "efgkbcd";
			string str3 = "gabcdef";
			Console.WriteLine (Finder.CheckRotation (str2,str3));
		}
	}
}
