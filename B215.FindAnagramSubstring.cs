/**
String input (M)
String pattern (N)

# output me the number of substrings in input that is an anagram of pattern

Example:
input：abcba
pattern：abc
output: 2  (abc, cba)


Idea: 
This problem is very similiar to Minimum Window Substring but actually easier. The length of pattern
is fixed so we only need to check all substrings that has the same length as pattern. So we will use
a sliding winodw that has the same length of pattern. In each pass, move the window one step forward.
Then there is a char that goes out of the window and a char goes into the window. So we handle these
two chars and update the HashMap (array) and count accordingly. We also check count, if it's equal
to the length of pattern, we find an anagram substring, increment res.


Solution:
We will also use two array toFind and hasFound with length of 256 to serve like hashtable.
Suppose the length of input is m and the length of pattern is n. 
1, Construct toFind array according to the char in pattern.
2, Then initially check the first substring input.Substring(0,n) and for each char c, if it's not 
in pattern, continue. If it's in pattern, hasFound[c]++ and if c is needed to match pattern, increment
count.
3, After the initial check, if count==n, the first substring is an anagram, res++
4, Then we go to the for loop to traverse input. Use i starting from 1, and until i<=m-n. Because
if i >m-n, there is no enough chars to match pattern. Then in each pass, get the char goes out of
window, prev(input[i-1]) and the char goes into the window, curr(input[i+n-1]). Then if prev is
in pattern, hasFound[prev]--, and if prev is needed to match pattern, count--. If curr is in pattern,
hasFound[curr]++, and if curr is needed to match pattern, count++. Then if count==n, res++.

Time complexity: O(n), n is the length of input

Note: the key point is to distinguish whether prev and curr is needed to match pattern or not.
For prev, after hasFound[prev]--, if hasFound[prev]<toFind[prev], then prev is needed, so count--.
For curr, after hasFound[curr]++, if hasFound[curr]<=toFind[curr], then curr is needed, so count++.

*/

using System;
using System.Collections.Generic;

public class Test
{
	public static int GetNumSubstr(string input, string pattern){
		int res = 0;
		int[] toFind = new int[256];
		int[] hasFound = new int[256];
		foreach(char c in pattern)
			toFind[c]++;
			
		int m = input.Length, n = pattern.Length;
		int count = 0;
		foreach(char c in input.Substring(0,n)){
			if(toFind[c]==0)
				continue;
			hasFound[c]++;
			if(hasFound[c]<=toFind[c])
				count++;
		}
		if(count==n)
			res++;
		for(int i=1;i<=m-n;i++){
			char prev = input[i-1]; //prev goes out of window
			char curr = input[i+n-1]; //curr goes into window
			if(toFind[prev]!=0){
				hasFound[prev]--;
				if(hasFound[prev] < toFind[prev])
					count--;
			}
			if(toFind[curr]!=0){
				hasFound[curr]++;
				if(hasFound[curr] <= toFind[curr])
					count++;
			}
			if(count==n)
				res++;
		}
		return res;
	}
	
	public static void Main()
	{
		string input = Console.ReadLine();
		string pattern = Console.ReadLine();
		Console.WriteLine(GetNumSubstr(input,pattern));
	}
}
