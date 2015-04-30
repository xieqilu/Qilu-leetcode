/**
Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

For example,
S = "ADOBECODEBANC"
T = "ABC"
Minimum window is "BANC".

Note:
If there is no such window in S that covers all characters in T, return the emtpy string "".

If there are multiple such windows, you are guaranteed that there will always be only one unique minimum window in S.


Idea:
This is a classic Sliding Window problem. We can use two dictionary and two pointers to solve it. The two dictionary
are used to store the identity of chars in string t and current window of string s. Assume that s and t can only contain
ASCII chars, we can use two array instead of two dictionary, which are more easier to implement.

The basic idea is we use two pointers begin and end to traverse string s. Initially begin stays at index 0 and we traverse
s by incrementing end. When we move end to a certain index and we find a window that contains all chars in t, we try to move
begin forward as much as possible, as long as it won't affect the current window. When we cannot move begin that means we got
a current minimum window and we will try to update the final minimum window. 


Solution:
We use minBegin, minEnd, minWindowLen to store the begin index, end index and length of final minimum window.
And we use array toFind to store all the chars in t and array hasFound to store all the chars the current window contains.
Use count to keep track of how much char in t we have in current window, when count == t.Length, we got a valid window.

Detailed steps:
1, initially begina at 0, move end to traverse s.
2, if s[end] is not a char in t, continue.
3, if s[end] is a char in t, increment hasFound[s[end]] and check if current s[end] is needed for the window.
If hasFound[s[end]]<=toFind[s[end]], means s[end] is needed, so increment count. Otherwise, we have more s[end]
in the window than in t, so don't increment count.
4, if count==t.Length, then we try to move begin forward as much as possible.
5, while s[begin] is not in t OR we have more s[begin] in current window than in t, we can increment begin.
And everytime if we have more s[begin] in current window, decrement hasFound[s[begin]] before incrementing begin.
6, After the while loop, we got a current minimum window, then we compare the length with minWindowLen and try to
update all variables related finla minimum window (minWindowLen, minBegin, minEnd).
7, After the traverse, if count == t.Length, then we have found at least one minimum window, return the substring using
minBegin and minWindowLen. Otherwise, there is no valid window, return "".

Time complexity: O(n)
Although there is a innner while loop in the for loop, but we find that by using the two pointers, each char in s
will at most be visited twice, thus make it a linear time method.

Space complexity: O(1)
Because s and t only contains ASCII chars.

Note:
1, If s and t can contain other chars, we can simpley replace the two array with two dicitonary
2, Actually we only need two variables, minBegin and minWindowLen to store the information of final 
minimum window, we don't need minEnd.
3, We can actually solve this problem using only one dictionary/array by slightly modification.


Follow-up: what if we need to find a window that contains all chars in t with the same order?
*/

//Solution: 
public class Solution {
    public string MinWindow(string s, string t) {
        int[] toFind = new int[256]; //assume s and t only contains ASCII chars
        int[] hasFound = new int[256];
        foreach(char c in t)
            toFind[c]++;
        int begin=0, minBegin=0,count=0;
        int minWindowLen = int.MaxValue; //initial minWindowLen as the max int value
        for(int end=0; end<s.Length;end++){
            //skip char that not in t
            if(toFind[s[end]]==0)
                continue;
            hasFound[s[end]]++;
            if(hasFound[s[end]]<=toFind[s[end]]) //only increment count if s[end] is needed
                count++;
            //if find a window contains all chars in t
            if(count==t.Length){
                //try to move begin pointer to right as much as possible
                //if s[begin] is not needed for the window, move forward begin pointer
                while (toFind[s[begin]]==0 || hasFound[s[begin]]>toFind[s[begin]]){
                    if(hasFound[s[begin]]>toFind[s[begin]])
                        hasFound[s[begin]]--;
                    begin++;
                }
                //try to update minimum window using current window
                int windowLen = end - begin+1;
                if(windowLen < minWindowLen){
                    minBegin = begin;
                    minWindowLen = windowLen;
                }
            }
        }
        if(count == t.Length)
            return s.Substring(minBegin, minWindowLen);
        return "";
        
    }
}
