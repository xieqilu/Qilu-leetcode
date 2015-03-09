/**
 * Remove duplicate chars from a string. We only need to remove duplicate English Characters (A-Z).
 * We must do in-place removal, cannot construct a new string.
 * 
 * Example:
 * Input: ddccaabbb
 * Output: dcab
 * 
 * Note:
 * 1, the string is not sorted by alpha order.
 * 2, Since we only need to remove English Characters, we can use an bool array with length of 26.
 * If we need to remove ASCII charcters, we would use an int array with length of 256.
 * 
 * Solution1:  using constant extra memory space
 * Use an bool array with length of 26 to indicate if a specific English char has already exist in 
 * the string. Initially the array contains all false, if a char exist, turn the related element to true.
 * If an array has already existed, remove it. Note after removing an element, we must decrement i to make
 * sure every char in the string will be visited.
 * 
 * Time: O(n)
 * Space: O(1) Constant Memory Space
 * 
 * Solution2:
 * If we cannot use any extra memory space (including constant extra memory space), we need to use nested loop
 * to compare each char of the string with other chars and remove duplicate chars.
 * 
 * Time: O(n^2)
 * Space: O(1)
 * 
 * */


using System;

namespace RemoveDuplicateString
{
	class Solution{
		//Solution1
		public static string RemoveDup(string s){
			bool[] map = new bool[26]; //only remove duplicate English chars, if ASCII chars, use bool[256]
			for (int i = 0; i < map.Length; i++)
				map [i] = false;
			for (int i = 0; i < s.Length; i++) {
				if (s [i] <= 'z' && s [i] >= 'a') { //handle non-English chars in the string
					if (map [s [i] - 'a'] == false)
						map [s [i] - 'a'] = true;
					else {
						s = s.Remove (i, 1); //string.Remove(i,len), remove chars starting from index i and has the length of len
						i--;
					}
				}
			}
			return s;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (Solution.RemoveDup ("abbcd")); //abcd
			Console.WriteLine (Solution.RemoveDup ("ddccaabbb")); //dcab
			Console.WriteLine (Solution.RemoveDup ("   ")); //nothing
		}
	}
}
