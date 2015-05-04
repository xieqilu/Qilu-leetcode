//determine if a binary tree is a binary search tree.
using System;

namespace DeterminBST
{

	public class TreeNode
	{
		public TreeNode left{ get; set;}
		public TreeNode right{ get; set;}
		public int val{ get; private set;}
		public TreeNode(int val)
		{
			this.val = val;
			this.left = null;
			this.right = null;
		}
	}

	public class Solution1 {
		//private object prev;
		public static bool IsValidBST(TreeNode root) {
			if(root==null)
				return true;
			//Note: do not use Int32.MinValue, because the value of node could be Int32.MinValue also!!!
			//Instead, use an object to box the int value. Then we can use null to distinguish the initial value.
			object prev=null; 
			return IsValidBSTHelper(root,ref prev);
		}
		private static bool IsValidBSTHelper(TreeNode root,ref object prev){ //Note: must pass by reference to make prev consistant
			if(root == null) return true; //null is a valid BST
			if(IsValidBSTHelper(root.left,ref prev)){
				if(prev==null || root.val>(int)prev){ //unbox prev to get its int value
					prev = root.val;
					return IsValidBSTHelper(root.right,ref prev);
				}
				return false;
			}
			return false;
		}
	}

	public class Solution2 {
		public static bool IsValidBST(TreeNode root) {
			//Do not use Int32.MaxValue and Int32.MinValue, becasue the value of tree node may be these two values too.
			//Instead use object to box int value and pass two null objects as initial value.
			return IsValidBSTHelper(root, null, null); 
		}

		private static bool IsValidBSTHelper(TreeNode p, object low, object high) {
			if (p == null) return true;
			return (low == null || p.val > (int)low) && (high == null || p.val < (int)high) //unbox object when comparing value
				&& IsValidBSTHelper(p.left, low, (object)p.val) //box int and pass the object
				&& IsValidBSTHelper(p.right, (object)p.val, high); //box int and pass the object
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

			root.left = nodeA;
			root.right = nodeC;
			nodeA.left = nodeF;
			nodeA.right = nodeE;
			nodeC.left = nodeB;
			nodeC.right = nodeD;

			//The two solutions are already tested by all Leetcode test cases!!!
			Console.WriteLine(Solution1.IsValidBST(root));//true
			Console.WriteLine (Solution2.IsValidBST (root)); //true
		}
	}
}
