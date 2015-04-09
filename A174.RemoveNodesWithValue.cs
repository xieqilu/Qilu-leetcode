/**
Given a LinkedList of integers and an integer value, delete every node of the 
LinkedList containing this value.

Example:
1->2->5->5->3 remove 5
result: 1->2->3

Solution:
This is a very basic LinkedList question but not easy to implement with any bugs.
We need to pay attention to some edge cases. Suppose the value to remove is num.

Edge case:
1, head is null, return null
2, all nodes have the value of num, return null
3, the first n nodes have the value of num, update head to the (n+1)th node

We can combine edge case#2 and edge case#3 together.

Steps:
1, check edge case#1 
2, try to remove all consecutive nodes having num at the beginning of the list.
And update the newHead to the first node other than num.
3, check if newHead is null, if it is, return it. Otherwise, continue to next step.
4, Use a pointer p to traverse the rest nodes, intially p = newHead. In each pass,
check if p.next is num, if it is, remove p.next and Do Not Update p. This is very
important, because after delete originally p.next, the new p.next could also be num.
If p.next is not num, update p to p.next and continue the loop.
The condition of above loop is while(p.next!=null).

Time: O(n)  Space: O(1)
*/

using System;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
 }

public class Solution{
	//remove all nodes that have the value of num
	public static ListNode removeNodes(ListNode head, int num){
		if(head==null) return null;
		ListNode newHead = head;
		while(newHead!=null&&newHead.val==num)
			newHead=newHead.next;
		if(newHead==null) return newHead;
		ListNode p = newHead;
		while(p.next!=null){
			if(p.next.val==num){
				p.next=p.next.next; //delete p.next
			}
			else
				p=p.next;
		}
		return newHead;
	}
	
	//print result for test use
	public static void display(ListNode head){
		if(head==null){
			Console.WriteLine("");
			Console.WriteLine("empty list");
			return;
		}
		Console.WriteLine("");
		ListNode p=head;
		while(p!=null){
			Console.Write(p.val + "->");
			p=p.next;
		}
	}
}

public class Test
{
	public static void Main()
	{
		//test#1: null
		ListNode head = null;
		Solution.display(Solution.removeNodes(head,5)); //empty
		//test#2: 1
		head = new ListNode(1);
		Solution.display(Solution.removeNodes(head,5)); //1->
		//test#3: 5
		head = new ListNode(5);
		Solution.display(Solution.removeNodes(head,5)); //empty
		//test#4: 1->2
		head = new ListNode(1);
		head.next = new ListNode(2);
		Solution.display(Solution.removeNodes(head,5)); //1->2->
		//test#5: 5->5->5
		head = new ListNode(5);
		head.next = new ListNode(5);
		head.next.next = new ListNode(5);
		Solution.display(Solution.removeNodes(head,5)); //empty
		//test#6: 1->2->5->5
		head = new ListNode(1);
		head.next = new ListNode(2);
		head.next.next = new ListNode(5);
		head.next.next.next = new ListNode(5);
		Solution.display(Solution.removeNodes(head,5)); //1->2->
		//test#7: 1->2->5->5->3
		head = new ListNode(1);
		head.next = new ListNode(2);
		head.next.next = new ListNode(5);
		head.next.next.next = new ListNode(5);
		head.next.next.next.next = new ListNode(3);
		Solution.display(Solution.removeNodes(head,5)); //1->2->3->
	}
}
