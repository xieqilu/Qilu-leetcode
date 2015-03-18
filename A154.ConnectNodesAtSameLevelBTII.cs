/**
 * Follow up for problem "Populating Next Right Pointers in Each Node".

What if the given tree could be any binary tree? Would your previous solution still work?

Note:

You may only use constant extra space.
For example,
Given the following binary tree,
         1
       /  \
      2    3
     / \    \
    4   5    7
After calling your function, the tree should look like:
         1 -> NULL
       /  \
      2 -> 3 -> NULL
     / \    \
    4-> 5 -> 7 -> NULL
    

Idea:
There are two approaches to solve this problem:
1, use two queues (or one queue and two variables) to do BFS for the tree, the method is almost the 
same as Level Order Traversal for Binary Tree. The logic is simpler but requires O(n) space.
2, use two pointers, prev and next to do iterative BFS for the tree, the logic is a little tricky but
only use constant memory space.

Solution1: Level Order Traversal using two queues.
This method is almost the same as Level Order Traversal of Binary Tree. Use two queues to store nodes
at current level and nodes at next level. For each node in the current level, connect it to the next
node in the queue. When queue is empty, swap the two queues and continue the while loop. If after swap,
the queue is still empty, then there is no more nodes in the tree.

Time: O(n)  Space:O(n)


Solution2: Level Order Traversal using one queue.
Very similiar to Solution1. Use two int currentNodes and nextNodes to keep track of the number of nodes
at current level and next level. In the while loop, after removing a node from queue, currentNodes--. And
after add a node to the queue, nextNodes++. For each node in the queue, if currentNodes!=0, connect it
to the next node in the queue. Otherwise, update currentNodes=nextNodes, and set nextNodes=0.


Solution3: Iterative BFS using only constant space
The key point of this method is to use two TreeLinkNode prev and next. Prev is used to keep track of the
previous node at the next level. And next is used to keep track of the first node at the next level.
Initially set curr=root,prev=null,next=null, the condition of while loop is curr!=null.
For each Node curr in loop, we actually try to construct next pointers for the next level of curr.

If curr has left child:
If prev==null, means curr.left is the first node at next level. We update prev=curr.left and next=curr.left.
Else: there is a previous node before curr.left, connect prev to curr.left and update prev=prev.next.

If curr has right child:
If prev==null, means curr.right is the first node at next level. We update prev=curr.left and next=curr.right.
Else: there is a previous node before curr.right, connect prev to curr.right and update prev=prev.next.

Then if curr.next!=null, means curr is not the last node at this level, so update curr=curr.next to continue
operation for the next node at this level.
Else: then curr is the last node at this level, so update curr to the first node at next level by curr=next, 
and continue operation for the next level.

If after the above two update, curr is still null, then there is no more nodes in the tree, return.

Time: O(n)  Space: O(1)
*/

/**
 * Definition for binary tree with next pointer.
 * public class TreeLinkNode {
 *     int val;
 *     TreeLinkNode left, right, next;
 *     TreeLinkNode(int x) { val = x; }
 * }
 */


//Solution1: Level Order Traversal (Using two queues)  Time: O(n)  Space:O(n)
public class Solution {
    public void Connect(TreeLinkNode root) {
        if(root==null) return;
        Queue<TreeLinkNode> curr = new Queue<TreeLinkNode>();
        Queue<TreeLinkNode> next = new Queue<TreeLinkNode>();
        curr.Enqueue(root);
        while(curr.Count!=0){
            TreeLinkNode temp = curr.Dequeue();
            if(temp.left!=null)
                next.Enqueue(temp.left);
            if(temp.right!=null)
                next.Enqueue(temp.right);
            if(curr.size()!=0)
                temp.next = curr.Peek();
            else{
                foreach(TreeLinkNode node in next)
                    curr.Enqueue(node);
                next.Clear();
            }
        }
    }
}


//Solution2: Level Order Traversal (using one queues and two variables)  Time: O(n) Space: O(n)
public class Solution {
    public void Connect(TreeLinkNode root) {
        if(root==null) return;
        Queue<TreeLinkNode> nodes = new Queue<TreeLinkNode>();
        nodes.Enqueue(root);
        int currentNodes=1, nextNodes=0;
        while(nodes.Count=0){
            TreeLinkNode curr = nodes.Dequeue();
            currentNodes--;
            if(curr.left!=null){
                nodes.Enqueue(curr.left);
                nextNodes++;
            }
            if(curr.right!=null){
                nodes.Enqueue(curr.right);
                nextNodes++;
            }
            if(currentNodes!=0)
                curr.next = nodes.Peek();
            else{
                currentNodes=nextNodes;
                nextNodes=0;
            }
        }
    }
}


//Solution3: Iterative BFS using constant extra space  Time: O(n)  Space: O(1)
public class Solution {
    public void Connect(TreeLinkNode root) {
        if(root==null) return;
        TreeLinkNode curr = root;
        //prev stores previous node at the next level
        //next stores first node at the next level
        TreeLinkNode prev = null, next = null;
        while(curr!=null){  //construct next pointers for next(children) level of curr
            if(curr.left!=null){
                if(prev==null){ // means curr.left is the first node at the next level
                    prev=curr.left;
                    next=prev; //update next as the first node at the next level
                }
                else{ //curr.left is not the first node at the next level
                    prev.next=curr.left;
                    prev=prev.next; //update prev to next node
                }
            }
            if(curr.right!=null){
                if(prev==null){ //means curr has no left child, thus curr.right is the first node
                    prev=curr.right;
                    next=prev;
                }
                else{ //curr.right is not the first node at the next level
                    prev.next=curr.right;
                    prev=prev.next;
                }
            }
            if(curr.next!=null) //curr is not the last node at this level
                curr=curr.next; //update curr to the next node at this level
            else{  //curr is the last node at this level
                curr=next; //update curr to the first node at the next level
                prev=null; //set prev and next as null for iteration of next level
                next=null;
            }
        }
    }
}
