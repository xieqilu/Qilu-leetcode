//Given a Binary Tree, find its Maximum Height

//The maximum height of a binary tree is defined as 
//the number of nodes along the path from the root node to the deepest leaf node. 
//Note that the maximum height of an empty tree is 0.

//Recursive Approach is easy to implement but still need to know 
//how to do it recursivlly

using System;
using System.Collections.Generic;
using System.Collections;

namespace MaxHeightBT
{

	public class TreeNode
	{
		public int value { get; private set;}
		public TreeNode Left { get; set;}
		public TreeNode Right { get; set;}

		public TreeNode (int value)
		{
			this.value = value;
			this.Left = null;
			this.Right = null;
		}
	}

	class Finder
	{
		//recursive approach, easy
		public static int MaxHeightRecur(TreeNode root)
		{
			if (root == null)
				return 0;
			int leftHeight = MaxHeightRecur (root.Left);
			int rightHeight = MaxHeightRecur (root.Right);
			return (leftHeight > rightHeight) ? leftHeight + 1 : rightHeight + 1;
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

			Node1.Left = Node2;
			Node1.Right = Node3;
			Node3.Left = Node4;
			Node3.Right = Node5;
			Node4.Left = Node6;         
			Node4.Right = Node7;
			Node5.Left = Node8;

			Console.WriteLine (Finder.MaxHeightRecur (Node1));
		}
	}
}
