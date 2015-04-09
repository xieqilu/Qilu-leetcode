/**
Implement an iterator over a binary search tree (BST). 
Your iterator will be initialized with the root node of a BST.

Calling next() will return the next smallest number in the BST.

Note: next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree.


Solution:
This problem is about the iterative in-order traversal of BST. Each time Next() will return the next 
smallest number in the BST. The in-order traversal of BST is an ascending sorted sequence. 
So what we need to do is a iterative in-order traversal of BST using Stack.

We don't need to push all nodes into Stack in the constructor. We can firstly push all nodes from root 
to leftmost node to the stack. Then in Next() method, after poping the next smallest node(p) from Stack, 
we treate p.right as the root and push all nodes from p.right to the leftmost node to Stack.

In detail, methods in BSTIterator are as follows:
Constructor: initialize Stack and push all nodes from root to the leftmost node into Stack.
bool HasNext(): return stack.Count>0.
int Next(): Pop Stack and get next smallest node p. Get p.val as result. Then update p=p.right.
Push all nodes from p to the leftmost node to stack. Then return result.

这是一道很经典的题目，考的非递归的中序遍历。其实这道题等价于写一个二叉树中序遍历的迭代器。
需要内置一个栈，一开始先存储到最左叶子节点的路径。在遍历的过程中，只要当前节点存在右孩子，
则进入右孩子，存除从此处开始到当前子树里最左叶子节点的路径。

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

public class BSTIterator {
    private Stack<TreeNode> stack;
    public BSTIterator(TreeNode root) {
        stack = new Stack<TreeNode>();
        while(root!=null){ //the last pushed node is the leftmost node of the tree
            stack.Push(root);
            root=root.left;
        }
    }

    /** @return whether we have a next smallest number */
    public bool HasNext() {
        return stack.Count>0;
    }

    /** @return the next smallest number */
    public int Next() {
        TreeNode p = stack.Pop(); //pop the stack
        int result = p.val; //get result
        p = p.right;
        while(p!=null){
            stack.Push(p);
            p=p.left;
        }
        return result;
    }
}

/**
 * Your BSTIterator will be called like this:
 * BSTIterator i = new BSTIterator(root);
 * while (i.HasNext()) v[f()] = i.Next();
 */
