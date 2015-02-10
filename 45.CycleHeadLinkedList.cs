//Given a singly Linked List
//If there is a cycle in the Linked List, return the head of the cycle
//If there is no cycle in the Linked List, return null


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
		//classic linked list approach: use two pointers, one slow, one fast!
		//After finding the cycle, move slow pointer to the head of LinkedList
		//Then move the two pointers one step further at each time, 
		//when they meet again, the meeting point is the head node of cycle
		public static Node FindLoop(Node head)
		{
			Node slow = head;
			Node fast = head;
			while (slow != null && fast != null && fast.next != null) {
				slow = slow.next;
				fast = fast.next.next;
				if (slow == fast)  //if two pointers meet, there is a loop
					break;
			}
			
			//two cases: fast is now null or fast is at the last node of list
			//so we need to check both fast and fast.next
			//if either fast or fast.next is null, we know there is no cycle
			//cannot check fast.next first, because if fast is now null, there
			//gonna be nullpointer exception
			if (fast == null || fast.next == null)
				return null;

			slow = head;
			while (slow != fast) {
				slow = slow.next;
				fast = fast.next;
			}
			return slow;
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
			node6.next = node4;

			Console.WriteLine (Finder.FindLoop (node1).value);
		}
	}
}
