/**
 * Given a binary tree

    struct TreeLinkNode {
      TreeLinkNode *left;
      TreeLinkNode *right;
      TreeLinkNode *next;
    }
Populate each next pointer to point to its next right node. 
If there is no next right node, the next pointer should be set to NULL.

Initially, all next pointers are set to NULL.

Note:

You may only use constant extra space.
You may assume that it is a perfect binary tree 
(ie, all leaves are at the same level, and every parent has two children).
For example,
Given the following perfect binary tree,
         1
       /  \
      2    3
     / \  / \
    4  5  6  7
After calling your function, the tree should look like:
         1 -> NULL
       /  \
      2 -> 3 -> NULL
     / \  / \
    4->5->6->7 -> NULL



Idea: 
Since the input is guaranteed to be a perfect binary tree. We can solve this problem using constant space.
The logic is pretty simple:
For each current node root, we construct the next pointers for its children level as follows:
root.left.next = root.right. 
If root.next!=null, root.right.next=root.next.left.

We can solve this problem using recursive DFS and iterative BFS.

Solution1: Recursive DFS
For each recursive call, we construct the next pointers for the children level of current root,
then keep calling for root.left and root.right.
Base case: when the current root has no children (we can just check for root.left because it's a
perfect binary tree, so root.left==null), return. Because there is no children level to construct.

Edge case: when the input root is null, return.


Solution2: Iterative BFS
Since the input is a perfect Binary Tree and each node has a next pointer, we don't need a queue
to implement iterative BFS. We can just use the next pointer to do it.

In detail, we use two while loops. In the outter while loop we update root to continue to the next 
level. In the inner while loop we update curr to continue to the next Node at the same level.
The condition for the inner while loop is curr!=null&&curr.left!=null. curr!=null is used to stop
when no Node at this level, and curr.left!=null is used to stop when no children(deeper) level exists.
In the inner while loop, we construct next pointers for children level of curr, then update curr=curr.next
to iterate all nodes at this level.
In the outter while loop, we set curr= root, then after inner loop we update root=root.left to keep the call
for the next level.
*/


/**
 * Definition for binary tree with next pointer.
 * public class TreeLinkNode {
 *     int val;
 *     TreeLinkNode left, right, next;
 *     TreeLinkNode(int x) { val = x; }
 * }
 */

//Solution1: Recursive DFS Solution
public class Solution {
    public void Connect(TreeLinkNode root) {
        if(root==null) return; //edge case: input root is null
        if(root.left==null) return; //Base case: current root has no children
        root.left.next=root.right;
        if(root.next!=null)
            root.right.next = root.next.left;
        Connect(root.left);
        Connect(root.right);
    }
}


//Solution2: Iterative BFS Solution
public class Solution {
    public void Connect(TreeLinkNode root) {
        while(root!=null){
            TreeLinkNode curr = root;
            while(curr!=null && curr.left!=null){ 
                curr.left.next=curr.right;
                if(curr.next!=null)
                    curr.right.next = curr.next.left;
                curr=curr.next;
            }
            root=root.left;
        }
    }
}

