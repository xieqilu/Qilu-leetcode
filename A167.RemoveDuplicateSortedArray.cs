/**
Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.

Do not allocate extra space for another array, you must do this in place with constant memory.

For example,
Given input array A = [1,1,2],

Your function should return length = 2, and A is now [1,2].


Idea:
The description of this problem is a littel confusing. In C# and Java, if the input is an array,
we cannot change the length of the original array. So what this problem means is given an array A,
change the postion of elements in A and return a new length L such that the subarray from 0 to L-1
of A has only unique elements. In other words, if A has n unique elements, we need to return n as 
the new length and the first n elements of A are all unique elements. All duplicate elements should
be pushed to the end of A.

In C++, the array is defined using a length. So by returning a new length, we actually return a new 
array that has the new length.


Solution:
This is a typical two pointers problem. Since A is already sorted, duplicate elements stay together. 
So we can use a prev pointer starting from 0 and iterate the whole array. In the iteratin, if 
A[i] == A[prev], ignore A[i] and continue. If A[i]!=A[prev], then we need to move A[i] to the next 
position of A[prev]. So increment prev and let A[prev]==A[i].
After the iteration, return prev+1 as the new length. At this time, the first prev+1 elements of A
are all unique elements.

Time: O(n)   Space: O(1)
*/

public class Solution {
    public int RemoveDuplicates(int[] A) {
        if(A.Length==0) return 0;
        int prev=0;
        for(int i=0;i<A.Length;i++){
            if(A[prev]!=A[i]){
                prev++;
                A[prev]=A[i];
            }
        }
        return prev+1;
    }
}
