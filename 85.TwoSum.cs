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
 *
 * Special Note: 
 * In the loop, first check if numbers[i] already exists in dict, if not, add numbers[i] to dict. 
 * Otherwise, would cause an error.
 * If there are multiple element A in array, and A is a part of two results. 
 * We need to know which index of A to consider as result. If it's the last A, then 
 * we need to update dict[A] if A already exists in array. If it's the first A, don't update.
 * */

using System;
using System.Collections.Generic;

namespace TwoSum
{
	class Finder{
		public static int[] TwoSum(int[] numbers, int target){
			Dictionary<int,int> dict = new Dictionary<int, int> ();
			int[] result = new int[2];
			for (int i = 0; i < numbers.Length; i++) {
				if (dict.ContainsKey (target - numbers [i])) {
					result [0] = dic [target - numbers [i]] + 1;
					result [1] = i + 1;
					break;
				} 
				//if numbers[i] appears before, don't add to dict, will cause an error
            			else if(!dict.ContainsKey(numbers[i])) 
                			dict.Add(numbers[i],i);
                		//if there are multiple a in array, and we need to return the index of last a,use below code
                		//if we need to return the index of first a, don't use below code
                		//else
                		//	dict[numbers[i]]=i;
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
