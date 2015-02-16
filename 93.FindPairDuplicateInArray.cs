/**
 * Find pair of duplicate elements in an array, 
 * the two duplicate elements in each pair must have different index.
 * 
 * Example:
 * array: {1,1,1,2,3,3}
 * number of pairs: 4
 * 
 * There are totally three 1s in the arrary, which can build 3 pairs,
 * and there are two 3s in the array, which can build 1 pair.
 * So totally there are 4 pairs.
 * 
 * Solution:
 * use a hashMap to store number of appearance for each distinct element.
 * Then iterate the hashMap, if number of appearance is greater than 1,
 * we caculate the pairs and add it to final result.
 * 
 * Method to caculate pairs:
 * Suppose a number appear for n times in the array, then number of pairs
 * for this number is (n-1)+(n-2)+....+1.
 * 
 * time: O(n)  space: O(n)
 * */


using System;
using System.Collections.Generic;

namespace FindPairDuplicateInArray
{
	class Finder{

		private static int CaculatePairs(int a){
			int result = 0;
			a--;
			while (a != 0) {
				result += a;
				a--;
			}
			return result;
		}

		public static int FindPairs(int[] arr){ 
			if (arr.Length == 0)
				return 0;
			Dictionary<int,int> dic = new Dictionary<int,int> ();
			int numOfPair = 0;
			foreach (int i in arr) {
				if (dic.ContainsKey (i))
					dic [i]++;
				else
					dic.Add (i, 1);
			}

			foreach (KeyValuePair<int,int> kp in dic) {
				if (kp.Value > 1)
					numOfPair += CaculatePairs (kp.Value);
			}
			return numOfPair;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (Finder.FindPairs(new int[]{1,1,1,2,3,3}));
			Console.WriteLine (Finder.FindPairs(new int[]{5,4,3,2,5,6,5,2,1,6,8,9}));
			Console.WriteLine (Finder.FindPairs(new int[]{}));
			Console.WriteLine (Finder.FindPairs(new int[]{1,2,3,4,5}));
			Console.WriteLine (Finder.FindPairs(new int[]{1}));
		}
	}
}
