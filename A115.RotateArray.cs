/**
Rotate an array of n elements to the right by k steps.

For example, with n = 7 and k = 3, the array [1,2,3,4,5,6,7] is rotated to [5,6,7,1,2,3,4].

Could you do it in-place with O(1) extra space?
*/

/**
Solution:
This efficient Solution is truly a TRICK! It's so tricky that I must remember this!

The trick is to do three reverse operation. One for the entire string, 
one from index 0 to k-1, and lastly index k to n-1. 
Magically, this will yield the correct rotated array, without any extra space! 

We need a private reverse method to do this. The reverse method takes three arguments:
the array, an int pointer start, an int pointer end. Then we just swap array[start] and
array[end] and increment start and decrement end until they meet each other.
In one word: the reverse method will reverse a part of the input array. (start-end).

Time Complexity: 
Space Complexity: O(1)
*/

public class Solution {
    private void Reverse(int[] nums, int start, int end){ //O(n)
        while(start<end){
            int temp = nums[start];
            nums[start]= nums[end];
            nums[end] = temp;
            start++;
            end--;
        }
    }
    
    public void Rotate(int[] nums, int k) {
        if(k==0) return;
        int n=nums.Length;
        k%=n; //if k>n, we only need to rotate (k%n) times
        
        //Reverse 3 times, each takes at most O(n) time
        Reverse(nums,0,n-1);
        Reverse(nums,0,k-1);
        Reverse(nums,k,n-1);
    }
}
