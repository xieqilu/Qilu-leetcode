/**
 * Given two sorted integer arrays A and B, merge B into A as one sorted array.

Note:
You may assume that A has enough space (size that is greater or equal to m + n) to hold additional elements from B. The number of elements initialized in A and B are m and n respectively.
*/

/**
 * Solution:
 * Note for this problem we need to merge B into A, not merge A and B to a new array.
 * So we cannot do the merge from the start. Instead, we must do the merge from the ends
 * of the two arrays (A and B). 
 * We can treate A like an empty array with length of m+n. Then use two pointers starting 
 * from the end of A and B, for each loop we compare current element of A and B, and put the
 * larger element to the current position of A (starting from the end (m+n-1)).
 * When one pointer reaches zero, either all elements of A or B are put into the correct 
 * position. If B still has elements that is not put yet, we put all left elements of B
 * to the correct position. If A still has elements that is not put yer, they are in the
 * correct position already, we do not need to do anything.
 * */


public class Solution {
    public void merge(int A[], int m, int B[], int n) {
        int pA = m-1;
        int pB = n-1;
        int p = m+n-1;
        while(pA>=0 && pB>=0){
            if(A[pA] > B[pB]){
                A[p]=A[pA];
                pA--;
            }
            else{
                A[p] = B[pB];
                pB--;
            }
            p--;
        }
        while(pB>=0){
            A[p] = B[pB];
            pB--;
            p--;
        }
    }
}
