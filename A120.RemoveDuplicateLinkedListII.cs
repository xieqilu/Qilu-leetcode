/**
 * Given a sorted linked list, delete all nodes that have duplicate numbers, 
 * leaving only distinct numbers from the original list.

For example,
Given 1->2->3->3->4->4->5, return 1->2->5.
Given 1->1->1->2->3, return 2->3.


Solution1: Iterative solution
We can use an iterative solution to solve this problem. Since we need to delete
all duplicates node, if we find curr and curr.next are duplicate, we need to delete
both curr and curr.next. So we must use a pointer to keep track of the previous node
of curr, then we are able to delete both curr and curr.next.

So basically we will have three pointers: prev, curr and next. Initially prev is null,
curr is the head, and next is curr.next. In the while loop, obviously we need to advance
next to the nearest non-duplicate node of curr. And then we have three different situations
to consider:
1, if next==curr.next, that means curr.next is not a duplicate of curr and in fact we did not
advance next pointer at all. So we don't need delete any node, just advance all three pointers
2, if next!=curr.next, that means we advanced next pointer and there are some duplicates with curr.
So we need to delete curr and all its duplicates. Then we need to check if curr is still the head,
if prev is null, then curr is the head. So we need to move head to next pointer to delete the 
original head and all its duplicate node.
3, If in the No.2 situation, we find that curr is not the head and prev is not null. We can simply
set prev.next= next to delete curr and all its duplicate. Then advance curr and next but do not advance
prev.

Note only in the situation No.1 we need to advance prev pointer, but in all three situations we need to
advance curr and next pointer.


Solution 2: Recursive Solution
Use recursive solution to solve this problem is very simple and elegant!
Suppose method d(ListNode head) will return a Linked List from node head with all duplicates deleted.
If given a node p and we want to delete all duplicates from it, our task is simply find out for which
following node we need to call method d again. In other words, we just need to ignore all duplicates for p
and call d(q), in which q is the nearest non-duplicate node of p.
The base case is when p is null, we return null.

By using recursive method, we only need to consider the following two situations:
1,the current input p has duplicates, then we need to delete p and all its duplicate, So we just return
d(q). q is the nearest non-duplicate node of p.
2,the current input p doesn't have duplicates, then we do not need to delete p,so we let p.next = d(q) and
then return p. 

In detail, we need to use a bool flag to distinguish the above two situations and operate accordingly.

Note by using recursive solution, we do not need to directly delete any node. Instead, we just ignoring all
duplicate nodes and choose where to call the recursive method and what to return. Thus, we do not need to do
any special operation for head duplicate at all.


Solution 3: More elegant recursive Solution
The same idea as Solution 2, but a more clean and elegant solution (without using the bool flag).
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
 
 //Solution 1: Iterative Solution
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        if(head==null) return null; 
        ListNode prev = null; 
        ListNode curr = head;
        while(curr!=null){
            ListNode p = curr.next; //keep track of curr.next
            while(p!=null&&p.val==curr.val){ //advance p to nearest non-duplicate node
                p=p.next;
            }
            if(p==curr.next) //if p and curr are not duplicate nodes
                prev = curr; //advance prev to curr
            else{ //if p and curr are duplicate
                //if prev is null, then curr is the head, otherwise, curr is not the head
                if(prev!=null)
                    prev.next=p;
                else //if curr is the head, need to ignore the current head
                    head=p;
            }
            curr = p;
        }
        return head;
    }
}

//Solution 2: Recursive solution
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        if(head==null) return null; //edge case
        ListNode p = head;
        ListNode p2 = head.next;
        bool isDup = false; //isDup indicates whether p is a duplicate or not
        //advance p2 to the nearest different node of p
        while(p2!=null && p.val==p2.val){
            p2=p2.next;
            isDup = true; //if there is duplicate, set isDup as true
        }
        //Recursive call to remove duplicates from node p2
        ListNode next = DeleteDuplicates(p2);
        
        if(isDup) //if p is a duplicate, ignore it and return next
            return next;
        else{  //if p is not a duplicate, append next to p and return p
            p.next = next;
            return p;
        }
    }
}

//Solution 3: Same idea, but a much more elegant recursive solution!
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        if(head==null) return null;
        ListNode p = head.next;
        //If head is not a duplicate, do not ignore head
        if(p==null || head.val!=p.val){
            head.next = DeleteDuplicates(p);
            return head;
        }
        //If still not return, then must p!=null&&p.val==head.val
        //Then head must be a duplicate with at least one following node
        while(p!=null&&head.val==p.val){
            p=p.next;
        }
        return DeleteDuplicates(p);//ignore head 
    }
}
