/**
 * Given two int numbers A and B , print the zip of them.
 * Suppose A and B both have size of n, (number of digits of A and B are both n)
 * then output should be a number as follows:
 * A[1]B[1]A[2]B[2].....A[n]B[n]
 * A[n] means the nth digit of number A
 * 
 * A and B belongs to [1,100000000]
 * 
 * For example:
 * A = 245, B=890, output: 284950
 * A = 1234, B=5678, output: 15263748
 * 
 * Solution:
 * no need to convert A and B to long, but must use a long variable
 * to store the final result.
 * Use a loop, each time we get the last digit
 * of B and A, then build them to int result.(must convert to long at this step)
 * Then update A and B to get rid of the original last digit
 * Until A and B is equal to zero.
 * Then return result
 * 
 * */


using System;

namespace TwoNumberZip
{
	class Finder{

		public static long ZipTwoNumber(int A, int B){ //time: O(N), N is the number of digits in A and B
			long result = 0;
			int power = 0;
			while (A!= 0 && B!= 0) {
				int currDigitB = B % 10;
				int currDigitA = A % 10;
				result += (long)currDigitB * (long)Math.Pow (10, power); //convert to long
				result += (long)currDigitA * (long)Math.Pow (10, power + 1);
				B = B / 10;
				A = A / 10;
				power += 2;
			}
			return result;
		}
	}


	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (Finder.ZipTwoNumber(245,890));
			Console.WriteLine (Finder.ZipTwoNumber(1234,5678));
			Console.WriteLine (Finder.ZipTwoNumber(123456789,987654321));
			Console.WriteLine (Finder.ZipTwoNumber(100000000,100000000));
		}
	}
}
