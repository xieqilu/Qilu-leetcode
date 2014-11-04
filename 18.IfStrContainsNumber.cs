//check if a string contains a number
//input: "asdasda"  output: false
//input: "sasd3sad4"  output: true

using System;

namespace CheckStrContainsNumber
{
	class MainClass
	{
		public class Checker
		{
			public static bool Check(string str)
			{
				for (int i = 0; i < str.Length; i++) {
					int diff = (int)str [i] - 48; //in ASCII, 0 locates at 48, 9 locates at 48+9=57.
					if (diff >= 0 && diff < 10)
						return true;
				}
				return false;
			}

			public static bool NewCheck(string str)
			{
				char[] charlist = str.ToCharArray ();
				foreach (char c in charlist)
				{
					if(char.IsDigit(c)) return true; //char.isdigit() to check wether the char is a number
				}
				return false;
			}
		}
		public static void Main (string[] args)
		{
			string teststr1 = "asdasdagdsfa";
			string teststr2 = "asdasd123asdas2";
			bool result1 = Checker.NewCheck (teststr1);
			bool result2 = Checker.NewCheck (teststr2);
			Console.WriteLine (result1);
			Console.WriteLine (result2);
		}
	}
}
