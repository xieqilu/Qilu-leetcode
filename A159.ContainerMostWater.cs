/**
Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate (i, ai). 
n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). 
Find two lines, which together with x-axis forms a container, such that the container contains the most water.

Note: You may not slant the container.

Understand the problem:
We can think of the given array stores heights of n different lines. Our task is to find two lines to form 
a container with the x-axis that contains most water. The container is actually a rectangle. Suppose two lines
are at (i,ai) and (j,bj), i and j are the index and ai and bj are the height. So the area of the rectangle is
Math.Min(ai,bj)*(j-i), assume j>i. The return value is the area of rectangle.


Solution: Two pointers
From the above analysis, we know that the area of rectangle is related to two factors: (j-i) and the shorter
height of ai and bj. To solve this problem in linear running time, we don't need to caculate each (i,j) pair
in the array. We can set the initial maxArea as large as possible, then try to test any other (i,j) pair that
could possibly produce a larger area than the initial maxArea. If we are given the array, we know the max value
of (j-i), and we can use it to set the initial maxArea.

So firstly set the two pinters as L=0 and R=array.Count-1. Now we have the max value of (R-L), and caculate the 
current area as the initial maxArea. 
Then we get the current value of array[L] (lHeight) and array[R] (rHeight).
Now if lHeight<rHeight, that means lHeight is the bottleneck of the current area. To find a possible larger area,
we need to change lHeight, so move L to right until array[L]>lHeight. Then this area may be larger than maxArea.
Otherwise, rHeight is the bottleneck of the current area. To find a possible larger area, we need to change rHeight,
so move R to left until array[R]>rHeight, then we got an area that may be larger than maxArea. When moveing L or R,
we make sure L<R, if the two pointers meet each other, stop this process.
Each time we got a possible larger area, we compare it with maxArea and try to update maxArea. 
We keep doing the above process until the two pointers meet with each other. Then we stop and return maxArea.

Thoughts:
So when intially set the maxArea, we use the max value of (j-i), we cannot find a larger value of (i-j) in the
given array. But the value of array[L] and array[R] could change and be much larger than the initial lHeight 
and rHeight. So if a new array[L] is not larger than lHeight, there is no need to compare and update maxArea, 
because the current area must be smaller than maxArea. For array[R], the logic is the same.
The key point is when we have two factors that can affect the result, we need to find a way to firstly get the best
of one factor, then try to change the second factor and update possible better result.

Time complexity: O(n)
*/

//Solution: Two pointers  Time: O(n)
public class Solution { 
    public int MaxArea(IList<int> height) {
        if(height.Count<2) return 0;
        int maxArea = 0;
        int L=0, R=height.Count-1;
        while(L<R){
           int lHeight = height[L], rHeight=height[R];
           max = Math.Max(maxArea, Math.Min(lHeight,rHeight)*(R-L));
           if(lHeight<rHeight){
               while(L<R && height[L]<=lHeight)
                    L++;
           }
           else{
               while(L<R && height[R]<=rHeight)
                    R--;
           }
        }
        return maxArea;
    }
}
