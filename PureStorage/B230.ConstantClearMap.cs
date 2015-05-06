/**
设计一个Map<Integer, Integer>，满足下面的复杂度:
add: O(1)  deletion: O(1)  lookup: O(1)  clear:O(1)  iterate: O(number of elements)。


Solution:
By using a dictionary, we can meet all the above requirement except for the clear operation.
The clear operation requires us to clear all content in the map in O(1) time. The only way to do
this is to use a timestamp and mark each key/value pair. When calling clear(), increment the 
timestamp. So if we look up the map after clearing it, the older key/value pair would not be considered
exist. 

Details:
1, Map contains a dictionary<int, node> and int currVersion.
2, Node contains int value and int version.
3, Add: if the key is not in dict, create new node with currVersion and value and insert <key, node>.
If the key is in the dict but its version is older than currVersion, remove the existing pair then add
new pair. If the key is in the dict and its version is same as currVersion, throw exception.
4, Delete: if the key is not in the dict, return false. If the key is in the dict but its version is
older than currVersion, return false. Otherwise, remove the pair.
5, GetValue: Same as Delete.
6, Clear: currVersion++. Thus all existing key/node pair become invalid. Time: O(1)
*/


using System;
using System.Collections.Generic;

public class Node{
	public int value{get;set;}
	public int version{get;set;} //time stamp
	public Node(int va, int ve){
		value = va;
		version = ve;
	}
}

public class MyMap{
	private Dictionary<int,Node> dict;
	private int currVersion;
	public MyMap(){
		dict = new Dictionary<int,Node>();
		currVersion = 0;
	}
	
	//add key value pair into map, note if there is a same key with older version
	//first delete older key, then add the new key value pair
	public void Add(int key, int value){
		if(dict.ContainsKey(key)){
			if(dict[key].version < currVersion)
				dict.Remove(key);
			else
				throw new ArgumentException("duplicate key!");
		}
		//if ther is no same key or there is a same key with older version,
		//we always need to add the key to dict
		Node temp = new Node(value,currVersion);
		dict.Add(key,temp);
	}
	
	//if delete successfully, return true, otherwise, return false
	public bool Delete(int key){
		if(!dict.ContainsKey(key))
			return false;
		if(dict[key].version < currVersion)
			return false;
		dict.Remove(key);
		return true;
	}
	
	//get value using key
	public int GetValue(int key){
		if(!dict.ContainsKey(key))
			throw new ArgumentException("key doesn't exist!");
		if(dict[key].version < currVersion)
			throw new ArgumentException("key doesn't exist!");
		return dict[key].value;
	}
	
	//clear the whole map
	public void Clear(){
		currVersion++;
	}
}

public class Test
{
	public static void Main()
	{
		MyMap map = new MyMap();
		map.Add(-1,1);
		map.Add(-2,2);
		map.Add(-3,3);
		Console.WriteLine(map.GetValue(-1)); //1
		Console.WriteLine(map.GetValue(-2)); //2
		Console.WriteLine(map.Delete(-3)); //true
		map.Clear();
		Console.WriteLine(map.Delete(-2)); //false
		map.Add(-1,10);
		Console.WriteLine(map.GetValue(-1)); //10
	}
}
