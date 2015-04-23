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
Wikipedia Reference for Happy Number:
http://en.wikipedia.org/wiki/Happy_number

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

Time complexity: O(log*n) or almost O(1)  Space complexity: O(log*n)


Solution2:
This is a more tricky solution and requires more thinking and observation. 

Quote from Wikipedia:
Note that if n has m digits, then the sum of the squares of its digits is at most 9^2 m, or 81m.

For m=4 and above,

n>=10^(m-1)>81m
so any number over 1000 gets smaller under this process and in particular becomes a number with strictly fewer digits. Once we are under 1000, the number for which the sum of squares of digits is largest is 999, and the result is 3 times 81, that is, 243.

In the range 100 to 243, the number 199 produces the largest next value, of 163.
In the range 100 to 163, the number 159 produces the largest next value, of 107.
In the range 100 to 107, the number 107 produces the largest next value, of 50.

Considering more precisely the intervals [244,999], [164,243], [108,163] and [100,107], we see that every number above 99 gets strictly smaller under this process. Thus, no matter what number we start with, we eventually drop below 100. An exhaustive search then shows that every number in the interval [1,99] either is happy or goes to the above cycle (4, 16, 37, 58, 89, 145, 42, 20, 4....).

The above work produces the interesting result that no positive integer other than 1 is the sum of the squares of its own digits, since any such number would be a fixed point of the described process.

From the above proving process from Wikipedia, we know that for any number, no matter what number we start, we eventually drop below 100. So we don't need to store all previous number, we just need to store the number that's less than 100. A number which is larger than 100 cannot become a part of the circle. So that we at most store 100 numbers in the HashSet, that makes the space complexity constant.

Time Complexity: O(log*n) or almost O(1)   Space Complexity: O(1)


Solution3:
This is a so tricky solution. It also based on the above quote from Wikipedia.
Note "An exhaustive search then shows that every number in the interval [1,99] either is happy or goes to the above cycle (4, 16, 37, 58, 89, 145, 42, 20, 4....)." That means every unhappy number, no matter what it is, will go to the circle starting from 4. So for a number, there are only two destination for it: 
1, go to 1 and thus it's a happy number
2, go to 4 and thus it's an unhappy number

So based on this theory, and we already know that 2,3,5,6 are not happy numbers, so we can just terminate the while loop
when n<=6, then check if current n is 1 to get result.

Time complexity: O(log*n) or almost O(1)   Space complexity: O(1)


Anylsis of Time Complexity:
Iterated Algorithm reference from Wikipedia:
http://en.wikipedia.org/wiki/Iterated_logarithm

The time complexity is O(log*n), pronunced as log start n.
If n<=1000, then reach circle or reach 1 in at most 1001 steps.
If n>1000, suppose n has m digit and the next number is n1. From above Wikipedia quote, we know that
n1 < 81*m, and m=log(10)n+1, so n1<81*(log(10)n+1), n1 = O(logn).

The iteration formula for this solution is:
if n<=1000, log*n = 1001
if n>1000, log*n = 1001 + log*(logn)

The above is a typical formula for iterated algorightm (check the reference), thus the time complexity is O(log*n).
In reality, O(log*n) grows very slow that we can treat it as constant O(1).

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


//Solution2: Using constant space for HashSet
public class Solution {
    public bool IsHappy(int n) {
        HashSet<int> set = new HashSet<int>();
        while(!set.Contains(n)){
            if(n<100) //or if(n<243) both are constant space
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


//Solution3: without using HashSet
class Solution {
    public bool IsHappy(int n) {
        while (n > 6) {
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
