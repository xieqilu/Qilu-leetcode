//Print a Binary Tree Level by Level

/**
 * Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

For example:
Given binary tree {3,9,20,#,#,15,7},
    3
   / \
  9  20
    /  \
   15   7
return(print) its level order traversal as:
[
  [3],
  [9,20],
  [15,7]
]

/**
 * Definition for binary tree
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */

/**
* java is always pass by value, even if we pass an object,
	* we actually pass the value of the object reference.
* Which means if we change the object itself in the method,
	* the change is visible to the caller.
* But if we let the reference point to another object,
	* the change is not visible to the caller.
	* 
	* In the following code:
	* when we want to add currentNodes to allNodes and then clear
* currentNodes, if we directly add currentNodes to allNodes and then
	* call currentNodes.clear(). The list added to allNodes will be cleared.
	* Because by add currentNodes to allNodes, we actually add the reference
	* to allNodes. So use reference to clear the object will change the object
	* in allNodes.
	* To avoid this problem, we need copy elements of currentNodes to a temp list
	* and then add the temp list to allNodes.
	* 
	* In C#, when passing object, default situation is the same as in Java. That is,
	* we actually pass the value of the object reference. If we use ref or out when passing
* object, then we actually pass the reference of object reference. Then if we let
	* the reference point to another object, the change is visible to the caller.
	* */


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

			public void PrintLevel(TreeNode root) //use two queues
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

			public void newPrintLevel(TreeNode root) //use only one queue and two variables
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

			printer.PrintLevel (Node1);
			printer.newPrintLevel (Node1);
		}
	}
}
