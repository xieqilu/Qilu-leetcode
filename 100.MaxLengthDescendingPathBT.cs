/** 
A binary tree consisting of N nodes is given. We say that a node T has a left descendant(or, conversely, aright descendant)
if the value of the attribute l(or, conversely, attributer) is a value other than NULL.
	A descending path is a sequence of nodes of the tree such that each successive node is a descendant of the previous one. 
	The length of a descending path is the number of pointers it traverses; that is, the number of nodes it contains minus 1.
Assume that the following declarations are given:

struct tree {
	int x;
	struct tree * l;
	struct tree * r;
};

class tree{
	int x;
	tree l;
	tree r;
}

Write a function: int solution(struct tree * T);
that, given a binary tree, returns the maximum length of a descending path that always goes to the left or always to the right.
*/

/**
Recursive Solution:
For every Node, we want to know three values:
1,the length of the left path starting at that node,
2,the length of the right path starting at that node, and
3,the length of the longest path starting at that node or one of its descendants.

For each recursive call, we need to return the above three values to its parent call.
So we need to build a new class that contains these three values and for each recursive
call, we return an objec of the class.

Base case: for any leaf node, the above three values are all zero.
*/




using System;
using System.Collections.Generic;

namespace MaxLengthDescendingPathBT
{
	class tree{
		public int x{ get; set;}
		public tree l{ get; set;}
		public tree r{ get; set;}
		public tree(int x){  //for test use only
			this.x = x;
			this.l = null;
			this.r = null;
		}
	}

	class Result{   //class contains return information for recursive call
		public int leftLength{ get; set;}
		public int rightLength{ get; set;}
		public int maxLength{get;set;}
		public Result(int l, int r, int m){
			this.leftLength = l;
			this.rightLength = r;
			this.maxLength = m;
		}
	}

	class Finder{

		private static Result FindPath(tree node){ //find the number of nodes on the longest path
			if (node == null)  //handle edge case
				return new Result (0, 0, 0);
			Result leftResult = FindPath (node.l);
			Result rightResult = FindPath (node.r);
			int leftLength = leftResult.leftLength + 1;
			int rightLength = rightResult.rightLength + 1;
			int maxLength = Math.Max (Math.Max (leftLength, rightLength),
								Math.Max (leftResult.maxLength, rightResult.maxLength));
			return new Result (leftLength, rightLength, maxLength);
		}

		public static int FindLongestPath(tree root){
			Result result = FindPath (root);
			return result.maxLength-1; //length of path is the number of nodes minus 1, do not forget this!
		}
			
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			tree node1 = new tree (5);
			tree node2 = new tree (2);
			tree node3 = new tree (15);
			tree node4 = new tree (10);
			tree node5 = new tree (6);
			tree node6 = new tree (14);
			node1.l = node2;
			node1.r = node3;
			node3.l = node4;
			node4.l = node5;
			node4.r = node6;
			Console.WriteLine (Finder.FindLongestPath (node1)); //2

		}
	}
}
