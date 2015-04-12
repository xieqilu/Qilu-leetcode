/**
Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

For example, this binary tree is symmetric:

    1
   / \
  2   2
 / \ / \
3  4 4  3
But the following is not:
    1
   / \
  2   2
   \   \
   3    3
   
Note:
Bonus points if you could solve it both recursively and iteratively.


Idea:
Note that if a tree is symmetric, then each node at the left subtree will have a mirror
node at the right subtree. The only exception is the root node, which is shared by both subtrees.
So if we need a process to check the tree, we need to start from root.left and root.right instead
of root itself. Each time we will check a pair of nodes which supposed to be symmetric. 

Key point:
We solve this problem by checking pair of nodes repeatedly instead of level of nodes. If we have two
symmetric node p1 and p2, then p1.left and p2.right must be a symmetric pair and p1.right and p2.left
must also be a symmetric pair.


Solution1: Recursive
We can do this easily using recursive method (input nodes: p1, p2). Detail steps are as follows:
1 Base Case: if both p1 and p2 are null, return true.
             if only one of p1 and p2 is null, return false.
2 Then compare value of p1 and p2, and call recursivly for the pair of (p1.left,p2.right) and 
the pair of (p1.right,p2.left). Return accordingly.

Note the sequence of arguments are very important. p1.left and p2.right are a symmetric pair, and
p1.right and p2.left are a symmetric pair. As long as we maintain this sequence for each recursive
call, we will compare all pairs of symmetric nodes

Time Complexity: O(n)  


Solution2: Iterative BFS using Queue
The idea is the same: comparing all pairs of symmetric nodes.
We will use a queue to store all pairs of symmetric nodes. The key point is when pushing nodes into 
the queue, we need to make sure each pair of adjecent nodes are symmetric. And in the while loop,
each pass we will pop two nodes from the queue, compare them and then push two pair of symmetric nodes
into the queue for further comparision. The sequence of comparing pairs doesn't matter, as long as 
two symmetric nodes stay together in the queue, eventually we will compare all pair of them.

Detail steps:
1, before the loop, push root.left and root.right into the queue.
2, In the loop, pop two nodes from the queue, compare them.
3, if both are null, continue.
4, if not symmetric, return false.
5, push children nodes as the following sequence:
p1.left, p2.right, p1.right, p2.left

Time Complexity: O(n)


Solution3: Iterative DFS using Stack
In fact, we can also use a Stack to do the excatly same process. Although stack is LIFO, as long as
two symmetric nodes stay together in the stack, they will be poped together, too.

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

//Solution1: Recursive DFS Solution  Time: O(n)
public class Solution {
    public bool IsSymmetric(TreeNode root) {
        if(root==null)
            return true;
        return SymmetricHelper(root.left,root.right);
    }
    
    private bool SymmetricHelper(TreeNode p1, TreeNode p2){
        if(p1==null&&p2==null) //if both p1 and p2 are null
            return true;
        if(p1==null || p2==null) //if one of p1 and p2 is null and the other is not null
            return false;
        if(p1.val==p2.val && SymmetricHelper(p1.left, p2.right) 
                && SymmetricHelper(p1.right, p2.left))
            return true;
        return false;
    }
}


//Solution2: Iterative BFS using Queue  Time: O(n)
public class Solution {
    public bool IsSymmetric(TreeNode root) {
        if(root==null)
            return true;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root.left); //like recursion, start from root.left and root.right
        queue.Enqueue(root.right);
        while(queue.Count!=0){
            TreeNode p1 = queue.Dequeue();
            TreeNode p2 = queue.Dequeue();
            if(p1==null&&p2==null) //compare p1 and p2
                continue;
            if(p1==null||p2==null||p1.val!=p2.val)
                return false;
            queue.Enqueue(p1.left);
            queue.Enqueue(p2.right);
            queue.Enqueue(p1.right);
            queue.Enqueue(p2.left);
        }
        return true;
    }
}


//Solution3: Iterative DFS using Stack  Time: O(n)
public class Solution {
    public bool IsSymmetric(TreeNode root) {
        if(root==null)
            return true;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root.left); //like recursion, start from root.left and root.right
        stack.Push(root.right);
        while(stack.Count!=0){
            TreeNode p1 = stack.Pop();
            TreeNode p2 = stack.Pop();
            if(p1==null&&p2==null) //compare p1 and p2
                continue;
            if(p1==null||p2==null||p1.val!=p2.val)
                return false;
            stack.Push(p1.left);
            stack.Push(p2.right);
            stack.Push(p1.right);
            stack.Push(p2.left);
        }
        return true;
    }
}

