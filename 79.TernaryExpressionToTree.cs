/**given a string that represents a ternary expression, 
parse it into a tree comprised of Node objects and 
return an Expression object that contains the pointer to the root node of the tree.

example: given string "a?b?c:d:e"
output: tree as follows
a
bc
de

Solution:
Scan the string in reverse order, use two int to count how many qustions mark and colon
have been scanned. 
for each char in the string, if it's a question mark, increment the count;
if it's a colon, increment the count;
if it's not question mark and colon, it must be a variable, so construct a node using
current variable.then we check if the number of question mark is 1 
&& if the number of colon is greater than 1.
if it is, then we pop the stack twice, construct two previous node.
Use current node as root, linke the root to the two poped node.
If it is not, we just push current node to the stack.

After the loop, we pop the stack and construct an expression using the poped node.
*/

using System;
using System.Collections.Generic;
using System.Collections;

namespace TernaryExpressionToTree
{
	class Node{
		public char variableName{ get; set;}
		public Node left{ get; set;}
		public Node right{ get; set;}
		public Node(char c){
			this.variableName = c;
			this.left = null;
			this.right = null;
		}
	}

	class Expression{
		public Node root{ get; set;}
		public Expression(Node n){
			this.root = n;
		}
	}

	class Finder{

		public static Expression Convert(string s){ //Convert Method
			Stack<Node> st = new Stack<Node> ();
			int CountQ = 0;
			int CountC = 0;
			for (int i = s.Length - 1; i >= 0; i--) {
				if (s [i] == ':')
					CountC++;
				else if (s [i] == '?')
					CountQ++;

				else {
					Node curr = new Node (s [i]);
					if (CountQ == 1 && CountC >= 1) {
						Node pre1 = st.Pop ();
						Node pre2 = st.Pop ();
						curr.left = pre1;
						curr.right = pre2;
						st.Push (curr);
						CountQ--;
						CountC--;
					} else
						st.Push (curr);
				}
			}
			Node root = st.Pop ();
			Expression e = new Expression (root);
			return e;
		}
			
	}

	//helper class to print and test the result
	class TreePrint{
		public static void Swap<T> (ref T lhs, ref T rhs)
		{
			T temp;
			temp = lhs;
			lhs = rhs;
			rhs = temp;
		}

		public static void PrintLevel(Node root) //use two queues
		{

			if (root == null)
				return;
			Queue<Node> currentLevel = new Queue<Node> ();
			Queue<Node> nextLevel = new Queue<Node> ();
			currentLevel.Enqueue (root);
			while (currentLevel.Count != 0) {
				Node currentNode = currentLevel.Peek ();
				currentLevel.Dequeue ();
				if (currentNode != null) {
					Console.Write (currentNode.variableName + " ");
					nextLevel.Enqueue (currentNode.left);
					nextLevel.Enqueue (currentNode.right);
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
			Expression e = Finder.Convert ("a?b?c:d:e");
			TreePrint.PrintLevel (e.root);
			Expression e1 = Finder.Convert ("a?b:c?d:e");
			TreePrint.PrintLevel (e1.root);
			Expression e2 = Finder.Convert ("a?b?c:d?e:f:g");
			TreePrint.PrintLevel (e2.root);
		}
	}
}
