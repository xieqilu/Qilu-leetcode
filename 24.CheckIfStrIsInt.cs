//Check if a string is an int 
//input: "string"  output: false
//input: "123123"  output: true

using System;

namespace CheckIfStringIsInt
{

	public class Checker
	{
		public static bool CheckInt(string str)
		{
			if (str == "") //handle edge case
				return false;
			int length = str.Length;
			for (int i = 0; i < length; i++) {
				int diff = (int)str [i] - 48; //the ASCII of 0-9 is 48-57
				if (diff > 9 || diff < 0)
					return false;
			}
			return true;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			string test1 = "123131";
			string test2 = "asdasdas";
			string test3 = "";

			Console.WriteLine (Checker.CheckInt (test1));
			Console.WriteLine (Checker.CheckInt (test2));
			Console.WriteLine (Checker.CheckInt (test3)); 
		}
	}
}
