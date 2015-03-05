/**
Given a string containing just the characters '(' and ')', 
find the length of the longest valid (well-formed) parentheses substring.

For "(()", the longest valid parentheses substring is "()", which has length = 2.

Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.


Solution:
This is a Dynamic Programming about matching parentheses. 
To match parentheses, we definitely need to use a stack. And Dynamic Programming requires us to store the 
intermeidate results.

Idea:
Use a stack to store the index of left paren and an array to store the index of longest matched point. 
The array dp has the same length of the string. And dp[i] stores the starting point of longest valid 
parentheses for current char s[i]. So if s[i] is a left paren, then dp[i] will always be -1 (initial value).
If s[i] is a right paren, then dp[i] could be another value.

We will also use an int max to record the length of longest valid parentheses.

Detailed process:
Iterate through each char of string s, operation is as follows:
1, if s[i] is a left paren, we just push index (i) into the stack.
2, if s[i] is a right paren, then we check if stack contains any element. If stack is now empty, that means
there is no left paren to match before current right paren, then ignore this right paren and continue.
If stack is not empty, pop the stack to get the index of matching left paren (m) for current right paren. Then
check if m>0 and dp[m-1] is not -1. 
If m=0, that means the matching left paren is the first char of the string. If dp[m-1]=-1, that means there is 
no valid substring that can directly connect to the current matching left paren. In both situations, we directly
set dp[i]=m. 
If m>0 and dp[m-1] is not -1. That means there is another valid string that directly connects to the matching left
paren and we need to connect s.Substring(m,i) to the previous valid string to get a longer valid string. So we set
dp[i]=dp[m-1]. 
Each time after updating dp[i], we compare i-dp[i]+1 and current max length, and try to update current max length.

And eventually, we return max which is the final length of longest valid parentheses substring.

Time Complexity: O(n)  Iterate the input string jus once
Space Complexity: O(n)
*/

public class Solution {
    public int LongestValidParentheses(string s) {
        Stack<int> stack = new Stack<int>();
        int[] dp = new int[s.Length];
        int max=0;
        for(int i=0;i<dp.Length;i++)
            dp[i]=-1;
        for(int i=0;i<s.Length;i++){
            if(s[i] == '(')
                stack.Push(i);
            else if(stack.Count!=0){ //if(s[i]==')')
                int m = stack.Pop();
                if(m>0&&dp[m-1]!=-1) //m==0 means last matching left paren is the first char
                    dp[i] = dp[m-1]; //if dp[m-1]!=-1, dp[m-1] must be greater than m
                else
                    dp[i]=m;
                int len = i-dp[i]+1;
                max=Math.Max(max,len);
            }
        }
        return max;
    }
}
