/**
 * Merge two sorted linked lists and return it as a new list. 
 * The new list should be made by splicing together the nodes of the first two lists.
 * 
 * Solution:
 * The solution is very similiar as merge two sorted array. 
 * We also use two pointers to simultaneously iterate two Lists.
 * 
 * First we need to handle edge case, if one input list is null,
 * we return the other list. If both are null, return null.
 * 
 * Then set a node newHead to the smaller head node of the two lists.
 * And when iterating the two linked lists, each time we append the smaller
 * node to the current newHead. And update newHead and the appened node.
 * 
 * After the above loop, we will append all remaining nodes of a list to 
 * the new list (use two while loop because we do not know which input list
 * has remaining nodes).
 * 
 * */



/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
 
//This is my solution, which is the same as Leetcode official Solution!!!
public class Solution {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
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
