/**
Get nth smallest element in a Binary Search Tree

Solution1: No need to modify TreeNode class
Since the in-order traversal of BST is ascending sorted sequence, we can do an 
iterative in-order traversal using a Stack. Use an integer to count the number of
nodes poped from stack, when count==n, stop and return the current poped node.

Detail steps:
1, push all nodes from root to the leftmost node into stack
2, use a while loop to pop node from stack, in the while loop:
pop a node p from stack and increment count. If count is equal to n, return p.
Otherwise, set p=p.right, while p!=null, push p to stack and update p as p.left.
(treate p.right as root, push all nodes from this root to the leftmost node into stack)
The condition of while loop is stack is not empty.

Time: O(n)  n is the number of nodes in the tree
Space: O(n)


Solution2: need to modify TreeNode class
The idea is to maintain rank of each node. 
We can keep track of elements in a subtree of any node while building the tree. 
Since we need K-th smallest element, we can maintain number of elements of left subtree in every node.

Assume that the root is having N nodes in its left subtree. 
If N = K-1, root is the K-th node. 
If N > K-1, we continue our search (recursion) for the Kth smallest element in the left subtree of root. 
If N < K-1, we continue our search in the right subtree for the (K – N – 1)-th smallest element. 
Note that we need the count of elements in left subtree only.

Algorithm:
start:
if K = root.leftElement + 1
   root node is the K th node.
   goto stop
else if K > root.leftElements
   K = K - (root.leftElements + 1)
   root = root.right
   goto start
else
   root = root.left
   goto srart

stop: return current root

Time complexity: 
O(h) where h is height of tree. 
O(logn) n is the number of nodes of tree.

*/

using System;
using System.Collections.Generic;

public class TreeNode {
    public int val{get;set;}
    public TreeNode left{get;set;}
    public TreeNode right{get;set;}
    public TreeNode(int x) { val = x; }
}

public class Solution{
	//method using iterative in-order traversal
	//Time: O(n)  Space:O(n)
	public static TreeNode InOrderSolution(TreeNode root,int n){
		Stack<TreeNode> stack = new Stack<TreeNode>();
		int count=0;
		while(root!=null){
			stack.Push(root);
			root=root.left;
		}
		while(stack.Count>0){
			TreeNode p = stack.Pop();
			count++;
			if(count==n){
				return p;
			}
			p = p.right;
			while(p!=null){
				stack.Push(p);
				p=p.left;
			}
		}
		return null; //the number of nodes in tree is less than n
	}
}

public class Test
{
	public static void Main()
	{
		// your code goes here
		TreeNode node1 = new TreeNode(20);
		TreeNode node2 = new TreeNode(8);
		TreeNode node3 = new TreeNode(22);
		TreeNode node4 = new TreeNode(4);
		TreeNode node5 = new TreeNode(12);
		TreeNode node6 = new TreeNode(10);
		TreeNode node7 = new TreeNode(14);
		node1.left = node2;
		node1.right = node3;
		node2.left = node4;
		node2.right = node5;
		node5.left = node6;
		node5.right = node7;
		Console.WriteLine(Solution.InOrderSolution(node1,3).val);//10
		Console.WriteLine(Solution.InOrderSolution(node1,5).val);//14
	}
}
