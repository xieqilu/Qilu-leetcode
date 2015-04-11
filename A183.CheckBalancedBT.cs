/**
Given a binary tree, determine if it is height-balanced.

For this problem, a height-balanced binary tree is defined as a binary tree 
in which the depth of the two subtrees of every node never differ by more than 1.

Important Reference: 
http://www.algoqueue.com/algoqueue/default/view/8912896/check-binary-tree-balanced-or-not 


Idea:
This is a typical recursive problem for Binary Tree. In order to check if a subtree is balanced,
we need to get the height for each node. We can use a recursion method to get height for each node.
And we will also need a recursion to check if each subtree is balanced.
We can use seperate recursions to get height and check balance. Thus the time complexity would be 
O(n^2). But a better solution is using the same recursion to get height and check balance, thus there
would be only one recursion to traverse the binary tree, so time complexity would be O(n).

Solution1:
Use two recursions.

Use a seperate recursive method GetHeight() to get height of node. 
Base Case: if node==null, return 0. 
Return 1+Max(GetHeight(root.left),GetHeight(root.right)).

Then the IsBalanced() method is also a recursive method.
Base Case: if node==null, return true. An empty tree is a balanced tree.

Then take the root and get height of left and right subtree. If the height 
differ less than 1 AND left subtree is balanced AND right subtree is balanced,
return true. Otherwise, return false.

In this solution, for each node, we will use a recursion to check if it's balanced,
and in this recursion, we will use another recursion to get height of node. 
Potentailly each recursion will have O(n) running time, so overall running time is O(n^2), 
it's a nested recursion.

Time complexity: O(n^2)


Solution2: Better solution
Use the same recursion to get height and check balance for each node.
The trick of this solution is when using a recursion to get height of each node, we can use
a special height value to indicate the subtree is not balanced for a specific node. 
The special height value is -1, since -1 could never be a valid height.

So in the recursive method GetHeight():
Base Case: if root==null, return 0
Then get height of left subtree and height of right subtree.
If height of any subtree is -1, then we directly return -1. (because if a subtree is not balanced,
the current root tree must not be balanced, too)
Then if the height of subtree differs more than 1, return -1.
Otherwise, return 1+Maximum of left and right subtree.

The key point is using -1 to indicate a subtree is not balanced. The recursive method will return 
the height if all subtree are balanced, otherwise it will return -1.

So in the IsBalanced() method, we simply get height of root, if the value is -1, then this tree
is not balanced. Otherwise, it's balanced.

Time Complexity: O(n)
*/

/**
 * Definition for binary tree
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

//Solution1: Use different recursion to get height and check balance. Time: O(n^2)
public class Solution {
    //Recursive method to get height of node
    private int GetHeight(TreeNode root){
        if(root==null) return 0;
        return 1+Math.Max(GetHeight(root.left), GetHeight(root.right));
    }
    //Recursive method to check balance of node
    public bool IsBalanced(TreeNode root) {
       if(root==null)
            return true;
       if(Math.Abs(GetHeight(root.left)-GetHeight(root.right))<=1 
            && IsBalanced(root.left) && IsBalanced(root.right))
            return true;
        return false;
    }
}

//Better solution
//Solution2: Use the same recursion to get height and check balance. Time: O(n)
public class Solution {
    //Recursive method to get height and check balance of each node
    private int GetHeight(TreeNode root){
        if(root==null) return 0;
        int left = GetHeight(root.left);
        int right = GetHeight(root.right);
        if(left==-1||right==-1) 
            return -1;
        if(Math.Abs(left-right)>1) 
            return -1;
        return 1+Math.Max(left,right);
    }
    
    public bool IsBalanced(TreeNode root) {
        if(root==null)
            return true;
        if(GetHeight(root)==-1)
            return false;
        return true;
    }
}
