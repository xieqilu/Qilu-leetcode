/**
Given a range [m, n] where 0 <= m <= n <= 2147483647, 
return the bitwise AND of all numbers in this range, inclusive.

For example, given the range [5, 7], you should return 4.


Idea:
This problem is a very good bitwise operation problem and tricky.
The naive solution is to do concecutive bitwise AND for all numbers between m and n.
The time complexity is O(m-n), which is clearly not good enough.

We can solve this problem in constant time by the following idea:
Note that all numbers between m and n is concecutive and they all have 32 binary digits. 

So for m and n, we can split the digits of them into two parts:
First part: the common head part, the first x digits of m and n are identical.
Second part: the different tail part, starting from the first digit that is different between m and n.

Then notice that if we do bitwise AND for all numbers from m to n, we actually set all bits in the second
part to 0. In other words, we erase all 1 in the second part of m and n. The result would be the first part
plus all 0s for the second part. That's because in the concecutive change of numbers between m and n, all digits
in the second part would be 0 for a certain number, thus the AND operation would set this digit for 0 finally.
Then the taks becomes find the common head for m and n, which can surely be done in constant time.


Solution1: best solution
Using the above idea. we use a while loop to shift m and n to right by 1 digit each pass, and use a variable
i to record the number of digits we have shifted until m!=n or m==0. Then i is the number of digits in the second
part. After the loop, restore m (or n) by shifting it to left by i digits to get the result.

Time complexity: O(1)  Worst case: O(32)


Solution2: 
The logic is excately the same. We use a while loop to find the number of digits in the second part without 
modifing m and n. Then after the loop, we have the number of digits in the second part. Then we can directly
set all digits in the second part to 0 for m (or n) to get the result.

Note: Suppose c is the number of digits we need to set to 0 in the second part, 
for i=0 to c-1, we do m &= ~(1<<i). The ~ operator will flip all bits for a number. 
So ~(1<<i) will turn the (i+1)th digit from right to 0 at each pass, then we eventually set 
the c lower digits to 0 for m. This is a very important technical trick for bitwise problem, 
must remember it solid.

Time complexity: O(1) 
*/

//Solution1: Time: O(1), worst case O(32)
public class Solution {
    public int RangeBitwiseAnd(int m, int n) {
        int i=0;
        while(m!=n&&m!=0){
            m>>=1;
            n>>=1;
            i++;
        }
        return m<<i;
    }
}
*/

//Solution2: Time: O(1) same as Solution1
public class Solution {
    public int RangeBitwiseAnd(int m, int n) {
       int c = 0;
       for(int i=0;i<32;i++){
           if(m>>i==n>>i){
               c=i;
               break;
           }
       }
       
       for(int i=0;i<c;i++)
            m &= ~(1<<i);
        return m;
    }
}
