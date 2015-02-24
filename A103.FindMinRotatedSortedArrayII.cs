/**
 * Suppose a sorted array is rotated at some pivot unknown to you beforehand.

(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

Find the minimum element.

You may assume no duplicate exists in the array.

Solution: use a modified binary search
Each time compare the rightmost element with middle element
if num[right] < num[middle], then minmum must be at right sub
otherwise, minmum  must be at the left sub
*/

/**
Follow up for "Find Minimum in Rotated Sorted Array":
	What if duplicates are allowed?
	Would this affect the run-time complexity? How and why?

Solution:
For case where AL == AM == AR, the minimum could be on AM’s left or right side
(eg, [1, 1, 1, 0, 1] or [1, 0, 1, 1, 1]). 
In this case, we could not discard either subarrays
and therefore such worst case degenerates to the order of O(n).
*/




using System;

namespace FindMinRotatedSortedArrayII
{
	public class Solution{
		public static int FindMin(int[] num){
			if(num.Length == 0)
				return -1;
			int length = num.Length;
			int left =0;
			int right = length-1;
			while(left<right){
				int middle = (left+right)/2;
				//cannot compare num[left] with num[middle], if only two elements
				//middle will be equal to left, so must use right element to compare
				//with middle element
				if(num[right]<num[middle]) //minmum must be at the right sub
					left = middle+1;
				else         //minmum must be at the left sub
					right = middle;
			}
			return num[left];
		}

		public static int FindMinDuplicate(int[] A){
			if (A.Length == 0)
				return -1;
			int L = 0, R = A.Length - 1;
			while (L < R) {
				int M = (L + R) / 2;
				if (A[M] > A[R]) { //min must be at right sub
					L = M + 1;
				} else if (A[M] < A[L]) { //A[R]=A[M], min must be at left sub
					R = M;
				} else if (A[L] == A[M] && A[M] == A[R]) { //{3,3,4,6,9,3,3,3,3,3,3,3}, 
					L = L + 1;
				} else {
					// A[L] = A[M] < A[R] or
					// A[L] < A[M] = A[R] or
					// A[L] < A[M] < A[R]
					R = L;
				}
			}
			return A[L];
		}
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
			//This code has been tested by Leetcode test cases!
			Console.WriteLine ("Hello World!");
		}
	}
}
