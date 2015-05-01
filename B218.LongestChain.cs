/**
longest chain
类似word ladder，对于一个单词删掉任何一个字母，如果新单词出现在给的词典里 
那么就形成一个 chain： old word -> new word -> newer word, 求最长长度(return int) 
比如给vector<string> w = {a,ba,bca,bda,bdca} 最长是4： bdca->bda->ba->a;


Idea:
This problem is very similiar to Word Ladder, the methof is almost the same. We also use can view 
this problem as a tree problem and each word in the input string array can be the root. Starting
from each root, we perform the BFS Level Order traverse, remove each char from root to check all
possible children for next level. And whenver we hit a string that only has one char, we find the 
longest chain and return depth. If we never hit a string that only has one char, then we will search
to the deepest level as we can, and return the largest depth.

Solution:
Differences from the solution for Word Ladder:
1, we need to construct a dictionary for all words in input string array to enable quick look-up.
2, each word in the input array can be the root, so we need to traverse the array and try each word
as the root.
3, Use variable res to save current longest length. If a word in the array is shorter than or equal
to res, no need to try BFS on it, because from this word we cannot find a longer length. Or we the
length of the word is 1, dont't do BFS, too.
4, In the Bfs method, we don't need to use the HashSet visited to store all visited words. Because
in this problem the length of a child word must be shorted than its parent, so a child will never
point reversely to its parent, thus we don't need to worry about a cycle. So this problem is excately
a tree problem in which only parent can points to child. The word ladder problem is more like a 
graph problem in which two nodes can point to each other.
5, There are two situations in the Bfs method to return depth:
5.1, we hit a child that has only one char, then we immidieatly return depth. Because the child belongs
to the next level, so return depth+1.
5.2, we got no valid child at a level thus the search is terminated, then we must return depth-1 
because we terminate the search at the current empty level, so the chain actually ends at the last 
level.


Time complexity: O(n^2)  n is the number of words in input array
Use each word as the root, in each pass, we will at most search for all n words, so O(n^2)

Space: O(n)  Each search we will at most store all words in the queue

另外一种解法：
思路: 建一个map<长度，set<string>> 根据长度把输入的字典放到set里，然后从最长的长度所在的map[长度] 
开始枚举每个单词并缩减然后进行recursive call， 比如bdca 那么就可能缩成dca,bca,bda 然后去map[3]里找，
类推直到 word.size()==1 或找不到， 放个全局int去记最大长度。
注意找到后从字典里删除和word ladder一样 否则只能过4个case 会超时。
*/



using System;
using System.Collections.Generic;
using System.Text;

public class Test
{
	public static int FindLongestChain(string[] words){
		int len = words.Length;
		HashSet<string> dict = new HashSet<string>();
		foreach(string s in words)
			dict.Add(s);
		int res = 0;
		foreach(string s in words){
			 //if the length of s is less or equal to res, 
			 //then it's not possible to find a longer res starting from s
			if(s.Length<=res || s.Length==1)
				continue;
			res = Math.Max(res,Bfs(s, dict));
		}
		return res;
	}
	
	//Find the length of longest chain starting from s
	private static int Bfs(string s, HashSet<string> dict){
		Queue<string> q = new Queue<string>();
		int current = 1, next = 0;
		int depth = 1; //If no chain, the length is 1
		q.Enqueue(s);
		while(current!=0){
			string currWord = q.Dequeue();
			current--;
			for(int i=0;i<currWord.Length;i++){
				StringBuilder sb = new StringBuilder(currWord);
				sb.Remove(i,1);
				string temp = sb.ToString();
				if(dict.Contains(temp)){
					if(temp.Length==1){ 
						return depth+1; //the chain ends at next level, so depth++
					}
					q.Enqueue(temp);
					next++;
				}
			}
			if(current==0){
				current = next;
				next = 0;
				depth++;
			}
		}
		//if no return inside while loop, chain ends at last level, so return depth-1.
		return depth-1; 
	}
	
	public static void Main()
	{
		string[] words = Console.ReadLine().Split();
		Console.WriteLine(FindLongestChain(words));
	}
}
