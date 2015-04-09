/**
Sort a linked list in O(n log n) time using constant space complexity.


Solution:
For this problem, we cannot use insertion sort, because the time complexity of insertion sort
is O(n^2). Instead we must use a sort algorithm that runs in O(nlogn) time. 
Since we already know how to merge two sorted linkedlist, we can use merge sort to solve this problem.

The idea of merge sort is as follows:
1, Use fast and slow pointers to break the list into two parts from the middle.
2, Recursively sort the two sub Lists.
3, Merge the two sorted sub lists together.

Note:
1, the base case for recursion is when head==null or head.next==null, return head.
2, In order to break the list into two parts, we need to keep track of the previous
node of slow pointer. After the while loop, slow pointer is at the middle node. So we
set preMid as head initially and in each pass, before updatting slow to slow.next, 
we update preMid to slow. So that at any stage of the loop, preMid is at the previous
node of slow pointer. 
Then after the loop, simply set preMid.next=null to break the list into two parts.

Time: O(nlogn)   Space: O(1)
*/

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
public class Solution {
    public ListNode SortList(ListNode head) {
        if(head==null || head.next==null) return head; //base case
        ListNode slow = head, fast=head, preMid = head; //keep track of previous node of slow
        while(fast!=null&&fast.next!=null){
            fast = fast.next.next;
            preMid = slow;
            slow = slow.next;
        }
        preMid.next = null; //split list into two parts
        ListNode left = sortList(head);
        ListNode right = sortList(slow); //now slow is the middle node
        return mergeTwoLists(left,right);
    }
    
    //method to merge two sorted lists
    private ListNode MergeTwoLists(ListNode l1, ListNode l2){
        if(l1==null||l2==null){
            if(l1 ==null) return l2;
            if(l2 ==null) return l1;
        }
        ListNode newHead,p,p1,p2;
        if(l1.val < l2.val){
            newHead = l1;
             p1 = l1.next;
             p2 = l2;
        }
        else{
            newHead = l2;
             p1 = l1;
             p2 = l2.next;
        }
           
         p = newHead;
        while(p1!=null && p2!=null){
            if(p1.val < p2.val){
                p.next = p1;
                p1 = p1.next;
            }
            else{
                p.next = p2;
                p2 = p2.next;
            }
            p=p.next;
        }
        //no need to use the while loop, directly append p1 or p2 to p
        //because rest nodes of p1 or p2 are already sorted
        if(p1!=null) p.next=p1;
        if(p2!=null) p.next=p2;
        return newHead;
    }
}
