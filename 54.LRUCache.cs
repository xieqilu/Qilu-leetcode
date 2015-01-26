//Design and Implement a data structure for
//Least Recently Used (LRU) Cache.
//Support two operations as follows:

//Get(key): get the value of the key if the key
//exists in the cache, otherwise return -1

//Set(key, value): set the new value to the specific key
//if the key doesn't exist, insert the new (key, value)
//to the cache, if the cache is full of capacity, remove
//the least recently used item before inserting new item.

//Solution:
//use combination of hashtable and list to store the key value pair
//hashtable<entry.key, index of entry in list>
//List<entry>, head of list: least recently used element; end of list: most recently used element


using System;
using System.Collections.Generic;
using System.Collections;

namespace LRUCache
{
	class CacheEntry
	{
		public int Value{ get; set;}
		public int Key { get; private set;}
		public CacheEntry(int key, int value)
		{
			this.Key = key;
			this.Value = value;
		}
	}

	class LRUCache
	{
		private Dictionary<int,int> dic = new Dictionary<int, int> ();
		private List<CacheEntry> list = new List<CacheEntry> ();
		private int capaciity;

		public LRUCache(int capacity)
		{
			this.capaciity = capacity;
		}

		//move cacheEntry to the end of the list
		private void MoveToHead(int key)
		{
			CacheEntry temp = this.list [this.dic [key]];
			this.list.RemoveAt (this.dic [key]);
			this.list.Add (temp);  //add temp to the end of list
			this.dic [key] = this.list.Count - 1;
		}

		public int Get(int key)
		{
			if (!this.dic.ContainsKey (key)) //if key doesn't exist
				return -1;
			MoveToHead (key);
			return this.list [this.dic [key]].Value;
		}

		public void Set(int key, int value)
		{
			if (!this.dic.ContainsKey (key)) {
				CacheEntry temp = new CacheEntry (key, value);
				if (this.list.Count >= capaciity) {
					//Remove the head element of list
					this.dic.Remove (this.list [0].Key);
					this.list.RemoveAt (0);
				}
				//add the new cacheEntry to the end of list
				this.list.Add (temp);
				this.dic.Add (key, this.list.Count - 1);
			} else {
				this.list [this.dic [key]].Value = value;
				MoveToHead (key);
			}
		}

		//print to test the result
		public void Print()
		{
			foreach (CacheEntry c in list) {
				Console.WriteLine (c.Key + "," + c.Value);
			}
		}
			
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
			//test cases, all successful!
			LRUCache cache = new LRUCache (4);
			cache.Set (1, 11);
			cache.Set (2, 22);
			cache.Set (3, 33);
			cache.Set (4, 44);
			Console.WriteLine(cache.Get (0));
			Console.WriteLine (cache.Get (3));

			cache.Set (5, 55);

			cache.Print ();
		}
	}
}
