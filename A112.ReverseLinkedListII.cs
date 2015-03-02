/**
Reverse a linked list from position m to n. Do it in-place and in one-pass.

For example:
Given 1->2->3->4->5->NULL, m = 2 and n = 4,

return 1->4->3->2->5->NULL.

Note:
Given m, n satisfy the following condition:
1 ≤ m ≤ n ≤ length of list.

The solution code suppose the above condition may not be satisfied,
just in case in the real interview, we may need to handle more edge
cases then we thought.
*/

/**
Solution:
We can solve this problem in two steps:
1, find the location of mth node and (m-1)th node in the original list.
To do this, we need to append a new node preHead before the head node in case that
the mth node is the head node, then we will use preHead as the (m-1)th node.

2, Insert (m+1)th node,..., nth node to between (m-1)th node and mth node.
To do this, we need a pointer curr that points to the node to be insert. And we
must insert each node right after (m-1)th node. Each time in the while loop,
we insert curr between (m-1)th node and its next node. Then let mth node.next point
to curr.next. And then we move curr one step forwrad.

3, After the insertion, we return preHead.next, which is the new head of reversed list.


Time Complexity: we do the reverse in one pass, so O(n).
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
    public ListNode ReverseBetween(ListNode head, int m, int n) {
        if(head==null) return null; //handle edge case
        ListNode preHead = new ListNode(0); 
        preHead.next = head;
        ListNode start = preHead; //start will be the (m-1)th node in the list
        //advance start pointer to the (m-1)th node in the list
        int count = 1;
        while(start!=null && count<m){
            start = start.next;
            count++;
        }
        
        if(count<m) return head; //length of the list is smaller than m, edge case
        //end is the mth node in the list
        ListNode end = start.next; //node will be inserted between start and end
        ListNode curr = end.next;//curr is the node to be insert 
        
        //insert each node right after start, advance curr until count==n
        while(curr!=null && count<n){
            ListNode next = curr.next; //get the next node using curr.next
            curr.next = start.next; //insert curr right after start node
            start.next = curr;
            end.next = next; //point end to next node
            curr = next; //advance curr to next node
            count++;
        }
        return preHead.next; //preHead is the node before original head, so return preHead.next
        
    }
}
