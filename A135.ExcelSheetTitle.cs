/**
Given a positive integer, return its corresponding column title as appear in an Excel sheet.

For example:

    1 -> A
    2 -> B
    3 -> C
    ...
    26 -> Z
    27 -> AA
    28 -> AB 



Solution1: My Solution
Use a char array to map 1-26 to A-Z, and use standard process to convert a 10 base number to
26 base char representation. But there is a slight but important difference between char representation
in this problem and a standard 26 base number.
The char representation starts from number 1 instead of number 0. And there is no char that is equal to
number 0. In other words, 0 is not a valid number for the conversion. And if the number is 26, the string
is Z instead of A0, if the number is 52, the string is AA instead of B0. 
So in this solution, we need modify the standard process a little bit. The first element of the char map array
should be Z. And if n is an integer times of 26 and n is larger than 26. We need to handle this case specially.
After get the last digit of string by n%26 and move to second last digit by n/26, we need to decrement n because 
there is a 26 would be represented as Z at the end of the string. 


Solution2: Leetcode Official Solution
Set int head as 64, which is the ASCII number right before 'A' (65). So we can use head+1 to head+26 to map 1-26 
to 'A' to 'Z'. Then according to the above special situation, we use n%26 to get each digit, if the current digit 
is 0, we map it to head+26, otherwise,map it to head+current digit. After each mapping, let n=(n-current digit)/26.
If current digit is not 26, then (n-current digit)/26 == n/26, if current digit is 26, then (n-current digit)/26
is equal to n/26-1. So this solution also handles the special case correctlly.
And this solution won't need us to define a char array, thus it's a better solution.
*/

//Solution1: My solution
public class Solution {
    public String ConvertToTitle(int n) {
        int m=n;
        char[] map = new char[]{
            'Z', 'A', 'B', 'C','D','E','F','G','H',
            'I','J','K','L','M','N','O','P','Q','R',
            'S','T','U','V','W','X','Y'
        };
        StringBuilder sb = new StringBuilder();
        while(n>26){
            int curr=n%26;
            sb.Insert(0,map[curr]);
            n=n/26;
            if(m%26==0&&m/26>1)
                n--;
        }
        sb.Insert(0,map[n%26]);
        return sb.ToString();
    }
}

//Solution2: Leetcode official Solution
public class Solution {
   public String ConvertToTitle(int n) {
        int head = 64;
        StringBuilder ret = new StringBuilder();
        while (n > 0) {
            int last = n % 26;
            last = (last == 0) ? 26:last;
            ret.Insert(0, (char)(head + last));
            n = (n - last) / 26;
        }
        return ret.ToString();
    }
}
