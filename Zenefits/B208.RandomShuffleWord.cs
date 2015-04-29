/**
Shuffle all words in a string sentence

有一个String输入，其实是一个sentence, 例如“I want to buy a cup of water” 
输出为 “I wnat to buy a cup of wtear”

意思是对于句子中的每个单词，例如water, 最边上两个char不能变，内部的char要随机排列重组，
也就是说需要写一个random word combination的函数，public String helper(String s), 
输出随机排列出来的word.


Solution:
Use Random class to shuffle all words in the string.
Convert each word in the string into a char array, then shuffle each char array.
*/


using System;

public class Test
{
	public static void Shuffle(char[] word){
		Random rng = new Random();
		int n = word.Length-1;
		while(n>1){
			n--;
			int k = rng.Next(1,n+1); //k is a random number such 0<k<n+1
			char temp = word[k];
			word[k] = word[n];
			word[n] = temp;
		}
	}
	
	public static void Main()
	{
		string[] words = Console.ReadLine().Split();
		foreach(string s in words){
			char[] word = s.ToCharArray();
			Shuffle(word);
			string res = new string(word);
			Console.Write(res + " ");
		}
	}
}
