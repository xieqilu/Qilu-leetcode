/**
 * Given an array of size n, find the majority element. 
 * The majority element is the element that appears more than ⌊ n/2 ⌋ times.

You may assume that the array is non-empty and the majority element always exist in the array.


Solution:
There several different approaches to solve this problem as follows:
1,Runtime: O(n2) — Brute force solution: Check each element if it is the majority element.

2,Runtime: O(n), Space: O(n) — Hash table: Maintain a hash table of the counts of each element, then find the most common one.

3,Runtime: O(n log n) — Sorting: As we know more than half of the array are elements of the same value, we can sort the array and all majority elements will be grouped into one contiguous chunk. Therefore, the middle (n/2th) element must also be the majority element.

4,Average runtime: O(n), Worst case runtime: Infinity — Randomization: Randomly pick an element and check if it is the majority element. If it is not, do the random pick again until you find the majority element. As the probability to pick the majority element is greater than 1/2, the expected number of attempts is < 2.

5,Runtime: O(n log n) — Divide and conquer: Divide the array into two halves, then find the majority element A in the first half and the majority element B in the second half. The global majority element must either be A or B. If A == B, then it automatically becomes the global majority element. If not, then both A and B are the candidates for the majority element, and it is suffice to check the count of occurrences for at most two candidates. The runtime complexity, T(n) = T(n/2) + 2n = O(n log n).

6,Runtime: O(n) — Moore voting algorithm: We maintain a current candidate and a counter initialized to 0. As we iterate the array, we look at the current element x:
If the counter is 0, we set the current candidate to x and the counter to 1.
If the counter is not 0, we increment or decrement the counter based on whether x is the current candidate.
After one pass, the current candidate is the majority element. Runtime complexity = O(n).

7,Runtime: O(n) — Bit manipulation: We would need 32 iterations, each calculating the number of 1's for the ith bit of all n numbers. Since a majority must exist, therefore, either count of 1's > count of 0's or vice versa (but can never be equal). The majority number’s ith bit must be the one bit that has the greater count.

Below are the implementations of Solution2 and Solution6. Between the below two solutions, solution6 is better for this
specific problem because it needs no extra memory space. But Solution2 is a more general solution and can be applied to
different similiar problems.
*/

//Solution2  Time: O(n)  Space:O(n)
public class Solution {
    public int MajorityElement(int[] num) {
        int count=0,result=0;
        foreach(int i in num){
            if(count==0) result=i;
            if(i==result) count++;
            else
                count--;
        }
        return result;
    }
}


//Solution6 Time:O(n)  Space:O(1)
public class Solution {
    public int MajorityElement(int[] num) {
        if(num.Length==1) return num[0];
        Dictionary<int,int> map = new Dictionary<int,int>();
        foreach(int i in num){
            if(map.ContainsKey(i)){
                map[i]++;
                if(map[i]>num.Length/2)
                    return i;
            }
            else
                map.Add(i,1);
        }
        return -1;
    }
}
