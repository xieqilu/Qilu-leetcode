/**
Given n non-negative integers representing an elevation map where the width of each bar is 1, 
compute how much water it is able to trap after raining.

For example, 
Given [0,1,0,2,1,0,1,3,2,1,2,1], return 6.

The above elevation map is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. 
In this case, 6 units of rain water (blue section) are being trapped. 


Idea:
This is a typical Dynamic Programming and Two Pointers problem. And the methods can be applied
to lots of other problems.

To fully understand this problem, we must know how to compute how much water a single bar
(an element in the array) can trap. By observing the image, we can know that for a specific bar
B in the array, there must be a heigher bar at the left of B and a heigher bar at the right of
B so that B can trap some water. And suppose the highest bar at the left is lh, and the highest
bar at the right is rh, then the bottelneck should be Math.Min(lh,rh). And the width of each bar
is always 1, so the amount of water B can trap is Math.Min(lh,rh)-B (B is an int element in the array).
Then for each B, we need to know Math.Min(lh,rh). If Math.Min(lh,rh)>B, B cannot trap water. Otherwise,
B can trap Math.Min(lh,rh)-B amount of water(the value could be 0).


Solution1: Iterate array twice. Use an array maxHeight to store Math.Min(lh,rh).
To get the above Math.Min(lh,rh) in linear time, we can iterate the array twice.
In the first iteration, for each element we find the max element at the left(lh) and store it to maxHeight.
In the second iteration, for each element we find the max element at the right(rh) and store 
Math.Min(lh,rh) to maxHeight. Then if maxHeight[i]>A[i], add maxHeight[i]-A[i] to result.
After the second iteration, we havd added the amount of water for each bar to result. 

Note: To find left max element, iterate from left to right. To find right max element, iterate
from right to left. Use an int max to store current left/right max element. Then for each element,
first let maxHeight[i]=max, then compare max with A[i] and try to update max.

Time: O(n) (O(2n))   Space: O(n)


Solution2: Iterate array just once and use constant extra space
This solution is the ultimate solution for this problem. It only iterates the array for once and uses
constant memory space. But it requires some serious thinking here.

This solution is a typical two pointers solution. We use two pointers L and R starting from the left and 
right end of the array (L=0, R=A.Length-1). Then we compare A[L] with A[R], if A[L]>A[R], store current 
A[L] as minL, then move L to right (L++). If after moving, A[L]<=minL, then minL must be the bottleneck for
current A[L]. Because minL is the highest bar on the left of A[L], and there is another right bar A[R] is
higher than A[L] and minL. minL-A[L] is the amount of water the current A[L] can trap. We keep moving L until
A[L]>minL, then we stop and compare current A[L] and A[R] and do the above process again. If A[R]<=A[L], we 
move R to the left (R--), the rest logic is exactly the same.

Then after one iteration, we can get the trapping amount for each element in A, thus we can get the final result.

Time: O(n)   Space: O(1)


Special Note: 
For the two pointers method, the key point is at any stage of the while loop, we can determine which pointer to
move so that the result could be better. Thus we can move one pointer at a time until they meet each other.
If at any stage moving two pointers can both make the result better, then this method cannot solve the problem.
*/


//Solution1: Iterate array twice   Time: O(n)  Space: O(n)
public class Solution {
    public int Trap(int[] A) {
        if(A==null || A.Length<2) 
            return 0;
        int[] maxHeight = new int[A.Length];//store Math.Min(leftMaxHeight,rightMaxHeight)
        int max = 0, res=0;
        //first iterate, store left max height for A[i] in maxHeight[i]
        for(int i=0;i<A.Length;i++){
            maxHeight[i]=max; //first store the current max for A[i] then update max
            max=Math.Max(max,A[i]);
        }
        
        max=0; //reset max and start iterate from end of A
        //second iterate, store minimum of left and right max height in maxheight[i]
        //Then try to update res
        for(int i=A.Length-1;i>=0;i--){
            maxHeight[i]=Math.Min(maxHeight[i],max); //get the min value of left and right max height
            max=Math.Max(max, A[i]);
            if(maxHeight[i]>A[i])  //if maxHeight[i]>A[i], A[i] can store water
                res+=maxHeight[i]-A[i];
        }
        return res;
    }
}


//Solution2: Best solution! Iterate Array once,  Time: O(n)  Space: O(1)
public class Solution {
    public int Trap(int[] A) {
        if(A==null || A.Length<2) 
            return 0;
        int L = 0, R=A.Length-1;
        int res=0;
        while(L<R){
            if(A[L]<A[R]){
                int minHeight = A[L];
                while(L<R && A[L]<=minHeight){
                    res+=minHeight-A[L];
                    L++;
                }
            }
            else{
                int minHeight = A[R];
                while(L<R && A[R]<=minHeight){
                    res+=minHeight-A[R];
                    R--;
                }
            }
        }
        return res;
    }
}
