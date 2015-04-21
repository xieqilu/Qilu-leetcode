/**
Find the kth smallest element in two sorted array

Solution1 Explanation:
Assume that the number of elements in A and B are both larger than k/2, and if we compare the k/2-th smallest element in A(i.e. A[k/2-1]) and the k-th smallest element in B(i.e. B[k/2 - 1]), there are three results:
(Becasue k can be odd or even number, so we assume k is even number here for simplicy. The following is also true when k is an odd number.)
A[k/2-1] = B[k/2-1]
A[k/2-1] > B[k/2-1]
A[k/2-1] < B[k/2-1]
if A[k/2-1] < B[k/2-1], that means all the elements from A[0] to A[k/2-1](i.e. the k/2 smallest elements in A) are in the range of k smallest elements in the union of A and B. Or, in the other word, A[k/2 - 1] can never be larger than the k-th smalleset element in the union of A and B.

Why?
We can use a proof by contradiction. Since A[k/2 - 1] is larger than the k-th smallest element in the union of A and B, then we assume it is the (k+1)-th smallest one. Since it is smaller than B[k/2 - 1], then B[k/2 - 1] should be at least the (k+2)-th smallest one. So there are at most (k/2-1) elements smaller than A[k/2-1] in A, and at most (k/2 - 1) elements smaller than A[k/2-1] in B.So the total number is k/2+k/2-2, which, no matter when k is odd or even, is surly smaller than k(since A[k/2-1] is the (k+1)-th smallest element). So A[k/2-1] can never larger than the k-th smallest element in the union of A and B if A[k/2-1]<B[k/2-1];
Since there is such an important conclusion, we can safely drop the first k/2 element in A, which are definitaly smaller than k-th element in the union of A and B. This is also true for the A[k/2-1] > B[k/2-1] condition, which we should drop the elements in B.
When A[k/2-1] = B[k/2-1], then we have found the k-th smallest element, that is the equal element, we can call it m. There are each (k/2-1) numbers smaller than m in A and B, so m must be the k-th smallest number. So we can call a function recursively, when A[k/2-1] < B[k/2-1], we drop the elements in A, else we drop the elements in B.


We should also consider the edge case, that is, when should we stop?
1. When A or B is empty, we return B[k-1]( or A[k-1]), respectively;
2. When k is 1(when A and B are both not empty), we return the smaller one of A[0] and B[0]
3. When A[k/2-1] = B[k/2-1], we should return one of them

In the code, we check if m is larger than n to garentee that the we always know the smaller array, for coding simplicy.
*/

//Solution1: Modified Binary Search   Time: O(log(m+n)) m and n is the length of two arraies
public class Solution { 
    //Method to find the kth smallest element in two sorted array A and B   Time: O(logk)
    //Idealy reduce the size of K by half in each pass
    private double FindKthSmallest(int[] A, int AStart, int[] B, int BStart, int k){
        int ALen = A.Length-AStart;
        int BLen = B.Length-BStart;
        //always assume ALen<BLen to make code simpler
        if(ALen > BLen)
            return FindKthSmallest(B, BStart, A, AStart, k);
        //Edge Case
        if(ALen==0)
            return B[BStart+k-1];
        if(k==1)
            return Math.Min(A[AStart], B[BStart]);
        
        //Divide k into two parts, pa cannot be larger than ALen to avoid index out of range
        //use pa to get pb to make sure pa+pb = k.
        int pa = Math.Min(k/2, ALen), pb = k-pa;
        if(A[AStart+pa-1]<B[BStart+pb-1])
            return FindKthSmallest(A, AStart+pa, B, BStart, k-pa);
        else if(A[AStart+pa-1]>B[BStart+pb-1])
            return FindKthSmallest(A, AStart, B, BStart+pb, k-pb);
        else
            return A[AStart+pa-1];
    }
    
    public int FindKthTwoSortedArrays(int[] A, int[] B, int k) {
    	if(k>A.Length+B.Length)
    		throw new ArgumentException("invalid argument", "k"); 
        return FindKthSmallest(A, 0, B, 0, K);
    }
}


//Solution2: Two Pointers  Time: O(k)
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
