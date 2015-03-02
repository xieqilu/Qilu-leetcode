/*
 * Reverse a LinkedList
 * 
 * 
 * Solution:
 * This is a very basic problem. We can iterate the Linked List
 * use two pointers: prev and curr.
 * Initially set prev as null, and curr as head
 * Then for each step:
 * ListNode temp = curr.next;
 * curr.next = prev;
 * prev = curr;
 * curr = temp;
 * 
 * */

using System;

namespace ReverseLinkedList
{
	public class ListNode {
		public int val{ get; set;}
		public ListNode next{ get; set;}
		public ListNode(int v){
			this.val = v;
			this.next = null;
		}
	}

	public class Solution{
		//Reverse LinkedList
		public static ListNode ReverseList(ListNode head){
			if(head==null) return null;
			ListNode prev = null;
			ListNode curr = head;
			ListNode next;
			while (curr != null) {
				next = curr.next;
				curr.next = prev;
				prev = curr;
				curr = next;
			}
			return prev; //after the while loop, curr must be null, so return prev!
		}

		//Print a LinkedList to check the result
		public static void PrintList(ListNode head){
			Console.WriteLine(" ");
			while(head!=null){
				Console.Write (head.val + "->");
				head = head.next;
			}
		}

	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			ListNode l1 = new ListNode (1);
			ListNode l2 = new ListNode (2);
			ListNode l3 = new ListNode (3);
			ListNode l4 = new ListNode (4);
			ListNode l5 = new ListNode (5);
			l1.next = l2;
			l2.next = l3;
			l3.next = l4;
			l4.next = l5;
			Solution.PrintList (l1);
			Solution.PrintList (Solution.ReverseList (l1));

		}
	}
}
