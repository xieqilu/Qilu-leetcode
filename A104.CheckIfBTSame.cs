/**
 * Given two binary trees, write a function to check if they are equal or not.

Two binary trees are considered equal if they are structurally identical and the nodes have the same value.

Solution:
Use Pre-Order Traversal to compare if two tress are the same. 
Do not use In-Order Traversal because two different trees may produce
the same node list by In-order Traversal.

Note: We do not need to use two Lists to store all the nodes of two BT, because 
we are not required to seariliaze the two BT. we can just compare node in the steps
of Pre-Order traversal.
*/

using System;

namespace CheckIfBTIsSame
{

//Definition for Bianry Tree
 	public class TreeNode {
     	public int val;
    	public TreeNode left;
    	public TreeNode right;
    	public TreeNode(int x) { val = x; }
	}

	public class Solution {
		public bool IsSameTree(TreeNode p, TreeNode q) {
			if (p == null && q == null)
				return true;
			if (p == null || q == null) //p==null,q!=null OR p!=null,q==null
				return false;
			//Recursively compare left subtree and right subtree to see if they are the same
			return p.val == q.val && IsSameTree (p.left, q.left) && IsSameTree (p.right, q.right);
		}
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
		//The code is tested by LeetCode test cases
			Console.WriteLine ("Hello World!");
		}
	}
}
