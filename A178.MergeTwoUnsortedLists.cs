/**
Given two unsorted LinkedLists, sort and merge them into one sorted LinkedList.


Solution:
For this problem, there are two basic approaches (suppose the length of two lists are n and m):
1, sort two lists seperately, then merge two sorted lists together. Time: O(nlogn+mlogm)
2, merge two lists together, then sort the merged list. Time: O((m+n)log(m+n))

According to the time complexity, the first approach has a better running time than the second. So 
we will take the first approach.

Steps:
1, implement mergeTwoLists method which merges two sorted lists.
2, implement sortList method which sort one list using merge sort.
3, then for the method to merge two unsorted lists, 
use sortList to sort the two lists seperately, then use mergeTwoLists to get final result.

The solution is pretty simple if we already know how to implement mergeTwoLists and sortList methods.

Time: O(nlogn+mlogm)  Space: O(1)
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
    public ListNode MergeUnsortedLists(ListNode l1, ListNode l2){
        ListNode p1 = sortList(l1);
        ListNode p2 = sortList(l2);
        return mergeTwoLists(p1,p2);
    }
    
    private ListNode SortList(ListNode head) {
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
