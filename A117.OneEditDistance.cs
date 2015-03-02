/**
 * Given two strings S and T, determine if they are both one edit distance apart.
 * 
 * Solution:
 * Suppose the length of s is m and the length of t is n.
 * Assume m<=n will greatly reduce the conditional statement in the method.
 * If m>n, we just return the method itself swap the position of s and t.
 * 
 * Now we know m<=n, get get the length difference of m and n as lengthDiff.
 * if lengthDiff>1, we immediately know s and t cannot be one edit distance, return false.
 * if lengthDiff=0 (s and t have the same length), we just need to check if there is
 * exactly one element different between the two strings.
 * if lengthDiff=1, we need to check if s can be converted to t by inserting exactly
 * one element.
 * 
 * Now lengthDiff could be 0 or 1. Then we use a while loop to iterate s and t.
 * If s[i]!=t[i] or i=m, the loop will break.
 * 
 * After the loop, we check why the loop break. If i==m, the loop break because
 * i reaches the end of m. Then if lengthDiff is 0, s and t are the same, return false;
 * If lengthDiff is 1, return true;
 * 
 * If the loop break because at some point s[i]!=t[i], then we need to check lengthDiff.
 * If lengthDiff is 0, increment i and use a while loop to continue compare s[i] and t[i].
 * If lengthDiff is 1, use a while loop to continue compare s[i] and t[i+1].
 * 
 * We can combine the above two conditions together by using a while loop to compare
 * s[i] and t[i+lengthDiff], if lengthDiff is 0, i has been incremented, so it's actually
 * s[i] and t[i]. If lengthDiff is 1, it's actually s[i] and t[i+1].
 * 
 * After the second while loop, if i==m, then there is only one edit distance, return true.
 * Otherwise (i<m), there are at least two edit distances, return false.
 * 
 * 
 * Time Complexity: O(n)
 * 
 * Space Complexity: O(1)
 * */


using System;

namespace OneEditDistance
{
	class MainClass
	{
		public class Solution
		{
			public bool IsOneEditDistance(string s, string t){
				int m = s.Length, n = t.Length;
				if (m > n)
					return IsOneEditDistance (t, s);
				int lengthDiff = n - m;
				if (lengthDiff > 1)
					return false;
				int i = 0;
				while (i < m && s [i] == t [i])
					i++;
				if (i == m)
					return lengthDiff > 0; //if lengthDiff is 0, flase; if it is 1, true
				if (lengthDiff == 0)
					i++;
				while (i < m && s [i] == t [i + lengthDiff])
					i++;
				if (i < m)
					return false;
				return true;
			}
		}
		public static void Main (string[] args)
		{
			Console.WriteLine (new Solution().IsOneEditDistance("teacher","beacher")); //true
			Console.WriteLine (new Solution().IsOneEditDistance("teacher","leacher")); //true
			Console.WriteLine (new Solution().IsOneEditDistance("teacher","beacherk"));//false
			Console.WriteLine (new Solution().IsOneEditDistance("teacher","teacher")); //false
			Console.WriteLine (new Solution().IsOneEditDistance("",""));//false
		}
	}
}
