/**
Given a linked list, remove the nth node from the end of list and return its head.

For example,

   Given linked list: 1->2->3->4->5, and n = 2.

   After removing the second node from the end, the linked list becomes 1->2->3->5.
Note:
Given n will always be valid.
Try to do this in one pass.


Solution:
This is a very classic Linked List problem.
The key point is to find the location of (n-1)th node from the end of list, then
we can easily remove nth nth node from the end of list.

Use two pointers, fast and slow, to solve this problem in one pass.
fast and slow will both start at the head. First move fast pointer forward for n steps.
Then move fast and slow forward at the same speed until fast.next is null. Now fast
is at the end of the list, slow will be at the (n-1)th node from the end. Thus we can 
simply let slow.next = slow.next.next to remove the nth node from the end.

Edge case: there is a very important edge case to handle. When the nth node from the end
is the head of the list, after moving fast forward for n steps, fast will be at the end of 
the list. So after the first move of fast, we need to check if fast.next is null. If it
is, we simply remove head and return head.next. If it is not, we do the second move for
both fast and slow.

Time complexity: O(n)
*/


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode fast = head;
        ListNode slow = head;
        for(int i=0;i<n;i++){
            fast=fast.next;
        }
        if(fast==null) return head.next;
        while(fast.next!=null){
            fast=fast.next;
            slow=slow.next;
        }
        slow.next = slow.next.next;
        return head;
    }
}
