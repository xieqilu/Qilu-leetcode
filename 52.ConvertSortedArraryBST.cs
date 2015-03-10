//Given an array where elements are sorted in ascending order, 
//convert it to a height balanced BST.
//
//A height-balanced tree is a tree whose subtrees differ in 
//height by no more than one and the subtrees are height-balanced, too.

//This is a classic Recursive Question

//Pick the middle element as the root, then do recursive call
//with the left and right subarray


/**
 * Given an array where elements are sorted in ascending order, 
 * convert it to a height balanced BST.
 * 
 * 
 * Special Note: got this problem in a phone interview, but failed to find the correct
 * base case for the recursive call. A very stupid confusion and mistake, shows I do not
 * understand recrusion completely. So this problem is an important reminder that reminds
 * me to studay harder, remember god has a bigger plan, better than mine.
 * 
 * 
 * Solution:
 * The recursive logic is very simple, pick the middle element of the array, use it as the 
 * root, then recursivly pick the middle of left part and the middle of right part to construct
 * the binary tree.
 * 
 * Pay attention to the base case for the recurisve call. When should the recursive call return?
 * How to avoid Stack Overflow? The base case is when start>end we need to return null. Notice that
 * for each recursive call, we need to get the middle element as num[(start+end)/2]. As long as start
 * is not greater than end, we can continue finding new node for the binary tree. If start is equal 
 * to end, then there is still an element to visit in the part of the array.
 * 
 * The base case is very similiar to a binary search, we need an array, an int start and an int end to 
 * perform the binary search. And for each recursive call, we pick a half of the array to continue. So
 * when start>end, that means the search should be over.
 * 
 * Just remember!!!!! THE BASE CASE IS START>END, RETURN NULL!!!!
 * */

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
