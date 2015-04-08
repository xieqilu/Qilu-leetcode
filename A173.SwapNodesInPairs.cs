/**
Given a linked list, swap every two adjacent nodes and return its head.

For example,
Given 1->2->3->4, you should return the list as 2->1->4->3.

Your algorithm should use only constant space. 
You may not modify the values in the list, only nodes itself can be changed.


Idea: 
The task is to swap each pair of adjecent nodes. The solution is pretty straightforward, 
just pay attention to details and edge cases. The basic idea is to keep track of the 
previous node of the current pair, swap the pair and update all related pointers.

Edge case:
if head is null or head.next is null, return head. (if only one node, no need to swap)

Also note before the swapping, we need to create a pointer that points to head.next, since the
original head.next would be the new head to return.

Solution1: my solution
Use two pointers l1 and l2 representing the two nodes to swap. Use a pointer prev representing
the previous node of l1. In the while loop, swap l1 and l2 then update l1, l2 and prev. Before
updatting, check if l1.next is null, if it is, break the loop since there is no more nodes to 
swap.

Time: O(n)  Space: O(1)

Solution2: Leetcode Official Solution
Use one pointer p representing the first node of the current pair. Use a pointer prev representing
the previous node of l1. In the while loop, swap p and p.next then update prev and p. Note before
swapping, use a pointer next to hold p.next.next so that we can swap correctlly.

Time: O(n)  Space: O(1)
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

//My Solution: time: O(n)  Space: O(1)
public class Solution {
    public ListNode SwapPairs(ListNode head) {
        if(head==null||head.next==null) return head;
        ListNode l1 = head;
        ListNode l2 = head.next;
        ListNode newHead = head.next; //new head must be head.next
        ListNode prev = null; //keep track of the previous head of l1
        while(l1!=null&&l2!=null){
            if(prev!=null) //edge case: no node before l1
                prev.next=l2;
            l1.next = l2.next; //swap
            l2.next=l1;
            if(l1.next==null) //if no more nodes to swap
                break;
            prev=l1; //update prev, l2, l1
            l2=l1.next.next;
            l1=l1.next;
        }
        return newHead;
    }
}


//Leetcode Official Solution  Time: O(n)  Space: O(1)
public class Solution {
    public ListNode SwapPairs(ListNode head) {
        if(head==null || head.next==null) 
            return head;
        ListNode p = head;
        ListNode newHead = head.next;
        ListNode prev =null;
        while(p!=null && p.next!=null){
            ListNode next = p.next.next;
            p.next.next = p;
            if(prev!=null)
                prev.next = p.next;
            p.next=next;
            prev=p;
            p=next;
        }
        return newHead;
    }
}
