/**
Given a string S and a string T, count the number of distinct subsequences of T in S.

A subsequence of a string is a new string which is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (ie, "ACE" is a subsequence of "ABCDE" while "AEC" is not).

Here is an example:
S = "rabbbit", T = "rabbit"

Return 3.

Idea:
This is a clearly Dynamic Programming problem. Suppose the length of S is m, the length of T is n.
We need to use a martix dp[m+1, n+1] to store all intermediate information. dp[i,j] means the number of
subsequence T.Substring(0,j) in S.Substring(0,i). 

If the current element of S and T is equal, then we have the following two types of match for dp[i,j]:
1, Based on dp[i-1,j-1], we add the same char to S and T and the match won't change. So the value of
dp[i-1,j-1] shoud be added.
2, Based on dp[i-1,j], we can change the last match char in T to match the current char of S (no matter where
the original matching char in S is). So the value of dp[i-1,j] should be added.

If the current char of S and T is not equal. Then dp[i,j] must be equal to dp[i-1,j]. Because the current char
of T cannot be matched to S, so the number of T.Substring(0,j) in S.Substring(0,i) is equal to the number of
T.Substring(0,j) in S.Substring(0,i-1). The current char of S cannot help to match more T.Substring(0,j), because
S[i-1] and T[j-1] is not equal.



Solution:
We find the following relationship to construct dp[i,j]:
1, Note dp[i,j] is related to the char S[i-1] and T[j-1].
2, If S[i-1]==T[j-1], then dp[i,j] = dp[i-1,j-1]+dp[i-1,j].
3, Else, dp[i,j] = dp[i-1,j].

Use the above relationship to construct the matrix and return the right up corner element of it.
Return dp[m,n].

Time complexity:  O(m*n)
*/

//DP Solution   Time: O(m*n)
public class Solution {
    public int NumDistinct(string S, string T) {
        int m = S.Length, n = T.Length;
        int[,] dp = new int[m+1,n+1]; //default value is 0
        for(int i=0;i<m+1;i++)
            dp[i,0] =1;
        for(int i=1;i<m+1;i++){
            for(int j=1;j<n+1;j++){
                if(S[i-1]==T[j-1]) //dp[i,j] is related to S[i-1] and T[j-1]
                    dp[i,j] = dp[i-1,j-1]+dp[i-1,j];
                else
                    dp[i,j] = dp[i-1,j];
            }
        }
        return dp[m,n];
    }
}
