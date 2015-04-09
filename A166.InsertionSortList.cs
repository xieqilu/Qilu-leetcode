/**
Sort a linked list using insertion sort.

Idea of Insertion Sort:
Insertion sort iterates, consuming one input element each repetition, and growing a sorted output list. 
Each iteration, insertion sort removes one element from the input data, finds the location it belongs within the sorted list, 
and inserts it there. It repeats until no input elements remain.

Sorting is typically done in-place, by iterating up the array, growing the sorted list behind it. 
At each array-position, it checks the value there against the largest value in the sorted list 
(which happens to be next to it, in the previous array-position checked). 
If larger, it leaves the element in place and moves to the next. If smaller, it finds the correct position within the sorted list, 
shifts all the larger values up to make a space, and inserts into that correct position.

Time: Worst: O(n^2)  Best: O(n)
Space: O(1)
More efficient in practice than most other simple quadratic (i.e., O(n2)) algorithms 
such as selection sort or bubble sort

Adaptive, i.e., efficient for data sets that are already substantially sorted: 
the time complexity is O(nk) when each element in the input is no more than k places away from its sorted position


Solution:
The idea of sorting a LinkedList using insertion sort is the same as above. Assuming the first k nodes are already
sorted, then for the k+1 node, we iterate the first k nodes and find the correct position for the k+1 node, insert
it to the position then keep doing this process for the k+2 node.

But there are some issues we need to be clear:
1, In each pass, we need to keep track of the previous node (prev) of current node(curr). Because if curr is removed
and inserted to a new position, we need to set prev.next=original curr.next to keep the list connected.

2, Each pass we need to update prev and curr, curr would always be updated as original curr.next. But prev has different
update situations. If curr is not moved, then prev should be updated as curr. If curr is moved, then prev should
stay the same, because now prev.next points to original curr.next.

3, To implement issue#2, we need to use two pointers newPrev and newCurr to store curr and curr.next at the start of
each pass, then if curr is moved, we set newPrev=prev. And at the end of each pass, always update prev=newPrev and
curr=newCurr.

Time: worst: O(n^2) Best: O(n) 
Space:(1)
*/

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
public class Solution {
    public ListNode InsertionSortList(ListNode head) {
        ListNode preHead = new ListNode(Int.MinValue);
        preHead.next = head;
        ListNode prev = null; //points to the node before curr
        ListNode curr = head;
        while(curr!=null){
            ListNode newPrev = curr; //if curr won't be moved, the prev for next pass
            ListNode newCurr = curr.next; //if curr won't be moved, the curr for next pass
            ListNode p = preHead;
            while(p.next!=curr){
                if(curr.val>=p.val && curr.val<=p.next.val){//curr needs ot be inserted between p and p.next
                    ListNode temp = curr.next; //store original curr.next
                    curr.next = p.next; //insert curr 
                    p.next = curr;
                    prev.next = temp; //after removing curr, needs to connect prev and original curr.next
                    newPrev = prev; //curr is moved so prev for next pass doesn't change
                    break;
                }
                p=p.next;
            }
            prev=newPrev; //if curr is not moved, prev won't change, otherwiese, prev points to curr
            curr=newCurr; //curr would always points to curr.next
        }
        return preHead.next;
    }
}
