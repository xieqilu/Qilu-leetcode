/**
Reverse bits of a given 32 bits unsigned integer.

For example, given input 43261596 (represented in binary as 00000010100101000001111010011100), 
return 964176192 (represented in binary as 00111001011110000010100101000000).

Follow up:
If this function is called many times, how would you optimize it?


Solution1: my Solution
For this problem, I think my solution is more readable and understandable than Leetcode official Solution.
The idea is very simple, we just construct the new int reversely according to digits of input int. Suppose
input int is n and new int is m. We use a for loop to do the operation for exactly 32 times. In each pass,
first get the last digit of n by n%2, then shift m to left by 1 digit. Then if n%2 is 1, we add 1 to m. If
n%2 is 0, we don't need to modify m because by shifting m to left by 1 digit, an 0 is automatically added
to m. Then we shift n to right by 1 digit to get rid of the last digit of n.

After the loop, m is the exactly reversed version of n, just return m.

Time complexity: O(1) (O(32)), since we will do the operation for exactly 32 times.


Solution2: Leetcode official Solution
The Leetcode official solution is a little bit confusing and not very readable. And it requires a lot of
pre-defined binary Mask. So still need to be understood for me.
Will update soon.
*/

//Solution1: My solution
public class Solution {
    public uint reverseBits(uint n) {
        uint m = 0;
        for(int i=0;i<32;i++){ //loop for exactly 32 times
            uint curr = n%2; //get the last binary digit of n
            m<<=1;  //shift m to left by 1 digit, an 0 automaticaly added to m
            if(curr==1) //if curr is 1, add 1 to m, manually turn the last digit from 0 to 1
                m+=1;
            n>>=1; //shift n to right by 1 digit, to get rid of last digit of n
        }
        return m;
    }
}
