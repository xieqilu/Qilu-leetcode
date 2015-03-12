/**
Given a binary tree and a sum, determine if the tree has a root-to-leaf path 
such that adding up all the values along the path equals the given sum.

For example:
Given the below binary tree and sum = 22,
              5
             / \
            4   8
           /   / \
          11  13  4
         /  \      \
        7    2      1
return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.


Solution:
This is an simple typical DFS Problem. We can use iterative or recursive solution to solve it.

Solution 1: My solution
Use recursive DFS approach to check each path from root to leaf and find if the sum of values is
equal to input sum.

Notice in this problem, we only consider root to leaf path so it's important to identify leaf node.
If n.left and n.right are both null, then n must be a leaf node. So the idea is recursively check
paths from root to each leaf and store the sum of node value to a list. After the recursive call,
check if any element in the list is equal to input sum, if it is, return true, otherwise, false.

We use a Top-Down approach, the recursive method will take three parameters:
TreeNode node, an integer value indicating sum of values from root to its parent, and a List<int>.
In the recursive call, if node is a leaf, put the sum of node.val and value into list. If node is
not a leaf, then if node.left is not null, recursively call method(node.left, node.val+value,list).
If node.right is not null, recursively call method(node.right, node.val+value, list).

So the recursion base case is when current TreeNode is a leaf node, the recursion would be stopped.

Time complexity: O(n) n is the number of nodes in the tree


Solution 2: Leetcode official Solution
We can also convert the above recurisve process to iterative.
When implementing iterative DFS, we must use a Stack. The basic idea is we only consider leaf node as
the end of a path, so must specially handle leaf node. If we pop a node from stack and it's a leaf, then
we compare the sum of this path to input sum, if it is equal, return true. If it's not equal, we continue
the iterative process. In the iterative loop, we memorize sum of value in a path by changing the value of 
nodes on this path. In other words, for each visited node, node.val will be updated to the sum of values 
from root to its parent.

So first we push root to the stack. Then while stack is not empty, pop the current node and check if it is
a leaf. If it's leaf, compare its value with input sum, if equal, return true, otherwise, continue. If it's 
not a leaf, then if node.left is not null, update node.left.val+=current.val then push node.left to stack.If
node.right is not null, update node.right.val+=current.val then push node.right to stack.
If after the while loop, the method still not return, then we return false.


Recursive vs Iterative:
In this problem, they both have pros and cons.
If we use recursive method, we'll need to visit each path of the tree, store all sums and then check if there
is one path that equals to input sum. But if using iterative method, once we find a path that equals to the 
input sum, we can immidieatly return true.

On the other hand, Iterative method will modify the original tree and also use a stack. But recursive method
won't modify input tree.
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
 
 //My Solution: Recursive Solution
 public class Solution{
     public bool HasPathSum(TreeNode root, int sum){
         if(root==null) return false;
         List<int> list = new List<int>();
         DFS(root, 0,list);
         foreach(int i in list){
             if(i==sum) return true;
         }
         return false;
     }
     
     private void DFS(TreeNode root, int value, List<int> list){
         if(root.left==null&&root.right==null){
             list.Add(value+root.val);
             return;
         }
         if(root.left!=null) 
            DFS(root.left, value+root.val, list);
         if(root.right!=null)
            DFS(root.right,value+root.val, list);
     }
 }
 
 

 //Leetcode Official Solution: Iterative solution
 public class Solution {
    public bool HasPathSum(TreeNode root, int sum){
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0 && root != null){
            TreeNode current = stack.Pop();
            if (current.left == null && current.right == null){
                if (current.val == sum) return true;
            }
            if (current.right != null){
                current.right.val = current.val + current.right.val;
                stack.Push(current.right);
            }
            if (current.left != null){
                current.left.val = current.val + current.left.val;
                stack.Push(current.left);
            }
        }
        return false;
    }
}
