//Check if an integer number is a palindrome


using System;

namespace PalindromeNumber
{
	public class Finder 
	{
		public bool FindPalindrome(int x)
		{
			if (x < 0)
				return false;
			if (x == 0)
				return true;

			int div = 1;
			while (x / div >= 10) {
				div *= 10;
			}

			while (x != 0) {
				int left = x / div;
				int right = x % 10;
				if (left != right)
					return false;
				//x = x - (div * left);
				//x = (x - right) / 10;
				x = (x % div) / 10; //update x to ger rid of the first and last number
				div = div / 100; //update div to match x
			}
			return true;
		}
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
			Finder finder = new Finder ();
			int x = 879545978;
			int y = 12233221;
			Console.WriteLine (finder.FindPalindrome (x));
			Console.WriteLine (finder.FindPalindrome (y));
		}
	}
}
