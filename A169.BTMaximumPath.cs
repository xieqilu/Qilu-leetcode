/**
Given a binary tree, find the maximum path sum.

The path may start and end at any node in the tree.

For example:
Given the below binary tree,

       1
      / \
     2   3
Return 6.


Solution:
Use recursive bottom-up DFS to solve this problem. Note that the return value of the recursive call is
not the same as the update max value for each recursive call. 
Use an integer max to store the max sum value. And pass the reference of max to each recursive call.
Base case: if root==null, return 0.
So for each recursive call:
1, check the base case.
2, get leftMax by call(root.left, ref max)
3, get rightMax by call(root.right, ref max)
4, Then get the max of (leftMax+root.val, rightMax+root.val, root.val) as rootMax.
5, Update max to the max of (rootMax, root.val+leftMax+rightMax, max).
6, return rootMax.

Special Note:
For each recursive call, the max value could be root.val+leftMax+rightMax, but the return value cannot 
be it. Because the return value should be the max path that can be connected to root.parent. 

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
public class Solution {
    public int MaxPathSum(TreeNode root) {
        if(root==null) return 0;
        int max = root.val;
        FindMax(root, ref max);
        return max;
    }
    
    private int FindMax(TreeNode root, ref int max){
        if(root==null)  //base case 
            return 0; 
        int leftMax = FindMax(root.left, ref max);
        int rightMax = FindMax(root.right, ref max);
        int rootMax = Math.Max(root.val, Math.Max(leftMax+root.val, rightMax+root.val));
        max = Math.Max(max, Math.Max(rootMax, leftMax+root.val+rightMax));
        return rootMax;
    }
}
