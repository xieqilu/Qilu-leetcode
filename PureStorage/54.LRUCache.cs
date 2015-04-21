//Design and Implement a data structure for
//Least Recently Used (LRU) Cache.
//Support two operations as follows:

//Get(key): get the value of the key if the key
//exists in the cache, otherwise return -1

//Set(key, value): set the new value to the specific key
//if the key doesn't exist, insert the new (key, value)
//to the cache, if the cache is full of capacity, remove
//the least rechetly used item before inserting new item.

//both of Get and Set operation should be done in O(1) time(constant time)

/**
 * Solution:
 * For this problem, in order to achieve constant time operation,
 * we cannot use hashMap and list. Because if we use them, when we
 * move a key/value to the head of the list, we need to update all
 * other key/value pair's index in the hashmap, then it's O(n)
 * 
 * Instead, in order to achieve quick move/insert element, we need
 * to use a Doubly Linked List and HashMap.
 * 
 * Why we need a Doubly Linked List instead of a singly Linked List?
 * Because if the capacity is full, we need to move the end Node of 
 * the list, then set the end pointer to the new end, this requires
 * us to get the node before the end Node. So we need a pre Pointer in
 * each node.
 * 
 * In detail:
 * HashMap<Key,Node>
 * Node:
 * next, pre, value,key
 * int capacity, keep track of capacity
 * int len, keep track of the number of current nodes
 * 
 * Method:
 * RemoveNode(Node): remove a Node from the Doubly Linked List
 * SetHead(Node): Set a New Node to the head of the Doubly Linked List
 * Get(key)
 * Set(Key)
 * 
 * Note: SetHead method should always be used after RemoveHead method
*/

using System;
using System.Collections.Generic;
using System.Collections;

namespace LRUCache
{
	class Node{
		public int value{ get; set;}
		public int key{ get; set;}
		public Node pre{get;set;}
		public Node next{ get; set;}
		public Node(int v,int k){
			this.value = v;
			this.key = k;
		}
	}

	class LRUCache
	{
		private Dictionary<int,Node> dic = new Dictionary<int, Node> ();
		private Node head;
		private Node end;
		private int capacity;
		private int len;

		public LRUCache(int capacity)
		{
			this.capacity = capacity;
			this.len = 0;
		}

		//remove a node from LinkedList
		private void removeNode(Node node){
			Node curr = node;
			Node pre = curr.pre;
			Node post = curr.next;
			if (pre != null)
				pre.next = post;
			else
				head = post;

			if (post != null)
				post.pre = pre;
			else
				end = pre;
		}

		//set a new node to the head of LinkedList
		private void setHead(Node node){
			node.next = head;
			node.pre = null;
			if (head != null)
				head.pre = node;
			head = node;
			if (end == null) //if this node is the first of list
				end = node;

		}

		//get value from LRU Cache
		public int Get(int key)
		{
			if (dic.ContainsKey (key)) {
				Node curr = dic [key];
				int value = curr.value;
				removeNode (curr);
				setHead (curr);
				return value;
			} else
				return -1;
		}

		//set key/value pair
		public void Set(int key, int value)
		{
			if (dic.ContainsKey (key)) {
				Node curr = dic [key];
				curr.value = value;
				removeNode (curr);
				setHead (curr);
			} else {
				Node newNode = new Node (value,key);
				if (len == capacity) {
					Node last = end;
					removeNode (last);
					dic.Remove (last.key);
					dic.Add (key, newNode);
					setHead (newNode);
				} else {
					dic.Add (key, newNode);
					setHead (newNode);
					len++;
				}
			}
		}
			
		public void Print()
		{
			Node curr = head;
			while (curr != null) {
				Console.WriteLine (curr.key + " " + curr.value);
				curr = curr.next;
			}
		}

		public void PrintMostRecentUsed(){
			Node curr = head;
			Console.WriteLine (curr.key + " " + curr.value);
		}

	}

	class MainClass
	{
		public static void Main (string[] args)
		{

			LRUCache cache = new LRUCache (4);
			cache.Set (1, 11);
			cache.Set (2, 22);
			cache.Set (3, 33);
			cache.Set (4, 44);
			cache.Print ();
			Console.WriteLine (" ");
			Console.WriteLine(cache.Get (0));
			Console.WriteLine (cache.Get (1));
			cache.PrintMostRecentUsed (); 
			Console.WriteLine (cache.Get (4));
			cache.PrintMostRecentUsed ();
			cache.Set (5, 55);


			cache.Print ();

		}
	}
}

