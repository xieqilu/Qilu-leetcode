/**
Related to question Excel Sheet Column Title

Given a column title as appear in an Excel sheet, return its corresponding column number.

For example:

    A -> 1
    B -> 2
    C -> 3
    ...
    Z -> 26
    AA -> 27
    AB -> 28 
    
    

Solution:
This is a fairly simple math problem. Much simpler than converting excel sheet column to number.
Basically, we visit each char of the input string, and map the char to number (1 to 26), and multiply
the number with corresponding power of 26.

The last char should be multiplied with pow(26,0), then pow(26,1).....to pow(26,s.Length-1).
We can iterate each char in the input string, and use s[i]-'A'+1 to get the number, then use
Math.Pow(26, s.Length-1-i) to get the multiplier.

Time: O(n)
*/

public class Solution {
    public int TitleToNumber(String s) {
        if(s.Length==0 || s==null) return 0;//handle edge case
        int num = 0;
        for(int i=0;i<s.Length;i++){
            num+= (s[i]-'A'+1)*(int)Math.Pow(26,s.Length-1-i);
        }
        return num;
    }
}
