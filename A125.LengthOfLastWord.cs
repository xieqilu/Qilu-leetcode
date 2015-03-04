/**
Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.

If the last word does not exist, return 0.

Note: A word is defined as a character sequence consists of non-space characters only.

For example, 
Given s = "Hello World",
return 5.


Solution:
This is an easy string problem. 
We need totally three pointers to solve the problem. 
start: keep track of the starting position of each word.
end: keep track of the ending position of each word.
next: used to iterate each char of the input string.

We need to firstly use advance start pointer to the first non-space char of the input string.
If there is no non-space char, then there is no word, we return 0.

Then we use next to iterate the string. If s[next] is not a space and s[next-1] is a space, 
we find a starting position of a word and update start=next.
If s[next] is not a space and s[next] is space or next is at the end of the string, we find
a ending position of a word and update end=next.

After the traversal, we return end-start+1.

Time complexity: O(n) n is the length of the input string
*/

public class Solution {
    public int LengthOfLastWord(string s) {
        int start=0;
        while(start<s.Length&&s[start]==' ')
            start++;
        if(start==s.Length) return 0;
        
        int next=start+1, end=start;
        while(next<s.Length){
            if(s[next]!=' '&&s[next-1]==' ')
                start = next;
            if(s[next]!=' '&&(next==s.Length-1||s[next+1]==' '))
                end = next;
            next++;
        }
        return end-start+1;
    }
}
