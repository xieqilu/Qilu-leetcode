/**
 * Given a singly linked list L: L0→L1→…→Ln-1→Ln,
reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→…

You must do this in-place without altering the nodes' values.

For example,
Given {1,2,3,4}, reorder it to {1,4,2,3}.
**/

/**
* Definition for singly-linked list.
* class ListNode {
*     int val;
*     ListNode next;
*     ListNode(int x) {
*         val = x;
*         next = null;
*     }
* }
*/

/**
Solution:
For this problem, we cannot create a new list, but need to
do "in-place" operations. We can only change their pointers,
not creating a new list.

1 Split the list into two parts (use fast and slow pointers)
If list contains odd number of nodes, the first part will
contains 1 more node than the second. If list contains even
number of nodes, the two parts will contain equal nodes

2, Reverse the second list.

3, Merge the two lists together one node by one node

**/


using System;

namespace ReorderList
{
	class ListNode{
		public int val{get;set;}
		public ListNode next{ get; set;}
		public ListNode(int v){
			this.val = v;
			this.next = null;
		}
	}

	class Finder{

		private static ListNode ReverseList(ListNode head){ //reverse the list 
			if (head == null || head.next == null) //handle edge case
				return head;

			ListNode current = head;
			ListNode next = head.next;
			while (next != null) {
				ListNode temp = next.next;
				next.next = current;
				current = next;
				next = temp;
			}
			head.next = null; //set original head.next to null
			return current;

		}

		public static void ReorderList(ListNode head){
			if (head == null || head.next == null) //handle edge case
				return;

			//split the list use fast and slow pointers
			ListNode fast = head;
			ListNode slow = head;
			while (fast.next != null && fast.next.next != null) {
				fast = fast.next.next;
				slow = slow.next;
			}
			ListNode second = slow.next;
			slow.next = null; //final step for splitting list, cut two lists off

			//reverse second list
			second = ReverseList (second);

			ListNode first = head;
			while (first != null && second != null) {
				ListNode temp1 = first.next;
				ListNode temp2 = second.next;
				second.next = first.next;
				first.next = second;
				first = temp1;
				second = temp2;
			}
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			//Java version of this code has already been tested by
			//Leetcode test cases!
			Console.WriteLine ("Hello World!");
		}
	}
}
