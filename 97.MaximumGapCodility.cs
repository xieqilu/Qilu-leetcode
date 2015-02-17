/**
 * Given an array A, find max(min(abs(x-A[i]))) such that max(A[i])>=x<=min(A[i])
 * 
 * Given an array A, we can choose x in the range of max(A[i]) to min(A[i]),
 * for each x, there is a minimum value of abs(x-A[i]) we called xMin
 * Then we need to find and return the maximum value of xMin.
 * 
 * Example:
 * A:{1,2,4} output: 1
 * x is in the range of [1,4]. So x can be 1,2,3,4
 * x = 1 |1-1| = 0, |1-2| = 1, |1-4| = 3, min is 0
   x = 2 |2-1| = 1, |2-2| = 0, |2-4| = 2, min is 0
   x = 3 |3-1| = 2, |3-2| = 1, |3-4| = 1, min is 1
   x = 4 |4-1| = 3, |4-2| = 2, |4-4| = 0, min is 0
 *
 * So the maximum value is when x=3, min =1. Then we return 1;

 * These problem is very similiar to Maximum Gap on LeetCode. The only difference is that 
 * we need to return gap/2 instead of gap.
 * 
 * We can use the same approach (modified bucket sort).
 * 
 * Time complexity: O(n), Space complexity: O(n)

*/

using System;
using System.Collections.Generic;

namespace MaximumGap
{
	class Finder{
		public static int FindMaxGapCodility(int[] A){ //time: O(n)
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
			return gap / 2;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			//the java version of this code has passed all leetcode testcases!
			Console.WriteLine (Finder.FindMaxGapCodility (new int[]{ 4,3,2,5,1,10 })); //2
			Console.WriteLine (Finder.FindMaxGapCodility (new int[]{ 1,2,4 }));//1
			Console.WriteLine (Finder.FindMaxGapCodility (new int[]{ 100,10,9,13,2,1 }));//43
			Console.WriteLine (Finder.FindMaxGapCodility (new int[]{ 1 })); //0
			Console.WriteLine (Finder.FindMaxGapCodility (new int[]{ 1,7,9,41,15}));//13
		}
	}
}
