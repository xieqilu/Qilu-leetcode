/**
 * Given a binary tree, return the preorder traversal of its nodes' values.

For example:
Given binary tree {1,#,2,3},
   1
    \
     2
    /
   3
return [1,2,3].

Note: Recursive solution is trivial, could you do it iteratively?


Solution:
This is a very general and important problem. PreOrder traversal is a kind of DFS, to 
do DFS iteratively, we must use a stack. (To do BFS iteratively, we must use a queue)
Remeber the three kinds of DFS tree traversal:
PreOrder: root->left->right
InOrder: left->root->right
PostOrder: left->right->root
Note left is always ahead of right, the difference of pre/in/post is the position of root.

Also pay attention of the sequence we put children of root to the stack. Since left child
shold be pop ahead of right child, and stack is first in last out, so we need to first put
right child into the stack then left child.
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
 
//Solution1: Recursive
public class Solution {
    public IList<int> PreorderTraversal(TreeNode root) {
        IList<int> result = new List<int>();
        PreorderDFS(root,result);
        return result;
    }
    
    private void PreorderDFS(TreeNode root, IList<int> result){
        if(root==null)
            return;
        result.Add(root.val);
        PreorderDFS(root.left,result);
        PreorderDFS(root.right,result);
    }
}

//Solution2: Iterative 
public class Solution {
    public IList<int> PreorderTraversal(TreeNode root) {
        List<int> result = new List<int>();
        if(root == null) return result;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while(stack.Count!=0){
            TreeNode current = stack.Pop();
            result.Add(current.val);
            if(current.right!=null)
                stack.Push(current.right);
            if(current.left!=null)
                stack.Push(current.left);
        }
        return result;
    }
}
