/**
 * Find how many 1s in the product of a*b
 * Example:
 * a = 3, b=7, a*b=21=10101, return 3
 * a,b belongs to [1,100000000].
 * time complexity: O(log(a+b)), space comlextity: O(1)
 * 
 * solution:
 * use n&(n-1) to get rid of the rightmost 1 in n
 * 
 * no need to convert a and b to long, just use typecast
 * when get product a and b. long product = (long)a * (long)b
 * then get their product and do n&(n-1) until product=0
 * count how many times we can do n&(n-1)
 * */

using System;

namespace FindSetBitsInProduct
{
	class Finder{
		public static int FindSetBits(int a, int b){
			long product = (long)a * (long)b;
			int count = 0;
			while (product != 0) {
				product = product & (product - 1); //get rid of the rightmost 1
				count++;
			}
			return count;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (Finder.FindSetBits (4000,4000));
			Console.WriteLine (Finder.FindSetBits (100000000,100000000));
			Console.WriteLine (Finder.FindSetBits (3,7));
			Console.WriteLine (Finder.FindSetBits (2,4));
			Console.WriteLine (Finder.FindSetBits (800000,800000));
		}
	}
}
