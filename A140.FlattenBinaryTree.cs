/**
Given a binary tree, flatten it to a linked list in-place. 
Or: Given a 2D LinkedList in which each node contains 3 parameters namely, 
data , pointer to left, pointer to down . 
The aim of the function is to flatten the linkedlist.

The above two format of this problem is equivalent. They are the same problem.

For example,
Given

         1
        / \
       2   5
      / \   \
     3   4   6
The flattened tree should look like:
   1
    \
     2
      \
       3
        \
         4
          \
           5
            \
             6


Hints: if you notice carefully in the flattened tree, 
each node's right child points to the next node of a pre-order traversal.


Solution1: 
Notice that by flatting the binary tree, we actually insert left child between root and right child
for any (root->left->right) combination. In other words, the flattened LinkedList will obey root->left->right
order from the binary tree, which is exactly the order of pre-order traversal.
So we can do a recursive pre-order traversal on the tree and use a prev TreeNode representing the previous 
treenode in the pre-order traversal. Then for each call, if prev!=null, let prev.left=null and prev.right=root.
Then recursive do the call for root.left and root.right.

Special Note: Since we must first call for root.left and then root.right, the call of root.left might modify root.right
to root.left (because now prev is root) and influence the next call. So before those two calls, we need to retrieve
root.right firstly to make sure no StackOverflow.

Time: O(n)  n is the number of nodes in the tree

/**
 * Definition for binary tree
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
 
//Solution1: Recursive Pre-order traversal
public class Solution {
    private void FlattenHelper(TreeNode root, ref TreeNode prev){
        if(root==null) return; //Base case 
        //Be aware that root.right might be modified to point to left child in the first recursive call
        if(prev!=null){
            prev.left=null;
            prev.right=root; //modify prev.right
        }
        prev=root; //update prev
        TreeNode right = root.right; //must retrieve current root.right before doing any recursive calls
        FlattenHelper(root.left, ref prev); //This first recursive call might modify prev.right (root.right)
        FlattenHelper(right, ref prev);////cannot directly use root.right, will lead StackOverflow
    }
    
    public void Flatten(TreeNode root) {
        TreeNode prev=null;
        FlattenHelper(root, ref prev);
    }
}
