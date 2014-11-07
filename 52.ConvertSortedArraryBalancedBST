//Given an array where elements are sorted in ascending order, 
//convert it to a height balanced BST.
//
//A height-balanced tree is a tree whose subtrees differ in 
//height by no more than one and the subtrees are height-balanced, too.

//This is a classic Recursive Question

//Pick the middle element as the root, then do recursive call
//with the left and right subarray

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ConvertSortedArrayBalancedBST
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
		public static TreeNode Convert(int[] input)
		{
			return ConvertHelper (input, 0, input.Length - 1);
		}

		public static TreeNode ConvertHelper(int[] input, int start, int end)
		{
			if (input.Length == 0) //if input array is empty
				return null;
			if (start > end) 
				return null;
			int mid = (start + end) / 2;
			TreeNode root = new TreeNode (input [mid]);
			root.Left = ConvertHelper (input, start, mid - 1);
			root.Right = ConvertHelper (input, mid + 1, end);
			return root;
		}

		//print Binary Tree to test result
		public static void Swap<T> (ref T lhs, ref T rhs)
		{
			T temp;
			temp = lhs;
			lhs = rhs;
			rhs = temp;
		}

		public static void PrintLevel(TreeNode root) //use two queues
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
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] test = new int[]{ 0, 1, 2, 3, 4, 5, 7, 8, 9, 10, 11 };
			TreeNode result = Finder.Convert (test);
			Finder.PrintLevel (result);
		}
	}
}
