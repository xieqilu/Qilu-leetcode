/**
第二题，给一组String[](容量<10000)，求每一个String(长度<100)在其自己的
Permutation Sequence中的序号

Input: // String[] 
cab
babc

Output:  //返回 int[], index starting from 0
4        //{abc, acb, bac, bca, 【cab】, cba}
3        //{abbc, abcb, acbb, 【babc】,.....}

//注意，String内有重复的Character，但 Permutation Sequence 只保留distinct记录


Solution:
对于每一个字母, 找到在排序后的字符串中的位置
比如cab，源字符串排序abc
c -> 2 (remove c, source string becomes "ab")
a -> 0 (remove a, source string becomes "b")
b -> 0 (remove b)
所以在目标字符串的位置就是2*2! + 1*0! + 0*0! = 4

第二个有重复的例子，就选取最左边的位置（比如babc排序是abbc，第一次b出现的位
置为1）
1*3!/2! + 0*2! + 0*1! + 0*0!

general solution:
1, In each pass, get the first char c of the string.
2, Get the index of c in sorted char sequence of all chars in string, assume it's n.
3, Assume the number of c in string is k.
4, Assume the current length of string is l, then res+=n*(l-1)!/k!.
5, Get rid of all c in string without changing the relative position of other chars, then
repeat the above process.

Note: in each pass, l-1 is how many positions we can have other than the head position, 
and n is how many chars other than c can be put at the head.

If there are duplicate chars, then we also need to get the number of c in string, assumes it's k.
Then in step3, res+=n*(l-1)/k!

Time complexity: O(n^2logn)
*/

using System;
using System.Collections.Generic;
using System.Linq;
public class Test
{
	//Get original index of s in its permutations sequence
	public static int GetIndexPermutation(string s){
		int[] map = new int[256]; //map letter to occurence
		foreach(char c in s)
			map[c]++;
		char[] array = s.ToCharArray();
		int res = 0;
		while(array.Length>1){
			int l = array.Length-1; //get current length-1
			int k = map[array[0]]; //get occurence of current first char
			int n = GetOriginalIndex(array); //get original index
			res+=n*GetFactorial(l)/GetFactorial(k); //calculate
			array = array.Where(y=>y!=array[0]).ToArray(); //remove all array[0]
		}
		return res;
	}
	
	//Get original index of the first char in s
	private static int GetOriginalIndex(char[] a){ //O(nlogn)
		char target = a[0];
		char[] array = new char[a.Length];
		Array.Copy(a,0,array,0,a.Length); //copy a to array
		Array.Sort(array);
		//return the first occurence index of target in array
		return Array.IndexOf(array, target);
	}
	
	//Get n!
	private static int GetFactorial(int n){ //O(n)
		int res=1;
		for(int i=n;i>=1;i--)
			res*=i;
		return res;
	}
	
	public static void Main()
	{
		Console.WriteLine(GetIndexPermutation("ba"));
		Console.WriteLine(GetIndexPermutation("dabc"));
		Console.WriteLine(GetIndexPermutation("babc"));
	}
}
