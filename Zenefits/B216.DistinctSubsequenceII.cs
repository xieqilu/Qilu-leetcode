/**
String s1 = "waeginsapnaabangpisebbasepgnccccapisdnfngaabndlrjngeuiogbbegbuoecccc";
String s2 = "a+b+c-";

s2的形式是一个字母加上一个符号，正号代表有两个前面的字符，负号代表有四个，
也就是说s2其实是"aabbcccc"，不考虑invalid。
在s1中，找出连续或者不连续的s2，也就是说从s1中找出"aa....bb.....cccc"，abc顺序不能变，
但是之间可以有零个或多个字符，返回共有多少个。在上面这个例子中，有四个.


Idea:
This problem is very similiar to Distinct Subsequence from Leetcode. The difference is that in this
problem aa, bb and cccc should be treated as a whole object. In other words, s1 must have two concecutive
'a' to match aa in s2, the two 'a' cannot be seperate.
We can convert s1 to use a single 'a' to represent 'aa' or 'aaaa', same as 'b' and 'c'. And also
convert s2 to use 'a' represent 'a+' or 'a-' and same as 'b+/-' and 'c+/-'. Then use the same method
in Distinct Subsequence to solve this problem.

Note: We assume that if 'a+' is in s2, there won't be any 'a-', and s1 will only contain a or aa,
ther won't be any aaa or aaaa. 

Solution:
1, use two StringBuilder to convert s1 and s2. Use a dictionary to store the identity of s2, the
key is the char, and value is the number of following chars needed. For a+, the value is 1, for a-,
the value is 3.
2, then use the dictionary to convert s1. Ignore the chars not in s2, and for each char that is in
s2, check if there are enough following same chars to match. If there are, append the current char
to sb2.
3, After converting s1 and s2, pass the two converted strings to Dinstinct Subsequence method to 
get the result.

Time complexity: O(m*n)  m and n are the length of s1 and s2.
Space complexity: O(m*n)  the size of dp matrix

Follow-up:
1, what if there could be lots of concecutive a in s1? Like aaa, aaaa,.....
As long as the there won't be concecutive a+ or a- in s2, the solution should be fine.

2, what if there also could be concecutive a+ and a- in s2?
In this situation, we need to distinguish the difference of a+ and a-, we can consider to use the 
uppercase A to represent a- and lowercase a to represent a+.
*/

using System;
using System.Collections.Generic;
using System.Text;

public class Test
{
	public static int GetNumSubsequence(string s1, string s2){
		StringBuilder sb1 = new StringBuilder();
		StringBuilder sb2 = new StringBuilder();
		//use dictionary to store the identity of s2
		Dictionary<char, int> dict = new Dictionary<char, int>();
		//convert s2
		for(int i=0;i<s2.Length;i+=2){
			sb2.Append(s2[i]);
			dict.Add(s2[i], s2[i+1]=='+'? 1:3);
		}
		//convert s1
		for(int i=0;i<s1.Length-1;i++){
			if(!dict.ContainsKey(s1[i]))
				continue;
			int value = dict[s1[i]];
			if(IsValid(s1, i, value))
				sb1.Append(s1[i]);
		}
		
		return DistinctSubsequence(sb1.ToString(), sb2.ToString());
	}
	
	//method to check if the following chars in s1 match 
	private static bool IsValid(string s1, int i, int value){
		if(i+value>s1.Length-1)
			return false;
		for(int j=1;j<=value;j++){
			if(s1[i+j]!=s1[i])
				return false;
		}
		return true;
	}
	
	//method to get number of distinct subsequence, Leetcode
	private static int DistinctSubsequence(string s1, string s2){
		int m = s1.Length, n = s2.Length;
		int[,] dp = new int[m+1, n+1];
		for(int i=0;i<m+1;i++)
			dp[i,0] = 1;
		for(int i=1;i<m+1;i++){
			for(int j=1;j<n+1;j++){
				if(s1[i-1] == s2[j-1])
					dp[i,j] = dp[i-1,j] + dp[i-1,j-1];
				else
					dp[i,j] = dp[i-1,j];
			}
		}
		return dp[m,n];
	}
	
	public static void Main()
	{
		string s1 = Console.ReadLine();
		string s2 = Console.ReadLine();
		Console.WriteLine(GetNumSubsequence(s1,s2));
	}
}
