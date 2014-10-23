//Find the kth smallest element in two
//sorted array


using System;
using System.Collections;
using System.Collections.Generic;

namespace smallestInTwoSortedArray
{

	public class Finder
	{
		public int FindSmallestElement(List<int> listA, List<int> listB, int k)
		{
			int A_offset = 0;
			int B_offset = 0;
			if (listA.Count + listB.Count < k)
				return -1;
				while (true) {
					if (A_offset < listA.Count) { 
					while (B_offset == listB.Count|| listA [A_offset] <= listB [B_offset]) {
						//first check if B pointer equals to the length of listB, otherwise, will be out of range exception
							A_offset++;
							if (A_offset + B_offset == k)
								return listA [A_offset-1]; //DO NOT return listA[A_offset],it's wrong
						if (A_offset == listA.Count) 
							break;     //must break, otherwise listA[A_offset] will be out of range
						}
					}
					if (B_offset < listB.Count) {
					while (A_offset == listA.Count|| listB [B_offset] <= listA [A_offset]) {
						//first check if A pointer equals to the length of listA, otherwise, will be out of range exception
							B_offset++;
						if (A_offset + B_offset == k)
							return listB [B_offset-1]; 
						if (B_offset == listB.Count)
							break;
						}
					}
				}
		}

	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			List<int> listA = new List<int> (new int[]{ 1, 99});
			List<int> listB = new List<int> (new int[]{ 2,4,9,11,14,15});
			int k = 5;
			Finder finder = new Finder ();
			int result = finder.FindSmallestElement (listA, listB, k);
			Console.WriteLine (result);
		}
	}
}
