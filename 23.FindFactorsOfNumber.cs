//Find all the possible factors of a given number
//Example: input: 24, output: 1 2 3 4 6 8 12 24

using System;
using System.Collections;
using System.Collections.Generic;

namespace FindFactorsOfNumber
{

	class Finder
	{
		public static IEnumerable<int> FindFactors(int x) //Time: O(n)
		{
			int max = x / 2;
			for (int i = 1; i <= max; i++) {
				if (x % i == 0)
					yield return i; //each time the method yield and return i to IEnumerable<int>
			}
			yield return x;
		}

		public static IEnumerable<int> FindFactorsFaster(int x) //Time: O(square(n))
		{
			int max = (int)Math.Sqrt (x); //time complexity is same of little slower than the division operation. 
			for (int i = 1; i <= max; i++) {
				if (x % i == 0) {
					yield return i;
					if (i != x / i)
						yield return x / i;
				}
			}
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			int test = 24;
			List<int> result = new List<int>(Finder.FindFactors (test)); //construct a new List using IEnumerable<int>

			//use IEnumerator to interate the results of Finder.FindFactors.
			IEnumerator iterator = Finder.FindFactorsFaster (test).GetEnumerator();
			while (iterator.MoveNext ()) {
				Console.WriteLine (iterator.Current.ToString ()+" ");
			}
			Console.WriteLine ("--------------------------");
			foreach (int i in result) {
				Console.WriteLine (i);
			}
		}
	}
}
