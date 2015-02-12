/**
 * 1, Copy regular LinkedList
 * Solution:
 * Traverse the original list, and copy new node in each step
 * 
 * 2, Copy LinkedList with random pointer
 * A linked list is given such that each node contains an additional random pointer 
 * which could point to any node in the list or null.
* 
* Return a deep copy of the list.

* Three steps:
* 1, insert new node after each node in original list
* 2, copy the random pointer of each node to the new node after it
* 3, split current list to get the expected duplicate list
* */

using System;
using System.Collections;
using System.Collections.Generic;
namespace CopyListRandomPointer
{
	//ListNode class
	class ListNode
	{
		public int Value{ get; private set;}
		public ListNode Next{ get; set;}
		public ListNode Random{get;set;}

		public ListNode(int value)
		{
			this.Value = value;
			this.Next = null;
			this.Random = null;
		}
	}

	class Node{
		public int Value{ get; private set;}
		public Node Next{ get; set;}
		public Node(int value)
		{
			this.Value = value;
			this.Next = null;
		}
	}

	class MainClass
	{
		//Copy regular LinkedList 
		public static Node CopyRegular(Node head){
			if (head == null)
				return null;
			Node newHead = new Node (head.Value);
			Node current = head;
			Node newCurrent = newHead;
			while (current.Next != null) {
				Node newNext = new Node (current.Next.Value);
				newCurrent.Next = newNext;
				current = current.Next;
				newCurrent = newCurrent.Next;
			}
			return newHead;
		}

		//print regular LinkedList
		public static void PrintRegularList(Node head){
			Node temp = head;
			while (temp != null) {
				if (temp.Next != null)
					Console.Write (temp.Value + "->" + temp.Next.Value);
				Console.WriteLine (" ");
				temp = temp.Next; //do not forget this!
			}
		}

		//copy LinkedList with Random Pointer
		public static ListNode DeepCopy(ListNode head)
		{
			//empty list handle
			if (head == null)
				return null;

			//Insert new nodes to the List
			ListNode current = head;
			while (current != null) {
				ListNode temp = new ListNode (current.Value);
				temp.Next = current.Next;
				current.Next = temp;
				current = temp.Next;
			}

			//Copy the random pointer to new node
			current = head;
			while (current != null) {
				ListNode temp = current.Next;
				if(current.Random!=null)
					temp.Random = current.Random.Next;
				current = temp.Next;
			}

			//Split the List to get result
			current = head;
			ListNode newHead = current.Next;
			while (current != null) {
				ListNode temp = current.Next;
				current.Next = current.Next.Next;
				if (temp.Next != null)
					temp.Next = temp.Next.Next;
				current = current.Next;
			}
			return newHead;
		}

		//print result to see if the deep copy works
		public static void PrintList(ListNode head)
		{
			ListNode temp = head;
			while (temp != null) {
				if (temp.Next != null)
					Console.Write (temp.Value + "->" + temp.Next.Value + " " + temp.Value + "->" + temp.Random.Value);
				else
					Console.Write (temp.Value + "->" + temp.Random.Value);
				Console.WriteLine (" ");
				temp = temp.Next; //do not forget this!
			}
		}

		public static void Main (string[] args)
		{
			//construct a simple test Linked List
			ListNode[] testList = new ListNode[]{new ListNode(1),new ListNode(2),new ListNode(3),new ListNode(4)};
			for (int i = 0; i < testList.Length-1; i++) {


				testList [i].Next = testList [i + 1];
			}

			testList [0].Random = testList [2];
			testList [1].Random = testList [3];
			testList [2].Random = testList [0];
			testList [3].Random = testList [1];

			ListNode newList = DeepCopy (testList [0]);
			PrintList (testList [0]);
			Console.WriteLine ("------------------------------");
			PrintList (newList);

			Console.WriteLine ("----Test regular List-----");

			Node[] testList1 = new Node[]{new Node(1),new Node(2),new Node(3),new Node(4)};
			for (int i = 0; i < testList1.Length-1; i++) {


				testList1 [i].Next = testList1 [i + 1];
			}

			Node newHead = CopyRegular (testList1 [0]);
			PrintRegularList (testList1 [0]);
			Console.WriteLine ("------------------------------");
			PrintRegularList (newHead);

		}
	}
}
