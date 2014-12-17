//Determine if two bytes are gray code to each other
//if they are, return 1. If they aren't, return 0

//Gray code: two bytes that only differ in one bit.
//Example: 1101 and 1100 are gray code


using System;

namespace JudgeGrayCode
{
	public class Finder
	{
		public static int IsGrayCode(byte b1, byte b2) // range of byte" {0,255}
		{
			if (b1 == b2)
				return 0;

			int x = (b1 ^ b2) & 0xff; // ^ is the XOR operator for byte, XOR: two bits differ = 1, two bits same = 0
									  // so after XOR, if b1 and b2 are gray code, x would be one 1 with some 0. ()
			if ((x & (x - 1)) == 0)   // & is the logic AND, x & (x-1) get rid of the last 1 existing in x
									  // so if x only have one 1, then x & (x-1) would be 0
				return 1;
			else
				return 0;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			byte b1 = 13;
			byte b2 = 5;
			Console.WriteLine (Finder.IsGrayCode (b1, b2));
		}
	}
}
