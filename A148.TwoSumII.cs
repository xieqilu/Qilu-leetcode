/**
Given an array of integers that is already sorted in ascending order, 
find two numbers such that they add up to a specific target number.

The function twoSum should return indices of the two numbers such that they add up to the target, 
where index1 must be less than index2. 
Please note that your returned answers (both index1 and index2) are not zero-based.

You may assume that each input would have exactly one solution.

Input: numbers={2, 7, 11, 15}, target=9
Output: index1=1, index2=2


Idea:
In this problem, the input array is already sorted. So we should not use the HashTable solution
in the original Two Sum problem, which costs us extra O(n) space and doesn't use the sorted feature
of the input array. We are supposed to come up with a constant space solution.


Solution1: Binary Search
As the input array is already sorted, we can use binary search to check if an element exists in it.
So we iterate through the input array numbers, for each i, try to find target-numbers[i] using binary
search (a private method will do it). 
Note that for an index i, we don't need to check if target-numbers[i] exists in the whole input array.
we only need to check if it exists from index i+1 to end of input array. Because for all element before
numbers[i], we have already tried to find the pair element for them, we don't need to do it again.

Time: O(nlogn)   Space:O(1)
The time complexity of binary search is O(logn), in the worst case we need to do it for n times. So overall
the time complexity is O(nlogn).


Solution2: Two Pointers
We can use a brilliant two pointers solution to get even better running time!
Note that we should return indices of two numbers that add up to input target, and index1 must be less than index2.
That means we must find two different elements. So we can use two pointers, p1 is at the start of input array and p2
is at the end. Then while p1<p2 (make sure they point to different elements), 

Each time we compare the sum of numbers[p1] and numbers[p2] with target. We have three situations:
1, if sum > target, then we need to make sum smaller, so we decrement p2.
2, if sum < target, then we need to make sum greater, so we increment p1.
3, if sum==target, then we have found the answer.

If after the while loop, the method still doesn't return, we should throw an IllegalArgumentException.

Time: O(n)   Space: O(1)
*/


//Solution1: Binary Search
class Solution {
    public Tuple<int, int> TwoSum(int[] numbers, int target) {
        for(int i =0;i<numbers.Length;i++){
            //for each i, try to find target-numbers[i] from index i+1 to the end
            int result = BinarySearch(numbers, target-numbers[i],i+1);
            if(result!=-1)
                return new Tuple<int,int>(i+1, result+1);//note returned index is not zero-based
        }
        throw new ArgumentException("No Two Sum Solution!", "target");
    }
    
    //Binary Search, try to find target in numbers from index start to the end
    private int BinarySearch(int[] numbers, int target, int start){
        int L = start, R=numbers.Length-1;
        while(L<=R){
            int M = (L+R)/2;
            if(numbers[M]>target)
                R=M-1;
            else if(numbers[M]<target)
                L=M+1;
            else
                return M;
        }
        return -1; //means cannot find target in numbers
    }
}


//Solution2: Two Pointers
class Solution {
    public Tuple<int, int> TwoSum(int[] numbers, int target) {
        int p1=0, p2=numbers.Length-1;
        while(p1<p2){ //if p1==p2, search should be over
            int sum = numbers[p1]+numbers[p2];
            if(sum>target)
                p2--;
            else if(sum<target)
                p1++;
            else
                return new Tuple<int,int>(p1+1,p2+1); //note returned index is not zero-based
        }
        throw new ArgumentException("No Two Sum Solution!", "target");
    }
}
