/**
 * Given a binary tree where all the right nodes are either empty or leaf nodes, flip it upside down
 * and turn it into a tree with left leaf nodes.
 * In the original tree, if a node has a right child, it also must have a left child.
 *
 * for example, turn these:
 *
 *        1                1
 *       / \              / \
*      2   3            2   3
*     /
*    4
 *   / \
*  5   6
*
* into these:
*
*        1               1
*       /               /
*      2---3           2---3
*     /
*    4
 *   /
*  5---6
 *
 * where 5 is the new root node for the left tree, and 2 for the right tree.
 * oriented correctly:
 *
 *     5                  2
 *    / \                / \
*   6   4              3   1
*        \
*         2
*        / \
*       3   1
*
*/


using System;
using System.Collections.Generic;

namespace ReverseTree
{

	public class TreeNode
	{
		public TreeNode Left { get; set;}
		public TreeNode Right { get; set;}
		public int Value{ get; private set;}
		public TreeNode(int value)
		{
			this.Value = value;
			this.Left = null;
			this.Right = null;
		}

	}

	public class Reverser
	{
		public TreeNode ReverseTree(TreeNode root)
		{
			if (root == null)
				return null;
			Stack<TreeNode> treeStack = new Stack<TreeNode> ();
			TreeNode newRoot = null;
			while (root != null) {
				treeStack.Push (root);
				newRoot = root;
				root = root.Left;
			}

			TreeNode deepLeft = newRoot;
			TreeNode temp, right;
			treeStack.Pop ();
			while (treeStack.Count != 0) {
				temp = treeStack.Pop ();
				right = temp.Right;
				deepLeft.Right = temp;
				deepLeft.Left = right;

				deepLeft = temp;
			}

			return newRoot;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			TreeNode root = new TreeNode (1);
			TreeNode nodeA = new TreeNode(2);
			TreeNode nodeB = new TreeNode (3);
			TreeNode nodeC = new TreeNode(4);
			TreeNode nodeD = new TreeNode (5);
			TreeNode nodeE = new TreeNode(6);

			root.Left = nodeA;
			root.Right = nodeB;
			nodeA.Left = nodeC;
			nodeC.Left = nodeD;
			nodeC.Right = nodeE;

			Reverser reverser = new Reverser ();
			TreeNode newRoot = reverser.ReverseTree (root);

			Console.WriteLine (newRoot.Value + " " + newRoot.Left.Value + " " + newRoot.Right.Value);
			Console.WriteLine (newRoot.Right.Right.Value + " " + newRoot.Right.Right.Left.Value + " " + newRoot.Right.Right.Right.Value);
		}
	}
}
