/**
Given a sorted array of integers, find the starting and ending position of a given target value.

Your algorithm's runtime complexity must be in the order of O(log n).

If the target is not found in the array, return [-1, -1].

For example,
Given [5, 7, 7, 8, 8, 10] and target value 8,
return [3, 4].


Idea: 
This is my very first coding problem since hunting for job.
Traversing the whole array would take O(n) which is not efficient enough.
We can use a modified binary search method to search for the first and last index of target.

Solution:
In the binary search method, use a bool input to indicate we are searching the first or last index.
Difference from normal binary search method:
1, if we are searching the first index:
if A[middle] ==target, let result=middle and continue searching in the left sub array(right=middle+1).

2, if we are searching the last index:
if A[middle] ==target, let result=middle and continue searching in the right sub array(left=middle-1).

In the main Method:
1, call binary search method to get first index of target.
2, if the first index is -1, directly to return [-1,-1]
3, if it's not -1, call binary search method to get last index of target
4, return result.

Note: this approach can also be used to find number of target in a sorted array. We just need to call
binary search method to find first and last index, then number = last-first+1. If first and last index
are both -1, then return 0.

Time complexity: O(logn)  Space complexity: O(1)
*/

public class Solution {
    public int[] SearchRange(int[] A, int target) {
        int[] res = new int[2];
        res[0] = BinarySearch(A,target,true); //O(logn)
        if(res[0]==-1){
            res[1]=-1;
            return res;
        }
        res[1] = BinarySearch(A,target,false); //O(logn)
        return res;
    }
    //Modified Binary Search to find first/last index of target in A
    private int BinarySearch(int [] A, int target, bool isFirst){ //O(logn)
        int left=0, right=A.Length-1, result=-1;
        while(left<=right){
            int middle = (left+right)/2;
            if(A[middle]==target){
                result=middle;
                if(isFirst)
                    right=middle-1;
                else
                    left = middle+1;
            }
            else if(A[middle]>target){
                right = middle-1;
            }
            else{
                left=middle+1;
            }
        }
        return result;
    }
}
