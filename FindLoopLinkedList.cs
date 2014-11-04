//Given a singly Linked List
//Find if there is a loop existing in the Linked List



using System;
using System.Collections;

namespace FindLoopLinkedList
{
	class Node  //simple Node class
	{
		public int value{ get; private set;}
		public Node next{ get; set;}

		public Node(int value)
		{
			this.value = value;
			this.next = null;
		}
	}

	class Finder
	{
		//classic linked list approach:
		//use two pointers, one slow, one fast!
		public static bool FindLoop(Node head)
		{
			Node slow = head;
			Node fast = head;
			while (slow != null && fast != null && fast.next != null) {
				slow = slow.next;
				fast = fast.next.next;
				if (slow == fast)  //if two pointers meet, there is a loop
					return true;
			}
			return false;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Node node1 = new Node (1);
			Node node2 = new Node (2);
			Node node3 = new Node (3);
			Node node4 = new Node (4);
			Node node5 = new Node (5);
			Node node6 = new Node (6);

			node1.next = node2;
			node2.next = node3;
			node3.next = node4;
			node4.next = node5;
			node5.next = node6;
			node6.next = node1;

			Console.WriteLine (Finder.FindLoop (node1));
		}
	}
}
