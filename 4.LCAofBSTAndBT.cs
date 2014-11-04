//Given two nodes of a Binary Search Tree
//Find the Lowest Common Ancestor of the
//given two nodes

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
			public TreeNode FindLCA(TreeNode root, TreeNode p, TreeNode q) //Find Lowest Common Ancestor(LCA) of a binary search tree
			{
				if (root == null || p == null || q == null)
					return null;
				if (Math.Max (p.Value, q.Value) < root.Value) //if p,q are both at the left subtree of root
					return this.FindLCA (root.Left, p, q);
				else if (Math.Min (p.Value, q.Value) > root.Value)// if p,q are both at the rifht subtree of root
					return this.FindLCA (root.Right, p, q);					
				else                     // if p and q are at different side of root or one of them is root itself
					return root;
			}

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
					if (l == null) //p,q are both at the right side of root
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
