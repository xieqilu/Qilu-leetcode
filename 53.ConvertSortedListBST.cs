//Given a singly linked list where elements are sorted in ascending order, 
//convert it to a height balanced BST.Given a singly linked list 
//where elements are sorted in ascending order, convert it to a height balanced BST.
//
//for lined list, we cannot access element in O(1), so we cannot use top-down approach
//We need to use bottom-up approach, using in-order(left-root-right) travesal to
//construct the balanced binary tree


using System;
using System.Collections.Generic;
using System.Collections;

namespace ConvertSortedListtoBalancedBST
{
	//Linked List Node class
	class Node
	{
		public int Value{get;private set;}
		public Node Next{get;set;}

		public Node(int value)
		{
			this.Value = value;
			this.Next = null;
		}
	}

	//TreeNode class
	class TreeNode
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
		public static TreeNode Convert(Node head)
		{
			int len =0;
			Node temp = head;
			while (temp != null) {
				len++;
				temp = temp.Next;
			}

			return ConvertHelper (ref head, 0, len - 1);
		}

		//recursive call. must pass reference of Node head,
		//to make it increment consistently to travese the linked list
		public static TreeNode ConvertHelper(ref Node head, int start, int end)
		{
			if (start > end)
				return null;
			int mid = (start + end) / 2;
			TreeNode left = ConvertHelper (ref head, start, mid - 1); //left child
			TreeNode root = new TreeNode (head.Value); //root
			root.Left = left;
			head = head.Next; //increment head to travese the list
			root.Right = ConvertHelper (ref head, mid + 1, end); //right child
			return root;
		}

		//print the BST to test result
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
			//Construct the test Linked List
			Node[] test = new Node[] {new Node (0), new Node (1), new Node (2), new Node (3), new Node (4),
				new Node (5), new Node (7), new Node (8), new Node (9), new Node (10), new Node (11)
			};

			for (int i = 0; i < test.Length-1; i++) {
				test [i].Next = test [i + 1];
			}

			//test result
			TreeNode result = Finder.Convert (test [0]);
			Finder.PrintLevel (result);
		}
	}
}
