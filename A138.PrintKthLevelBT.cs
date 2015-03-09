//Print Nodes at Kth Level of a Binary Tree (Print Nodes at K distance from root of Binary Tree)

/**
 * Given a binary tree, print Nodes at kth level. (k may start from 0 or 1, logic is the same)
For example:
Given binary tree {3,9,20,#,#,15,7},
    3
   / \
  9  20
    /  \
   15   7

Given k as 2, the result is:
9 20

Give k as 3, the result is:
15 7

If kth level is out of scope, print nothing.

 * Definition for binary tree
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */

/**
Solution:
Use the same solution as Print Binary Tree Level order. 
Use two queues to do an iterative BFS on the Tree and use an Integer
to keep track of kth level of Nodes. Then only print the kth level of
nodes.
*/


using System;
using System.Collections.Generic;

namespace PrintBinaryTree
{
	class MainClass
	{
		public class TreeNode
		{
			public int value { get; private set;}
			public TreeNode Left { get; set;}
			public TreeNode Right { get; set;}

			public TreeNode (int value, TreeNode left, TreeNode right)
			{
				this.value = value;
				this.Left = left;
				this.Right = right;
			}

			public TreeNode (int value)
			{
				this.value = value;
				this.Left = null;
				this.Right = null;
			}
		}

		public class TreePrinter
		{
			//generic method to swap two items
			public static void Swap<T> (ref T lhs, ref T rhs)
			{
				T temp;
				temp = lhs;
				lhs = rhs;
				rhs = temp;
			}

			//Print Nodes at kth level of Binary Tree
			public void PrintKthLevel(TreeNode root, int k){
				if (root == null)
					return;
				Queue<TreeNode> currentLevel = new Queue<TreeNode> ();
				Queue<TreeNode> nextLevel = new Queue<TreeNode> ();
				int level = 1; //if level starts from 0, set int level = 0;
				currentLevel.Enqueue (root);
				while (currentLevel.Count != 0) {
					TreeNode currentNode = currentLevel.Dequeue ();
					if (currentNode != null) {
						if (level == k)
							Console.Write (currentNode.value + " ");
						nextLevel.Enqueue (currentNode.Left);
						nextLevel.Enqueue (currentNode.Right);
					}
					if (currentLevel.Count == 0) {
						level++;
						Swap (ref currentLevel, ref nextLevel);
					}
				}
			}

			/*
			//use two queues
			public void PrintLevel(TreeNode root) 
			{
				if (root == null)
					return;
				Queue<TreeNode> currentLevel = new Queue<TreeNode> ();
				Queue<TreeNode> nextLevel = new Queue<TreeNode> ();
				currentLevel.Enqueue (root);
				while (currentLevel.Count != 0) {
					TreeNode currentNode = currentLevel.Peek ();
					currentLevel.Dequeue ();
					if (currentNode != null) {
						Console.Write (currentNode.value + " ");
						nextLevel.Enqueue(currentNode.Left);
						nextLevel.Enqueue(currentNode.Right);
					}
					if (currentLevel.Count == 0) {
						Console.WriteLine ("");
						Swap (ref currentLevel, ref nextLevel);
					}
				}

			}

			//use only one queue and two variables
			public void newPrintLevel(TreeNode root) 
			{
				if (root == null)
					return;
				Queue<TreeNode> treeNodes = new Queue<TreeNode> ();
				int currentNodes = 1;
				int nextNodes = 0;
				treeNodes.Enqueue (root);
				while (treeNodes.Count != 0) {
					TreeNode currentNode = treeNodes.Peek ();
					treeNodes.Dequeue ();
					currentNodes--;
					if (currentNode != null) {
						Console.Write (currentNode.value + " ");
						treeNodes.Enqueue (currentNode.Left);
						treeNodes.Enqueue (currentNode.Right);
						nextNodes += 2;
					}
					if (currentNodes == 0) {
						Console.WriteLine ("");
						currentNodes = nextNodes;
						nextNodes = 0;
					}
				}
			}
			*/
		}

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

			Node1.Left = Node2;
			Node1.Right = Node3;
			Node3.Left = Node4;
			Node3.Right = Node5;
			Node4.Left = Node6;
			Node4.Right = Node7;
			Node5.Left = Node8;


			TreePrinter printer = new TreePrinter ();

			//printer.PrintLevel (Node1);
			//printer.newPrintLevel (Node1);
			printer.PrintKthLevel (Node1,1);
			Console.WriteLine (" ");
			printer.PrintKthLevel (Node1,3);
			Console.WriteLine (" ");
			printer.PrintKthLevel (Node1,4);
		}
	}
}
