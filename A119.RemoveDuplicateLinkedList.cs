/**
Given a sorted linked list, delete all duplicates such that each element appear only once.

For example,
Given 1->1->2, return 1->2.
Given 1->1->2->3->3, return 1->2->3.


Solution:
This is a very basic and simple Linked List problem. 
Use two pointer prev and curr to traverse the list, initially prev=head, curr=head.next.
while curr!=null, if prev and curr have the same value, we delete current curr and advance
the pointer curr. Otherwise, we advance both pointers.

Do not forget to handle the edge case when head is null, we return null.
*/


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode(int x) {
 *         val = x;
 *     }
 * }
 */
//The below solution passed all test cases from Leetcode
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        if(head==null) return null;
        ListNode prev = head;
        ListNode curr = head.next;
        while(curr!=null){
            if(prev.val==curr.val){
                prev.next = curr.next; //delete curr
                curr = curr.next; //advance curr, no change for prev
            }
            else{
                prev = curr;
                curr = curr.next;
            }
        }
        return head;
    }
}
