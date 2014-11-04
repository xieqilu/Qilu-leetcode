//determine if a binary tree is a binary search tree.
using System;

namespace DeterminBST
{

	class TreeNode
	{
		public TreeNode Left{ get; set;}
		public TreeNode Right{ get; set;}
		public int Value{ get; private set;}
		public TreeNode(int value)
		{
			this.Value = value;
			this.Left = null;
			this.Right = null;
		}
	}

	class Checker
	{
		private bool IsBSTHelper(TreeNode root, int high, int low)//Time: O(n) Space: O(1)
																  //visit each node only once	
		{
			if (root == null)
				return true; //must return true
			if (root.Value < high && root.Value > low)
				return (IsBSTHelper (root.Left, root.Value, low) && IsBSTHelper (root.Right, high, root.Value));
			else
				return false;
		}

		public bool IsBST(TreeNode root)
		{
			if (root == null)
				return false; //edge case: root == null
			int high = Int32.MaxValue;
			int low = Int32.MinValue;
			return IsBSTHelper (root, high, low);
		}

		private bool InOrderHelper(TreeNode root, int prev)//Time: O(n) Space:O(1)
		{												  // In order Travesal of a binary search tree
			if (root == null)							  // will output the node value strictly in increasing order!
				return true;							  
			if (InOrderHelper (root.Left, prev)) {
				if (root.Value > prev) {
					prev = root.Value;
					return InOrderHelper (root.Right, prev);
				} else
					return false;
			} else
				return false;
		}

		public bool IsBSTInOrder(TreeNode root)
		{
			if (root == null)
				return false;
			int prev = Int32.MinValue;
			return InOrderHelper (root, prev);
		}
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
			//construct a binary search tree
			TreeNode root = new TreeNode (5);
			TreeNode nodeA = new TreeNode (3);
			TreeNode nodeB = new TreeNode (6);
			TreeNode nodeC = new TreeNode (7);
			TreeNode nodeD = new TreeNode (8);
			TreeNode nodeE = new TreeNode (4);
			TreeNode nodeF = new TreeNode (2);

			root.Left = nodeA;
			root.Right = nodeC;
			nodeA.Left = nodeF;
			nodeA.Right = nodeE;
			nodeC.Left = nodeB;
			nodeC.Right = nodeD;

			Checker checker = new Checker ();
			Console.WriteLine(checker.IsBST (root));
			Console.WriteLine (checker.IsBSTInOrder (root));
		}
	}
}
