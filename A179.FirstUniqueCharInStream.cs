/**
Write a program that identifies the first(or last) occurring unique object (or char)
in a stream of objects at any time in O(1) running time.


Solution:
This is a very good interview question. The method is very similiar to LRU Cache.
The implementation is simpler compared to LRU Cache.
In order to achieve O(1) time complexity, we need to use a Dictionary and a doubly LinkedList.

Dictionary(HashMap): Key is char, Value is Node that contains key as value.
Node: char value, Node prev, Node next

The idea is the current first unique char is always at the head of doubly LinkedList. And each
occuring char has an entry in dictionary, if the value is null, that means this char is already
duplicate and is not in the LinkedList. Otherwise, the value is the node in the LinkedList.

when we get a new char from the stream, check if the Dictionay already contains
the char as a key. If it does, and if the related value is not null, delete the node(value)
from the doubly LinkedList and set value as null. 
If the dictionary does not contains the char, create a new node with the char, add the new 
node to the end of doubly LinkedList. And add <char,node> to the dictionary.
And when we want to get current first unique occuring char, just return the value of head node.

The methods in the class is as follows:
void RemoveNode(Node): remove a node from the doubly LinkedList
void AddNode(Node): add a node to the end of the doubly LinkedList
void Add(char): add a new char to this object from the stream
char Get(): get the current first occurring unique char of the stream

Time complexity: O(1)  Space complexity: O(n)

Note: If we want to get the current last unique occuring char, just return the value of end node. 
All other parts of the code are excatly the same.
*/

using System;
using System.Collections.Generic;

public class Node{
	public char val{get;set;}
	public Node prev{get;set;}
	public Node next{get;set;}
	public Node(char v){
		this.val=v;
	}
}

public class Cache{
	private Dictionary<char,Node> dict;
	private Node head;
	private Node end;
	public Cache(){
		dict=new Dictionary<char,Node>();
	}
	//remove a node from LinkedList
	private void RemoveNode(Node node){
		Node prev = node.prev;
		Node post = node.next;
		if(prev==null) //node is the first node
			head = post;
		else
			prev.next = post;
		if(post==null) //node is the last node
			end = prev;
		else
			end.prev = prev;
	}
	//Add a node to the end of LinkedList
	private void AddNode(Node node){
		if(head==null){ //if List is empty
			head=node;
			end=node;
		}
		else{ //if List is not empty
			end.next = node;
			node.prev = end;
			end = node;
		}
	}
	//add/receive a char from the stream
	public void Add(char c){
		if(dict.ContainsKey(c)){
			if(dict[c]!=null){
				RemoveNode(dict[c]);
				dict[c]=null;
			}
		}
		else{
			Node node = new Node(c);
			AddNode(node);
			dict.Add(c,node);
		}
	}
	//get current first occurring char from stream
	public char Get(){
		return head.val;
		//if get last occurring char
		//return end.val;
	}
}

public class Test
{
	public static void Main()
	{
		Cache cache = new Cache();
		cache.Add('1');
		cache.Add('2');
		cache.Add('3');
		Console.WriteLine(cache.Get());//1
		cache.Add('2');
		Console.WriteLine(cache.Get());//1
		cache.Add('2');
		Console.WriteLine(cache.Get());//1
		cache.Add('1');
		Console.WriteLine(cache.Get());//3
		cache.Add('4');
		cache.Add('3');
		Console.WriteLine(cache.Get());//4
		cache.Add('6');
		Console.WriteLine(cache.Get());//4
		cache.Add('4');
		Console.WriteLine(cache.Get());//6
	}
}
