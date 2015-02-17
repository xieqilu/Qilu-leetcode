/**
 * Given an unsorted array, find the maximum difference between the successive elements in its sorted form.

Try to solve it in linear time/space.

Return 0 if the array contains less than 2 elements.

You may assume all elements in the array are non-negative integers and fit in the 32-bit signed integer range.

Example:
Array: {1,2,4} output: 4-2=2;
Array: {9,5,0,3,1} output: 9-5=4;

Solution:
If we use QuickSort to sort the given array and then find max gap between any two concecutive element,
the time complexity would be O(nlogn), n is the size of array. It's not a linear time solution.

Linear time solution:
Use modified bucket sort as follows:

Suppose there are N elements and they range from A to B.
Then the maximum gap will be no smaller than ceiling[(B - A) / (N - 1)]
Let the length of a bucket to be len = ceiling[(B - A) / (N - 1)], 
then we will have at most num = (B - A) / len + 1 of bucket

for any number K in the array, we can easily find out which bucket it belongs by calculating loc = (K - A) / len 
and therefore maintain the maximum and minimum elements in each bucket.

Since the maximum difference between elements in the same buckets will be at most len - 1, 
so the final answer will not be taken from two elements in the same buckets.

For each non-empty buckets p, find the next non-empty buckets q, 
then q.min - p.max could be the potential answer to the question. 
Return the maximum of all those values.

Time: O(n) space: O(n)

*/

using System;
using System.Collections.Generic;

namespace MaximumGap
{
	class Finder{
		public static int FindMaxGap(int[] A){
			if (A.Length < 2) //handle edge case
				return 0;

			int min = A[0]; //traverse array to find min and max
			int max = A[0];
			foreach (int i in A) {
				if (i > max)
					max = i;
				if (i < min)
					min = i;
			}

			int bucketLen = (int)Math.Ceiling ((double)(max - min) /(double)(A.Length - 1)); //get bucket length
			int bucketNum = (max - min) / bucketLen + 1; //get the number of buckets

			List<int[]> buckets = new List<int[]> (bucketNum); //create list of buckets
			for (int i = 0; i < bucketNum; i++) {
				buckets.Add (new int[2]{-1,-1}); //each bucket only needs two space, to store local max and min
			}

			foreach (int k in A) {  //traverse the array and fill all the buckets
				int i = (k - min) / bucketLen;
				if (buckets [i] [0] == -1 && buckets [i] [1] == -1) { //if current bucket is empty
					buckets [i] [0] = k; //set min to k
					buckets [i] [1] = k; //set max to k
				} else {
					if (k < buckets [i] [0])
						buckets [i] [0] = k;
					if (k > buckets [i] [1])
						buckets [i] [1] = k;
				}

			}

			int gap = 0;
			int prev = 0;  //the first bucket cannot be empty
			for (int i = 1; i < bucketNum; i++) { //traverse list of buckets and update gap
				if (buckets [i] [0] != -1) {
					int currGap = buckets[i][0] - buckets[prev][1];
					if (currGap > gap)
						gap = currGap;
					prev = i;
				}
			}
			return gap;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			//the java version of this code has passed all leetcode testcases!
			Console.WriteLine (Finder.FindMaxGap (new int[]{ 4,3,2,5,1,10 }));
		}
	}
}
