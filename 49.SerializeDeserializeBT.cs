//Design an algorithm and write code to serialize and deserialize a binary tree. 
//Writing the tree to a file is called ‘serialization’ 
//and reading back from the file to reconstruct the exact same binary tree is ‘deserialization’.

//In this code, we serialize the tree to a string
//and deserialize a tree from a string

//we use the print BT by level order method to
//test the result


using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace SerializeDeserializeTree
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
		public static string Serialization(TreeNode root)
		{
			//use StringBuilder to build string, after
			//the recursive call, convert it to string
			StringBuilder sb = new StringBuilder (); 
			SerializationHelper (root, sb);
			return sb.ToString ();
		}

		//pre-order traversal
		private static void SerializationHelper(TreeNode root, StringBuilder sb)
		{
			if (root == null) {
				sb.Append ('#' + " ");
				return;
			}
			//output.Add (root.value + '0'); //only works for single digit int
			sb.Append (root.value + " ");
			SerializationHelper (root.Left, sb);
			SerializationHelper (root.Right, sb);
		}

		public static TreeNode Deserialization(string output)
		{
			string[] strArr = output.Split (' ');
			int start = 0;
			TreeNode result = DeserializationHelper (strArr, ref start);
			return result;
		}

		//pre-order traversal. pass reference of index to make sure it increments consistently
		private static TreeNode DeserializationHelper(string[] output, ref int index)
		{
			if (index > output.Length - 1 || output [index] == "#")
				return null;
			TreeNode p = new TreeNode (Convert.ToInt32 (output [index]));
			index ++;
			p.Left = DeserializationHelper (output, ref index);
			index ++;
			p.Right = DeserializationHelper (output, ref index);
			return p;
		}

		//print Binary Tree to test deserialization
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

			//test serialization
			Console.WriteLine(Finder.Serialization (Node1));

			string treeStr = "3 9 # # 20 15 11 # # 13 # # 17 71 # # #";

			//test deserialization
			TreeNode newNode = Finder.Deserialization (treeStr);

			Finder.PrintLevel (newNode);
			//Console.WriteLine (newNode.Right.value);



		}
	}
}
