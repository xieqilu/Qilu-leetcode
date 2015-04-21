/**
There are two sorted arrays nums1 and nums2 of size m and n respectively. 
Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).

Idea:
This problem is equal to find kth smallest element in two sorted array/lists, where kth smallest element is
replaced by median element. The normal idea is to use two pointers to alternatively traverse the two sorted array 
and merge them into one sorted array. Then find the median easily. But this method runs in O(m+n) time. 

Another idea is to use modified binary search, which runs in O(log(m+n)) time and much more complex than the first one.


Solution1: Merge A and B int one array
Use two pointers to traverse A and B in the same time. In each pass put the smaller element into C array.
Note if the pointer for A or B is out of range we can use max Integer to mark current element of A and B, this
won't change the result of C but will significantly reduce our coding work, very elegant and efficient.

After the merge, if m+n is odd, return middle element in C.
If m+n is even, return the average of the TWO middle elements in C. Note divide the sum by 2.0 since we need to
return double.

Time complexity: O(m+n)


Solution2: Modified Binary Search
This is a brillant magic method, I must remeber this!!!

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

//Solution1: Merge A and B into one array,  Time: O(m+n)
public class Solution { 
    public double FindMedianSortedArrays(int[] A, int[] B) {
        int m=A.Length;
        int n=B.Length;
        //Merge A and B into C, time: O(m+n)
        int[] C = new int[m+n];
        int i=0,j=0,k=0;
        while(i<m || j<n){
            int a = i < m ? A[i]:Int32.MaxValue; //if i or j is out of range, use maxi integer to mark a or b.
            int b = j < n ? B[j]:Int32.MaxValue;
            if(a<b){
                C[k]=a;
                i++;
            }
            else{
                C[k]=b;
                j++;
            }
            k++;
        }
        if((m+n)%2==1) //m+n is odd number, return middle element
            return (double)C[(m+n)/2];
        return (C[(m+n)/2-1]+C[(m+n)/2])/2.0; //m+n is even number, return average of two middle elements
    }
}



//Solution2: Modified Binary Search   Time: O(log(m+n))
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
    
    public double FindMedianSortedArrays(int[] A, int[] B) {
        int m = A.Length;
        int n = B.Length;
        if((m+n)%2==1)
            return FindKthSmallest(A, 0, B, 0, (m+n)/2+1);
        else
            return (FindKthSmallest(A, 0, B, 0, (m+n)/2) 
                    + FindKthSmallest(A, 0, B, 0, (m+n)/2+1))/2;
    }
}
