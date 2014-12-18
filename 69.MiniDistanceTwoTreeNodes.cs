//Find minimum distance between any 2 given nodes in Binary Tree

//First find the Lowest Common Ancestor of the 2 given nodes
//Then find the minimum distance between 2 nodes.
//The minimum path from one node to another must pass their lowest
//common ancestor


using System;
using System.Collections.Generic;
using System.Collections;

namespace MinimumDistanceTreeNodes
{
	public class TreeNode
	{
		public int Value{ get; private set;}
		public TreeNode Left { get;  set;}
		public TreeNode Right { get;  set;}

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
		public static TreeNode FindLCA(TreeNode root, TreeNode p, TreeNode q)
		{
			if(root == null || p == null || q == null)
				return null;
			if (root == p || root == q)
				return root;
			else {
				TreeNode l = FindLCA (root.Left, p, q); //try to get LCA of p,q in left subtree
				TreeNode r = FindLCA (root.Right, p, q); //try to get LCA of p,q in right subtree
				if (l != null && r != null) //p,q are at different sides of root
					return root;
				if (l == null) //p,q are both at the right side of root
					return r;
				else
					return l; //p,q are both at the left side of root
			}
		}


		public static int FindMinDis (TreeNode root, TreeNode p, TreeNode q)
		{
			TreeNode troot = FindLCA (root, p, q);
			int countp = FindLevelNum (troot, p);
			int countq = FindLevelNum (troot, q);
			return countp + countq;
		}

		public static void Swap<T> (ref T lhs, ref T rhs)
		{
			T temp;
			temp = lhs;
			lhs = rhs;
			rhs = temp;
		}

		public static int FindLevelNum(TreeNode root, TreeNode p) //use two queues
		{
			Queue<TreeNode> currentLevel = new Queue<TreeNode> ();
			Queue<TreeNode> nextLevel = new Queue<TreeNode> ();
			int count = 0;
			currentLevel.Enqueue (root);
			while (currentLevel.Count != 0) {
				TreeNode currentNode = currentLevel.Peek ();
				currentLevel.Dequeue ();
				if (currentNode != null) {
					if (currentNode == p) {
						return count;
					}
					nextLevel.Enqueue(currentNode.Left);
					nextLevel.Enqueue(currentNode.Right);
				}
				if (currentLevel.Count == 0) {
					count++;
					Swap (ref currentLevel, ref nextLevel);
				}
			}
			return 0;

		}
			
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			TreeNode Node1 = new TreeNode (3);
			TreeNode Node2 = new TreeNode (9);
			TreeNode Node3 = new TreeNode (20);
			TreeNode Node4 = new TreeNode (15);
			TreeNode Node5 = new TreeNode (17);
			TreeNode Node6 = new TreeNode (11);
			TreeNode Node7 = new TreeNode (13);
			TreeNode Node8 = new TreeNode (71);

			Node1.Left = Node2;
			Node1.Right = Node3;
			Node3.Left = Node4;
			Node3.Right = Node5;
			Node4.Left = Node6;
			Node4.Right = Node7;
			Node5.Left = Node8;

			Console.WriteLine (Finder.FindMinDis (Node1, Node5, Node6));
		}
	}
}
