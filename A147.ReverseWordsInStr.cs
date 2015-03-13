/**
 * Given an input string, reverse the string word by word. A word is defined as a sequence of non-space characters.

The input string does not contain leading or trailing spaces and the words are always separated by a single space.

For example,
Given s = "the sky is blue",
return "blue is sky the".

Could you do it in-place without allocating extra space?

Related problem: Rotate Array


Solution:
This problem is very similiar to Rotate Array! The method and trick is exactly the same.
The trick is to do multiple reverse operation. If the input char array contains n words, 
then we need to do (n+1) reverse operations. In detail, we need to reverse each word
independentely and then reverse the entire char array.

So we need a private reverse method which would reverse a part of the array. The input
is the array, int start and int end. The method will reverse a part of the array (from
start to end).

Note that in this problem the char array doesn't contain leading and trailling spaces
and there is only one space between two words. So when iterating the array, 
if the current char is a space, then the char before it is the end of a word. 
Also if the current char is the last char of the array,
then it must be the end of the last word.
*/

public class Solution {
    public void ReverseWords(char[] s) {
        int start=0;
        for(int i=0;i<s.Length;i++){
            if(s[i]==' '){
                ReverseHelper(s, start, i-1);
                start = i+1;
            }
            if(i==s.Length-1)
                ReverseHelper(s, start, i);
        }
        ReverseHelper(s, 0, s.Length-1);
    }
    
    private void ReverseHelper(char[] s, int start, int end){
        while(start < end){
            char temp = s[start];
            s[start] = s[end];
            s[end] = temp;
            start++;
            end--;
        }
    }
}
