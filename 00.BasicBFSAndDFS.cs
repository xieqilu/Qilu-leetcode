//implement basic BFS and DFS on a bianry tree

using System;
using System.Collections.Generic;
using System.Collections;

namespace BFSAndDFS
{
	public class TreeNode
	{
		public TreeNode left{ get; set;}
		public TreeNode right{get;set;}
		public int value{ get; private set;}
		public TreeNode(int value)
		{
			this.value = value;
			this.left = null;
			this.right = null;
		}
	}

	public class SearchTree
	{
		public static void DFS(TreeNode root)
		{
			if (root == null)
				return;
			Console.WriteLine (root.value);
			DFS (root.left);
			DFS (root.right);
		}

		public static void BFS(TreeNode root) // BFS == using a queue!!!!
		{
			Queue<TreeNode> nodeQueue = new Queue<TreeNode> ();
			Console.WriteLine (root.value);
			nodeQueue.Enqueue (root);

			while (nodeQueue.Count != 0) {
				TreeNode temp = nodeQueue.Dequeue ();
				if (temp.left != null) {
					Console.WriteLine (temp.left.value);
					nodeQueue.Enqueue (temp.left);
				}
				if (temp.right != null) {
					Console.WriteLine (temp.right.value);
					nodeQueue.Enqueue (temp.right);
				}
			}
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			//construct a simple binary tree using treenodes
			TreeNode Node1 = new TreeNode (3);
			TreeNode Node2 = new TreeNode (9);
			TreeNode Node3 = new TreeNode (20);
			TreeNode Node4 = new TreeNode (15);
			TreeNode Node5 = new TreeNode (17);
			TreeNode Node6 = new TreeNode (11);
			TreeNode Node7 = new TreeNode (13);
			TreeNode Node8 = new TreeNode (71);

			Node1.left = Node2;
			Node1.right = Node3;
			Node3.left = Node4;
			Node3.right = Node5;
			Node4.left = Node6;
			Node4.right = Node7;
			Node5.left = Node8;

			SearchTree.BFS (Node1);
			SearchTree.DFS (Node1);
		}
	}
}
