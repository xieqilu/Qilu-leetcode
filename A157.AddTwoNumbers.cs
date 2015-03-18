/**
You are given two linked lists representing two non-negative numbers. 
The digits are stored in reverse order and each of their nodes contain a single digit. 
Add the two numbers and return it as a linked list.

Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8


Solution:
This is a very good problem containing lots of useful trick and approach.
The basic idea is constructing the result list one digit by one digit. 
We will use an integer carry to store (l1.val+l2.val+carry)/10 for each pair of digits.
Initially carry is 0. In the while loop, each pass we will construct a new node of result list with the
value of (l1.val+l2.val+carry)%10 and update carry. Then move l1,l2 and result pointer 
forward for one step.

The above logic is pretty simple, but there are some cases that we need to handle:
1, We need to first have a head node for the result list then we can use the while loop.
To avoid writing duplicate codes, we can use a preHead node with value -1 and initially
set head=preHead. Then in the while loop, we construct a new node for head.next and update
head=head.next. And we returning the result, we return preHead.next as the head of result
list.

2, If the two input lists have different length, we don't need to do extra work after the 
while loop. Set the condition of while loop as l1!=null or l2!=null, then if in the loop,
l1 is null, we simply append a new node with value 0 to l1. If l2 is null, we simply append
a new node with value 0 to l2. Since a node with value 0 won't affect the final result, we 
can make the code more simple and elegant.

3, If the result list is longer than both l1 and l2, that means after the sum of last digits of
l1 and l2, the carry is 1 and we need to add an additional node to result list. So after the while
loop, we need to check if carry is 1, if it is, append a new node with value 1 to head.next.

Time: O(m+n)  m and n is the length of l1 and l2.
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

//Solution: My iterative solution, better than leetcode official solution
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode preHead = new ListNode(-1);
        ListNode head = preHead;
        int carry = 0;
        while(l1!=null || l2!=null){
            if(l1==null) l1=new ListNode(0); //if one of l1 and l2 is null, set it to
            if(l2==null) l2=new ListNode(0); //a new ListNode with value 0. Thus won't influence results
            head.next = new ListNode((l1.val+l2.val+carry)%10);
            carry = (l1.val+l2.val+carry)/10; //carry will be 0 or 1
            l1=l1.next;
            l2=l2.next;
            head = head.next;
        }
        if(carry==1)
            head.next=new ListNode(1);
        return preHead.next;
    }
}
