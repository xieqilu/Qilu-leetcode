/**
 * Given an array of integers, find two numbers such that they add up to a specific target number.

The function twoSum should return indices of the two numbers such that they add up to the target, 
where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.

You may assume that each input would have exactly one solution.

Input: numbers={2, 7, 11, 15}, target=9
Output: index1=1, index2=2
*/

/**
 * Solution:
 * use a hashMap<element, index> to store elements in the given arrays
 * for each int i in the given array,
 * first check if hashmap contains (target-i)
 * if it does, then return the index of i and (target - i)
 * it it doesn't, add <index, i> to the hashMap
 * 
 * Time:O(n), Space:O(n)
 * 
 * Note we must use element as key and index as value, because
 * we need to find if hashMap contains key fast.
 * */

using System;
using System.Collections.Generic;

namespace TwoSum
{
	class Finder{
		public static int[] TwoSum(int[] numbers, int target){
			Dictionary<int,int> dic = new Dictionary<int, int> ();
			int[] result = new int[2];
			for (int i = 0; i < numbers.Length; i++) {
				if (dic.ContainsKey (target - numbers [i])) {
					result [0] = dic [target - numbers [i]] + 1;
					result [1] = i + 1;
					break;
				} else
					dic.Add (numbers [i], i);
			}
			return result;
		}
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] temp = Finder.TwoSum (new int[]{ 2, 7, 11, 5 }, 9);
			foreach(int i in temp)
				Console.WriteLine (i);
			
		}
	}
}
