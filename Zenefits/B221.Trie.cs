/**
This is an implementation of a C# trie. It is a tree structure representing words.
Each node in the tree represents a single character, as shown below;
Trie with the words car, cat and dog added.
               root
              /    \
             c      d
            /         \
           a           o
          /  \          \
         r    t          g
The trie can be searched by prefix, returning a list of words which begin with the prefix. And 
we can add word to the trie, also we can check if a word exist in the trie.

The advantage of using a trie:
1, The trie is also called prefix tree. It can add and search for a word in O(L) time, where L is
the length of the target word.

2, HashSet or HashTable can only be used to find if the given word exist in it. But using trie we
can find all words that share the given prefix in O(h) time, where h is the height of the tree. 
For example, if given app, we can find all words that has app as prefix, like apple, appl, applee,etc.
In other words, if a trie contains n words, we can find all words sharing a given prefix in O(log(26)n).

Classes and Methods:
There are two classes, 
Trie and TrieNode.

Trie class:
Field: 
TrieNode root: root of this Trie structure

Method:
void AddWord(string word): add a word to the trie
List<string> GetWords(string prefix): get a list of words in the trie with a given prefix
bool CheckWord(string word): check if a word exists in the Trie. Check if the given word can be
			matched excately by a word in the Trie.
int CountWords(string prefix): get number of words in the trie that share the given prefix
							
							
TrieNode class:
Field: 
TrieNode parent: the parent of current TrieNode
TrieNode[] children: current children of current TrieNode
bool IsLeaf: indicate if any children exist
bool IsWord: indicate if current TrieNode is the last char of a word
char val: the char that current TrieNode represents

Constructor:
TrieNode(): construct top root TrieNode
TrieNode(char val): construct a child node represents val

Method:
void AddWord(string word): add a word to this node
TrieNode GetChildNode(char c): return the child node representing the given char
List<string> GetWords(): return a list of words which are lower than this node
string ToWord(): get the word that ends at this node using parent field
bool CheckWord(string word): check if there is a word ends at current node
*/

using System;
using System.Collections.Generic;

public class Trie
{
	private TrieNode root;
	
	//constructor
	public Trie(){
		root = new TrieNode();
	}
	
	//Add a word to the Trie
	public void AddWord(string word){
		root.AddWord(word.ToLower());
	}
	
	//Get the words in the trie with the given prefix
	public List<string> GetWords(string prefix){
		TrieNode lastNode = root;
		List<string> res = new List<string>();
		foreach(char c in prefix){
			//try to get child node level by level
			lastNode = lastNode.GetChildNode(c);
			//if any level returns null, means this prefix doesn't exist in trie
			if(lastNode==null)
				return res;
		}
		lastNode.GetWords(res); //get lower words of last char in prefix
		return res;
	}
	
	//check if the given word exist in this trie
	public bool CheckWord(string word){
		TrieNode lastNode = root;
		foreach(char c in word){
			lastNode = lastNode.GetChildNode(c);
			if(lastNode == null)
				return false;
		}
		return lastNode.CheckWord();
	}
	
	//get number of words in trie that share the given prefix
	public int CountPrefix(string prefix){
		TrieNode lastNode = root;
		foreach(char c in prefix){
			lastNode = lastNode.GetChildNode(c);
			if(lastNode == null)
				return 0;
		}
		List<string> res = new List<string>();
		lastNode.GetWords(res);
		return res.Count;
	}
}

public class TrieNode
{
	private TrieNode parent;
	private TrieNode[] children;
	private bool IsLeaf;
	private bool IsWord;
	private char val;
	
	//Constructor for root TrieNode
	public TrieNode(){
		children = new TrieNode[26];
		IsLeaf = true;
		IsWord = false;
	}
	
	//Constructor for child TrieNode
	public TrieNode(char val){
		children = new TrieNode[26];
		IsLeaf = true;
		IsWord = false;
		this.val = val;
	}
	
	//Add a word to this node. This method will be called recursivelly
	public void AddWord(string word){
		IsLeaf = false;
		int charPos = word[0]-'a';
		if(children[charPos]==null){ //if this char is not added yet
			children[charPos] = new TrieNode(word[0]);
			//the private field of this class can be accessed by another instance of the same class
			children[charPos].parent = this;
		}
		if(word.Length>1)
			children[charPos].AddWord(word.Substring(1));
		else
			children[charPos].IsWord = true;
	}
	
	//get the child node containing the given char
	public TrieNode GetChildNode(char c){
		return children[c-'a'];
	}
	
	//add all words which are lower than current node to res list
	public void GetWords(List<string> res){
		if(IsWord)//if current node is the end of a word, add the word
			res.Add(this.ToWord());
		if(!IsLeaf){
			foreach(TrieNode t in children){
				if(t!=null)
					t.GetWords(res); //add all words from children's list
			}
		}
	}
	
	//Get the word that ends at the current node
	private string ToWord(){
		if(parent==null)
			return "";
		return parent.ToWord()+val.ToString();
	}
	
	//check if there is a word ends at current node
	public bool CheckWord(){
		return this.IsWord;
	}
}

public class Test
{
	public static void Main()
	{
		string[] words = new string[]{"app","apple","appl", "brown", "brony", "michael",
							"michtell", "mike", "brow","manny", "mann", "scott", "xie", "stokton"};
		Trie dict = new Trie();
		foreach(string s in words)
			dict.AddWord(s);
		List<string> l1 = dict.GetWords("s");
		foreach(string s in l1)
			Console.WriteLine(s);
		Console.WriteLine(dict.CheckWord("xi"));
		Console.WriteLine(dict.CountPrefix("ap"));
	}
}
