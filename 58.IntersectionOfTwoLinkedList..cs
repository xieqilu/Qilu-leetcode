//Find Intersection of two singly Linked Lists
//
//Example: A; a1->a2->c1->c2->c3
//		   B: b1->b2->b3->c1->c2->c3
//The intersection would be node c1

//If no intersection, return null
//The LinkeLists must retain original structure after the fuction returns
//There are no cycle in two LinkedList
//Expect O(n) time and O(1) memory

/**
 * Three Methods:
 * 
 * private int getLength(ListNode head): 
 * get length of a linkedlist
 * 
 * private ListNode getIntersectionhelper(int d, ListNode1, ListNode2):
 * d is the difference of length of two linkedlists
 * ListNode1 is the head of longer linkedlist, ListNode2 is the head of
 * shorter LinkedList
 * 
 * public ListNode getIntersection(ListNode1, ListNode2)
 * first caculate the difference of length, then according to the difference,
 * call the helper method
 * */

using System;
using System.Collections.Generic;
using System.Collections;

namespace IntersectionTwoLinkedList
{
	//Definition of LinkedList Node class
	public class ListNode
	{
		public int val{ get; private set;}
		public ListNode next { get; set;}
		public ListNode(int x)
		{
			val = x;
			next = null;
		}
	}

	public class Finder
	{
		//up level public method
		public static ListNode getIntersection(ListNode head1, ListNode head2)
		{
			int l1 = getLength (head1);
			int l2 = getLength (head2);
			if (l1 > l2) {
				int d = l1 - l2;
				return getIntersectionHelper (d, head1, head2);
			} else {
				int d = l2 - l1;
				return getIntersectionHelper (d, head2, head1);
			}
				
		}

		//get length of a LinkedList
		private static int getLength(ListNode head)
		{
			int l = 0;
			while (head.next != null) {
				l++;
				head = head.next;
			}
			return l;
		}

		//get intersection using two Linkedlist and the length difference
		private static ListNode getIntersectionHelper(int d, ListNode head1, ListNode head2)
		{
			for (int i = 0; i < d; i++) {
				if (head1 == null)
					return null;
				head1 = head1.next;
			}

			while (head1 != null && head2 != null) {
				if (head1 == head2)
					return head1;
				head1 = head1.next;
				head2 = head2.next;
			}
			return null;
		}
	}

	class MainClass
	{

		public static void Main (string[] args)
		{
			ListNode node1 = new ListNode (1);
			ListNode node2 = new ListNode (2);
			ListNode node3 = new ListNode (3);
			ListNode node4 = new ListNode (4);
			ListNode node5 = new ListNode (5);

			ListNode node6 = new ListNode(8);
			ListNode node7 = new ListNode(9);
			ListNode node8 = new ListNode (10);

			node1.next = node2;
			node2.next = node3;
			node3.next = node4;
			node4.next = node5;

			node6.next = node7;
			node7.next = node8;
			node8.next = node2;

			ListNode intersection = Finder.getIntersection (node1, node6);

			while (node1 != null) {
				Console.Write (node1.val + "->");
				node1 = node1.next;
			}

			Console.WriteLine ();

			while (node6 != null) {
				Console.Write (node6.val + "->");
				node6 = node6.next;
			}
			Console.WriteLine ();
			Console.WriteLine(intersection.val);
		}
	}
}
