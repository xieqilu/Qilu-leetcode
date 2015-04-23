/**
Write an algorithm to determine if a number is "happy".

A happy number is a number defined by the following process: Starting with any positive integer, replace the number by the sum of the squares of its digits, and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.

Example: 19 is a happy number

12 + 92 = 82
82 + 22 = 68
62 + 82 = 100
12 + 02 + 02 = 1

But 4 is not a happy number because:
4, 16, 37, 58, 89, 145, 42, 20, 4....
And it ends in a infinite circle. 


Idea: 
So the key point for this problem is to check if the sequence of n would end in a circle without hit the 1
(Note the sequence 1,1,1,1,.... is also a circle). How to check if the sequence ends in a cirlce? Well, we
can check if the sequence encounters a number the previously appeared in this sequence. If this happens, then
the sequence must end in a circle. In fact, all numbers would end in a circle if we consider 1,1,1,1... is also
a circle. So after the sequence hit a circle, we just need to check if the current number is 1, if it is, then
it's a happy number. Otherwise it's not a happy number.


Solution1: 
This is the most regular way to solve this problem. We can use a HashSet to store all previous numbers in the 
current sequence. And use a while loop to generate the next number. If the current number is already in the HashSet, 
We need to terminate the while loop because we hit a circle. Then check if the last number is 1, if it is, return true.
Otherwise, return false.

Time complexity: maybe roughly O(logn)  Space complexity: same as time complexity


Solution2:
This is a more tricky solution. It based on the following fact:
All unhappy numbers will fall into a circle that invlove a number between 1 and 5. And in this range only 
1 is happy number, 2 to 5 are all not happy number. So we can actually keep generating the sequence and if
the current number is less than or equal to 5, terminate the while loop. Then check if this last number is
1 and return the result.

Time complexity: maybe roughly O(logn)   Space complexity: O(1)
*/

//Solution1: Using HashSet to store previous sum
public class Solution {
    public bool IsHappy(int n) {
        HashSet<int> set = new HashSet<int>();
        while(!set.Contains(n)){
            set.Add(n);
            int sum = 0;
            while(n>0){
                int digit = n%10;
                sum+=digit*digit;
                n/=10;
            }
            n=sum;
        }
        return n==1;
    }
}


//Solution2: Using just constant space 
class Solution {
    public bool IsHappy(int n) {
        while (n > 5) {
            int m = 0;
            while (n > 0) {
                m += (n % 10) * (n % 10);
                n /= 10;
            }
            n = m;
        }
        return n == 1; 
    }
}
