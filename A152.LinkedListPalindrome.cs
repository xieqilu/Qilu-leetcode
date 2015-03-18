/**
 * Given a singly linked list of characters, 
 * write a function that returns true if the given list is palindrome, else false.
 * 
 * Example:
 * 1->2->3->2->1 is a palindrome
 * 1->2->3 is not a palindrome
 * 
 * Assume null is a valid palindrome
 * 
 * Solution1: Using a Stack
 * A simple solution is to use a stack of list nodes. This mainly involves three steps.
1) Traverse the given list from head to tail and push every visited node to stack.
2) Traverse the list again. For every visited node, pop a node from stack and compare data of popped node with currently visited node.
3) If all nodes matched, then return true, else false.

Time complexity of above method is O(n), but it requires O(n) extra space. Solution2 solve this with constant extra space.

Time: O(n)   Space: O(n)
 * 
 * 
 * Solution2: Reversing the second half of the List
 * This method takes O(n) time and O(1) extra space.
1) Get the middle of the linked list.
2) Reverse the second half of the linked list.
3) Check if the first half and second half are identical.
If we are required to maintain the original Linked List structure:
4) Construct the original linked list by reversing the second half again and attaching it back to the first half

Note:
When number of nodes are even, the first and second half contain exactly half nodes. 
The challenging thing in this method is to handle the case when number of nodes are odd. 
We don’t want the middle node as part of any of the lists as we are going to compare them for equality. 
For odd case, we use a separate variable ‘midnode’ to store the middle node of the list.

Time: O(n)  Space: O(1)

 * */

using System;
using System.Collections.Generic;

namespace A152LinkedListPalindrome
{
	class ListNode{
		public int val{get;set;}
		public ListNode next{get;set;}
		public ListNode(int v){
			this.val = v;
		}
	}

	class Solution{
		public bool CheckPalindrome(ListNode head){ //Time: O(n)  Space: O(n)
			if (head == null) //handle edge case
				return true;
			Stack<ListNode> stack = new Stack<ListNode> ();
			ListNode tempHead = head;
			while (tempHead != null) { //traverse list and push each node into stack
				stack.Push (tempHead);
				tempHead = tempHead.next;
			}
			//traverse list again and compare each node with the node poped from stack
			tempHead = head;
			while (tempHead != null) {
				if (tempHead.val != stack.Pop ().val)
					return false;
				tempHead = tempHead.next;
			}
			return true;
		}

		public bool CheckPalinBetter(ListNode head){
			if (head == null || head.next==null) //edge case
				return true;
			ListNode fast = head, slow = head;  //used to find the middle node of list
			ListNode prevSlow = null; //used to keep track of the previous node of slow pointer
			ListNode midNode = null; //used to store the middle node when number of nodes is odd
			bool res = true; //store result, we must return after constructing the original list

			//get the middle node of list
			while (fast != null && fast.next != null) {
				fast = fast.next.next;
				prevSlow = slow;
				slow = slow.next;
			}

			if (fast != null) { //number of nodes is odd
				midNode = slow; //store middle node to later construct original list
				slow = slow.next; //skip the middle node
			}
			ListNode secondHalfHead = ReverseList (slow); //reverse second half of list
			prevSlow.next = null; //terminate first half of list, that's why we need prevSlow
			ListNode firstHalf = head;
			ListNode secondHalf = secondHalfHead;

			//compare firsthalf and secondhalf
			while (firstHalf != null && secondHalf != null) {
				if (firstHalf.val != secondHalf.val) {
					res = false;
					break;
				}
				firstHalf = firstHalf.next;
				secondHalf = secondHalf.next;
			}

			//construct the original list
			secondHalf = ReverseList (secondHalfHead); //reverse second half again
			if (midNode != null) { //if number of nodes is odd, insert midNode between prevSlow and secondHalf
				prevSlow.next = midNode;
				midNode = secondHalf;

			} else  //if number of nodes is even, directly connect prevSlow to secondHalf
				prevSlow.next = secondHalf;
			return res;
		}

		//reverse a LinkedList in place
		private ListNode ReverseList(ListNode head){
			ListNode prev = null;
			ListNode curr = head;
			while (curr != null) {
				ListNode temp = curr.next;
				curr.next = prev;
				prev = curr;
				curr = temp;
			}
			return prev; //after the while loop, curr must be null, so return prev
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			//test case 1: true
			ListNode node1 = new ListNode (1);
			ListNode node2 = new ListNode (2);
			ListNode node3 = new ListNode (3);
			ListNode node4 = new ListNode (2);
			ListNode node5 = new ListNode (1);
			node1.next = node2;
			node2.next = node3;
			node3.next = node4;
			node4.next = node5;

			//test case 2: false
			ListNode node11 = new ListNode (1);
			ListNode node12 = new ListNode (1);
			ListNode node13 = new ListNode (3);
			node11.next = node12;
			node12.next = node13;

			Console.WriteLine (new Solution ().CheckPalindrome (node1)); //true
			Console.WriteLine (new Solution ().CheckPalindrome (node11)); //false
			Console.WriteLine (new Solution ().CheckPalindrome (null)); //true

			Console.WriteLine (new Solution ().CheckPalinBetter (node1)); //true
			Console.WriteLine (new Solution ().CheckPalinBetter(node11)); //false
			Console.WriteLine (new Solution ().CheckPalinBetter (null)); //true
			Console.WriteLine (" ");
			//test if constructing the original list successfully
			while (node1 != null) {
				Console.Write (node1.val + "->");
				node1 = node1.next;
			}

		}
	}
}
