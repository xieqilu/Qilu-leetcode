/**
 * You have a BST where each node has pointers to its two children AND to its parent. 
Given a node in the BST, find the next largest node in the BST, 
e.g. if all the nodes were sorted by value in ascending order, 
it would be the next on the sorted list.
Assume that all node values in the tree are unique--no repeats.
Assume that the node given is guaranteed to be somewhere in the BST.

struct Node {
    Node *left;
    Node *right;
    int value;
}
And here's what the function looks like:

Node *nextLargestNode(Node *n, Node *root);

*/


using System;

namespace NextLargestNodeInBST
{
	class Node{
		public int data;
		public Node left;
		public Node right;
		public Node parent;
	}

	class TNode{
		public int data;
		public Node left;
		public Node right;
	}

	class MainClass
	{
		class Finder{
			//find next largest node using parent pointer
			public static Node nextLargest(Node n, Node root){

				//if n.right exist, then find the min node in its right subtree
				if (n.right != null)
					return MinValue (n.right);

				//if not, loop up to find a node which is the left child of its parent
				//the parent is the next largest node
				Node p = n.parent;
				while (p != null && n == p.right) {
					n = p;
					p = p.parent;
				}
				return p;
			}

			private static Node MinValue(Node root){
				Node n = root;

				/* loop down to find the leftmost leaf */
				while (n != null) {
					n = n.left;
				}

				return n;
			}


			//find next largest node without parent pointer
			public static TNode LargestNoParent(TNode n, TNode root){

				//same as above
				if (n.right != null)
					return MinValue (n.right);

				Node parent = null;


				//if n is greater than root, go left
				//if n is less than root, go right
				//if n is equal to root, return parent
				while (root != null) {
					if (n.data < root.data) {
						parent = root;
						root = root.left;
					} else if (n.data > root.data)
						root = root.right;
					else
						break;
				}
				return parent;
			}

		}

		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
		}
	}
}
