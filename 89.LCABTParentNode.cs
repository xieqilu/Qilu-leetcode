/**
 * Given a binary tree, 
 * find the lowest common ancestor of two given nodes in the tree. 
 * Each node contains a parent pointer which links to its parent.
 * 
 * Solution:
 * 
 * This problem is very similiar to find intersection of two LinkedLists.
 * 
 * Since we have the parent pointer, we can use it to get the height of two nodes.
 * If the two nodes have a lowest common ancestor, then the distance between the 
 * deeper node to LCA is longer than the upper one.
 * The distance difference is excatly the height difference of two nodes.
 * 
 * So we can get heights of both nodes and the height difference d.
 * Then we move the deeper node up for d level. 
 * Now the two nodes are at the same level of the tree.
 * Then we move both of the two nodes one level at a time.
 * Eventually they will meet at the LCA.
 * 
 * If they do not meet, that means they are not at the same tree,
 * then we return null.
 * */


using System;

namespace LCABTParentNode
{
	class Node{
		public Node parent{get;set;}
		public Node left {get;set;}
		public Node right { get; set;}
	}

	class Finder{
		private static int getHeight(Node node){
			int height = 0;
			while (node != null) {
				node = node.parent;
				height++;
			}
			return height;
		}

		private static Node getLCAHelper(int d, Node p, Node q){ //d=q-p, q is the deeper one, p is the upper one
			for (int i = 0; i < d; i++) {
				q = q.parent;
			}
			while (p != null && q != null) {
				if (p == q)
					return p;
				p = p.parent;
				q = q.parent;
			}
			return null;
		}

		public static Node getLCA(Node p, Node q){
			int pHeight = getHeight (p);
			int qHeight = getHeight (q);
			if (pHeight < qHeight)
				return getLCAHelper (qHeight - pHeight, p, q);
			else
				return getLCAHelper (pHeight - qHeight, q, p);
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
		}
	}
}
