/**
Write a function that takes an unsigned integer and returns the number of ’1' bits it has (also known as the Hamming weight).

For example, the 32-bit integer ’11' has binary representation 00000000000000000000000000001011,
so the function should return 3.


Solution:
It's actually counting how many set bits in a binary representation. 
Use n&(n-1) to get rid of the last 1 of n, keep doing it until n==0
and count how many 1 can we get rid of from n.

The time complexity is O(m), m is the number of 1 in n. So in the worst
case it's O(n) when all bits of n is 1.
*/

public class Solution {
    public int HammingWeight(uint n) {
        int count=0;
        while(n!=0){
            n=n&(n-1);
            count++;
        }
        return count;
    }
}
