
//Follow Up: how to solve this problem if a temporary buffer is not allowed?
//
//	2.1 fastest solution
//
//In general, we scan all elements in the LinkedList one by one and put them into a hash table. Each time we look up the hash table checking if the node
//	already exist in the hash table. If it’s already exist, we remove the node; if it’s not exist, we add the node to the hash table. In C#, we use Dictionary
//	which is actually a hash table with explicit value type. For each node, we put the node into hash table as the key, and use true as the value. 
//	Note: the reason we use hash table instead of a list is hash table has O(1) look up time, but list needs O(n) time to look up. 
//
//	2.2 solution without a temporary buffer
//
//	In this case we cannot use a hash table. So we user two pointers. As the first pointer stays at a node, the second pointer iterate through the next node of the 
//first pointer to the end of Linkedlist. Then each time we compare the values of the two pointers, if the value is the same, we simply remove the node of the 
//	second pointer. Then we update the first pointer to its next node, and repeat the previous process. When the first pointer iterate to the last node, the process
//	is done.
//	Note: in C# LinkedList.remove(node) automatically let node.previous.next point to node.next.


using System;
using System.Collections;
using System.Collections.Generic;

namespace Linkedlist
{
	public class ListHandler
	{
		public void deleteDups(LinkedListNode<int> n) //O(n), if we use List instead of Dictionary/Hashtable, it will be O(n^2)
		{
			LinkedList<int> ll = n.List; //get the LinkedList contains n
			LinkedListNode<int> tmp = new LinkedListNode<int> (1);
			Dictionary<int, bool> dt = new Dictionary<int,bool> ();
			while (n != null) {
				if (dt.ContainsKey (n.Value)) {
					tmp = n.Next;//store n.next
					ll.Remove (n); //remove duplicate
					n = tmp;//update n to prestored n.next
				}
				else {
					dt.Add (n.Value, true);
					n = n.Next;
				}
		
			}
		}

		public void deleteDupsNoBuffer(LinkedListNode<int> head) //O(n^2), but O(1) space since no extra buffer
		{
			var ll = head.List; //get the LinkedList contains head
			if (head == null)
				return;

			while (head != null) {
				var runner = head;
				while (runner.Next != null) {
					if (runner.Next.Value == head.Value) {
						ll.Remove (runner.Next); //automatically update runner.next to runner.next.next
					} else
						runner = runner.Next;
				}
				head = head.Next;
			}
		}

	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			var testList = new LinkedList<int> ();
			testList.AddLast (1);
			testList.AddLast (2);
			testList.AddLast (2);
			testList.AddLast (3);
			testList.AddLast (3);
			testList.AddLast (3);
			testList.AddLast (4);
			testList.AddLast (1);
			testList.AddLast (4);

			var listhandler = new ListHandler ();
			//listhandler.deleteDups (testList.First);
			listhandler.deleteDupsNoBuffer (testList.First);
			foreach (int element in testList) {
				Console.WriteLine (element);
			}
				
				
		}
	}
}
