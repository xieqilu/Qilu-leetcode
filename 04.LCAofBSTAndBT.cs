/**
 * //Given two nodes of a Binary Search Tree
//Find the Lowest Common Ancestor of the
//given two nodes

Find LCA of Two nodes in a Binary Tree:

We traverse from the bottom, and once we reach a node which matches one of the two nodes, 
we pass it up to its parent. The parent would then test its left and right subtree checking
if each contain one of the two nodes. 
If yes, then the parent must be the LCA and we pass its parent up to the root. 
If not, we pass the lower node which contains either one of the two nodes (if the left or right subtree contains either p or q),
or NULL (if both the left and right subtree does not contain either p or q) up.

*/

using System;

namespace LowestCommonAncestorBST
{
	class MainClass
	{
		public class TreeNode
		{
			public int Value{ get; private set;}
			public TreeNode Left { get; private set;}
			public TreeNode Right { get; private set;}

			public TreeNode(int value, TreeNode left, TreeNode right)
			{
				this.Value = value;
				this.Left = left;
				this.Right = right;
			}

			public TreeNode (int value)
			{
				this.Value = value;
				this.Left = null;
				this.Right = null;
			}
		}

		public class Finder
		{
			//Recursive solution for BST, Time: O(h), h is the height of BST, O(logn), n is the number of nodes of BST
			public static TreeNode FindLCAForBST(TreeNode root, TreeNode p, TreeNode q) //Find Lowest Common Ancestor(LCA) of a binary search tree
			{
				if (root == null || p == null || q == null)
					return null;
				if (p.Value<root.Value && q.Value<root.Value) //if p,q are both at the left subtree of root
					return FindLCAForBST (root.Left, p, q);
				else if (p.Value>root.Value && q.Value>root.Value)// if p,q are both at the rifht subtree of root
					return FindLCAForBST (root.Right, p, q);					
				else                    // if p and q are at different side of root or one of them is root itself
					return root;
			}

			//Iterative solution for BST, Time: O(h), h is the height of BST, O(logn), n is the number of nodes of BST
			public static TreeNode FindLCAIterBST(TreeNode root, TreeNode p, TreeNode q){
				if (root == null || p == null || q == null)
					return null;
				while (root != null) {
					if (p.Value < root.Value && q.Value < root.Value)
						root = root.Left;
					else if (p.Value > root.Value && q.Value > root.Value)
						root = root.Right;
					else
						return root;
				}
				return null;
			}

			//Recursive solution for BT, time: O(h), h is the height, O(logn), n is the number of nodes
			public TreeNode FindLCAForBT(TreeNode root, TreeNode p, TreeNode q) //find lowest common ancestor of a Binary Tree
			{
				if(root == null || p == null || q == null)
					return null;
				if (root == p || root == q)
					return root;
				else {
					TreeNode l = FindLCAForBT (root.Left, p, q); //try to get LCA of p,q in left subtree
					TreeNode r = FindLCAForBT (root.Right, p, q); //try to get LCA of p,q in right subtree
					if (l != null && r != null) //p,q are at different sides of root
						return root;
					else if (l == null) //p,q are both at the right side of root
						return r;
					else
						return l; //p,q are both at the left side of root

				}
			}
		}

		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
		}
	}
}
