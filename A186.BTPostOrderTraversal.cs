/**
Given a binary tree, return the postorder traversal of its nodes' values.

For example:
Given binary tree {1,#,2,3},
   1
    \
     2
    /
   3
return [3,2,1].

Note: Recursive solution is trivial, could you do it iteratively?


Solution1: Recursive
It's very easy to implement postorder traversal recursively. Just do it.


Solution2: Iterative 
Key points:
1, We must use a stack to do this when there is no parent pointer. 
2, When dealing with the current node (stack.Peek()), we are possibly traversing down or traversing up.
So it's important that we can figure out whether we are traversing up or down. We can use a prev variable
to store the previous poped node, then according to the realtionship between prev and curr, we can determine
the current sequence of traversal.

Detail steps:
We use a prev variable to keep track of the previously-traversed node. 
Let’s assume curr is the current node that’s on top of the stack. 

1, When prev is curr‘s parent, we are traversing down the tree. 
In this case, we try to traverse to curr‘s left child if available (ie, push left child to the stack). 
If it is not available, we look at curr‘s right child. 
If both left and right child do not exist (ie, curr is a leaf node), we print curr‘s value and pop it off the stack.

2, If prev is curr‘s left child, we are traversing up the tree from the left.
We look at curr‘s right child. If it is available, then traverse down the right child 
(ie, push right child to the stack), otherwise add curr‘s value to result and pop it off the stack.

3, If prev is curr‘s right child, we are traversing up the tree from the right. 
In this case, we add curr‘s value to result and pop it off the stack.

Note: In this solution, the stack will at most store h nodes when h is the height of the tree. 
Because for a root, we will deal with all left nodes before starting pushing right nodes. The left and right
child of a same root won't be stored in the stack at the same time.

Time complexity: O(n)  Space Complexity: O(logn)/O(h)

Solution3: More concise Iterative  
Solution2 is easy to follow, but has some redundant code. 
We could refactor out the redundant code, and now it appears to be more concise. 
Note how the code section for adding curr‘s value get refactored into one single else block. 
Don’t worry about in an iteration where its value won’t get added, 
as it is guaranteed to enter the else section in the next iteration.

Note: in this solution, if curr is a leaf node or prev is the left child of curr and curr has no right child,
then in the next iteration, curr would be equal to prev, then it gonna enter the else block and curr will be
added to result and stack will be poped.

Time Complexity: O(n)  Space Complexity: O(logn)/O(h)

/**
 * Definition for binary tree
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */


//Solution1: Recursive Solution, trivial  Time: O(n)
public class Solution {
    public IList<int> PostorderTraversal(TreeNode root) {
        IList<int> result = new List<int>();
        if(root==null) return result;
        PostDFS(root,result);
        return result;
    }
    
    private void PostDFS(TreeNode root, IList<int> result){
        if(root==null) //base case
            return;
        PostDFS(root.left, result);
        PostDFS(root.right, result);
        result.Add(root.val);
    }
}


//Solution2: Iterative, use stack and prev variable  Time:O(n)  Space: O(logn)/O(h)
public class Solution {
    public IList<int> PostorderTraversal(TreeNode root) {
        IList<int> result = new List<int>();
        if(root==null) return result;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        TreeNode prev = null;
        while(stack.Count!=0){
            TreeNode curr = stack.Peek();
            if(prev==null||prev.left==curr||prev.right==curr){ //curr is prev's child, traversing down
                if(curr.left!=null)
                    stack.Push(curr.left);
                else if(curr.right!=null)
                    stack.Push(curr.right);
                else{  //if curr is a leaf node
                    result.Add(curr.val);
                    stack.Pop();
                }
            }
            else if(curr.left==prev){ //prev is curr's left child, traversing up
                if(curr.right!=null) //if curr has right child, traverse its right subtree
                    stack.Push(curr.right);
                else{
                    result.Add(curr.val);
                    stack.Pop();
                }
            }
            else{ //prev is curr's right child, traversing up
                result.Add(curr.val);
                stack.Pop();
            }
            prev=curr;
        }
        return result;
    }
}


//Solution3: more concise iterative solution  Time: O(n)  Space: O(logn)/O(h)
public class Solution {
    public IList<int> PostorderTraversal(TreeNode root) {
        IList<int> result = new List<int>();
        if(root==null) return result;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        TreeNode prev = null;
        while(stack.Count!=0){
            TreeNode curr = stack.Peek();
            if(prev==null||prev.left==curr||prev.right==curr){ //curr is prev's child, traversing down
                if(curr.left!=null)
                    stack.Push(curr.left);
                else if(curr.right!=null)
                    stack.Push(curr.right);
            }
            else if(curr.left==prev){ //prev is curr's left child, traversing up
                if(curr.right!=null) //if curr has right child, traverse its right subtree
                    stack.Push(curr.right);
            }
            else{ //prev==curr or prev is curr's right child
                result.Add(curr.val);
                stack.Pop();
            }
            prev=curr;
        }
        return result;
    }
}
