/**
 * Find the Minimum duplicate elements between two sorted array
 * Given two array A[N] and B[M], find the Minimum element
 * that exist in both A and B.
 * if no element found in both A and B, return -1;
 * Require time complexity less than O((N+M)log(N+M))
 * and space complexity less than O(N+M).
 * 
 * Example:
 * A:{1,2,2,3,5}  B:{2,5,5}
 * output: 2
 * 
 * Solution:
 * for each element in A, try to find the same element 
 * in B using binary search. If we find the same element
 * in B, return the element. It must be the min duplicate element.
 * If after the foreach loop, we never find a duplicate element,
 * return -1;
 * 
 * Time complexity: O(NlogM), N is the size of A, M is the size of B
 * Space complexity: O(1)
 * 
 * FOLLOW-UP: if the two array A and B are unsorted, how to solve this problem
 * within the same time and space complexity?
 * 
 * Solution:
 * First we sort array B using array.sort method. This method uses QuickSort so the 
 * time complexity is O(MlogM),  M is the size of B
 * Then use an int min to store result.
 * for each element in A, try to find it in B using binary search, 
 * if we find it, compare it with min and try to update min
 * After the for loop, if min doesn't change, return -1;
 * Otherwise, return min.
 * 
 * Time complexity: O(NLogM+MLogM) = O((N+M)LogM), 
 * Space complexity: O(1)
 * 
 * 
 * Futher thought:
 * if A and B are both sorted, we can use two pointers to traverse
 * A and B Cocurrently to find the minimum duplicate element in Linear Time
 * Time complexity would be O(N+M)
 * */



using System;
using System.Collections.Generic;

namespace MinDuplicateNumTwoArray
{
	class Finder{
		//binary search to check if k exist in arr, time:O(logn), n is the size of arr
		private static bool BinarySearch(int k, int[] arr){
			int left = 0;
			int right = arr.Length - 1;
			while (left <= right) {  //Note: condition must be left<=right!!!
				int middle = (left + right) / 2;
				if (arr [middle] == k)
					return true;
				else if (arr [middle] > k)
					right = middle - 1;
				else
					left = middle + 1;
			}
			return false;
		}

		//If A and B are both sorted
		public static int MinDuplicate(int[] A, int[] B){ //time: O(NLogM), space: O(1)
			foreach (int i in A) {
				if (BinarySearch (i, B)) { //O(logM)
					return i;
				}
			}
			return -1;
		}

		//If A and B are both unsorted
		public static int UnsortedMinDup(int[] A,int[] B){ //time: O((N+M)LogM), space:O(1)
			Array.Sort (B); //QuickSort, O(MLogM)
			int min = Int32.MaxValue;
			foreach (int i in A) {
				if (BinarySearch (i, B)) {
					if (i < min)
						min = i;
				}
			}
			if (min == Int32.MaxValue)
				min = -1;
			return min;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] A = new int[] { 1, 2, 2, 3, 5 };
			int[] B = new int[] { 2, 2, 5 };
			Console.WriteLine (Finder.MinDuplicate (A, B)); //2
			Console.WriteLine (Finder.MinDuplicate (new int[]{ 1, 7, 9 }, new int[]{ 1, 3, 5, 7, 8, 9 }));//1
			Console.WriteLine (Finder.MinDuplicate (new int[]{ 1, 7, 9 }, new int[]{ 3,4,5 })); //-1

			Console.WriteLine (Finder.UnsortedMinDup (new int[]{}, new int[]{})); //-1
			Console.WriteLine (Finder.UnsortedMinDup (new int[]{7,9,4,1}, new int[]{14,0,9,5,4,1})); //1
			Console.WriteLine (Finder.UnsortedMinDup (new int[]{10,12,1,5,8,5,3}, new int[]{2,4,11,6,7})); //-1
			Console.WriteLine (Finder.UnsortedMinDup (new int[]{}, new int[]{1,2,3})); //-1
			Console.WriteLine (Finder.UnsortedMinDup (new int[]{3,5,1,2}, new int[]{})); //-1
			Console.WriteLine (Finder.UnsortedMinDup (new int[]{7,9,4,1,2}, new int[]{14,0,9,5,4,2,13,24,2,31}));//2
		}
	}
}
