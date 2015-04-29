/**
Given a list of numbers, determine whether it can represent the post-order traversal list of a binary search tree (BST).

Input Format:
First Line is the number of test cases.
Then for each test case, there are two lines:
First Line is the number of nodes in the postorder traversal array
Second Line is the postorder traversal array

Example Input:
3
7
1 4 3 8 6 9 5
5
1 1 1 1 1
7
1 4 3 11 12 9 5

Example OutPut:
True
False
True


Idea:
There are two important facts we need to know as follows:
1, We cannot construct a Binary Tree only using its PostOrder traversal list. There could be multiple binary trees that
have the same PostOrder traversl list. However, we can construct a BT using pre-in order traversal or in-post order traversal.
2, But if we are dealing with a Binary Search Tree, things are quite different. We can construct a BST using only Postorder 
traversal list. Because a BST is actually sorted, its inorder traversal is sorted, so a BST has a unique postorder traversal.

So a straightforward approach is to assume the given list is a post-order traversal of a BST and construct this BST. Then 
check if this BST is actually a valid BST, if it is, then return true. Otherwise return false. 

But the above approach is a little too complex, actually we don't need to really construct the BST. We can modify the method 
used to constructing BST and check if the list is a valid BST postorder traversal list recrusively.


Solution1:
1, Construct the BST using the given list of numbers, suppose it's the postorder traversal list.
2, Check if this BST is a valid BST. If it is, return true. Otherwise return false.
Note: Though this method is too complex and not the best for this problem, it consists two important sub-method 
to a) Construct a BST from postorder traversal and b) validate a BST.

Time complexity:
Construct BST: O(nlogn)  Validate BST: O(n)
Overall: O(nlogn)

Space complexity: O(n)  needs to hold the entire BST


Solution2:
We don't need to actually construct the BST. We don't need any Node class. We can modify the method to construct BST a little
bit and recursively scan the whole array to check if it can be a valid BST postorder traversal.

Detail steps:
1, Use a private recursive helper method which takes three arguments: the array nodes[], int start, int end.
start and end set the current range of nodes in the array for current sub-tree.
2, In the helper method, if start<=end, that means this sub-tree is empty or has only one node, then it must be a valid BST.
So directly return true.
3, If start>end, first get the root value of current sub-tree which is the last node in current range, nodes[end]. Then traverse
back from nodes[end] to nodes[start] while i>=start && nodes[i]>nodes[end]. Then after the while loop, i will stay at the partition
point for the left and right sub-tree. In other words, i will be at the nearest node that is smaller than root, which is also
the last node in left sub-tree.
4, Then store the partition index i to another variable left and keep moving i to the left while i>=start && nodes[i]<nodes[end].
After the while loop, i should stay at the start-1 index. Because we just move i through all nodes belonging to left sub-tree.
5, Then check i to see if it is equal to start-1, if it's not, then we know there are values that don't satisfy BST, return false.
6, If i is equal to start-1, then for the current sub-tree, it could be a valid BST. So we recursively check for the left subtree
and the right subtree. 
For left subtree: start = start, end = left
For right subtree: start = left+1, end = end-1.
7, if both of left and right subtree are valid BST, return true. Otherwise, return false.

Time complexity: O(nlogn)  Space complexity: O(1)
*/

//Solution1: Time: O(nlogn)  Space: O(n)
using System;
using System.Collections.Generic;
using System.Linq;

//Tree Node class
public class TreeNode{
	public int val{get;set;}
	public TreeNode left{get;set;}
	public TreeNode right{get;set;}
	public TreeNode(int v){
		this.val=v;
	}
}

public class Test
{
	//Check if a given postorder traversal is a valid BST
	public static bool ValidatePostorder(int[] nodes, int len){
		TreeNode root = ConstructBST(nodes, 0, len-1);
		return ValidateBST(root);
	}
	
	//Construct a BST using Post-Order traversal
	private static TreeNode ConstructBST(int[] nodes, int start, int end){
		if(end<start)
			return null;
		TreeNode root = new TreeNode(nodes[end]);
		if(end==start)
			return root;
		int i=end-1;
		while(i>=start){
			if(nodes[i]<root.val)
				break;
			i--;
		}
		root.left = ConstructBST(nodes, start, i);
		root.right = ConstructBST(nodes, i+1, end-1);
		return root;
	}
	
	//check if a given Binary Tree is a BST
	private static bool ValidateBST(TreeNode root){
		object prev=null;
		return ValidateBSTHelper(root, ref prev);
	}
	
	//Helper method for checking if a given Binary Tree is BST
	private static bool ValidateBSTHelper(TreeNode root, ref object prev){
		if(root==null)
			return true;
		if(ValidateBSTHelper(root.left, ref prev)){
			if(prev==null||root.val>(int)prev){
				prev=root.val;
				return ValidateBSTHelper(root.right, ref prev);
			}
		}
		return false;
	}
	
	public static void Main()
	{
		int numCase = int.Parse(Console.ReadLine());
		for(int i=0;i<numCase;i++){
			int len = int.Parse(Console.ReadLine());
			string[] array = Console.ReadLine().Split();
			int[] nodes = array.Select(y=>int.Parse(y)).ToArray();
			Console.WriteLine(ValidatePostorder(nodes, len));
		}
	}
}


//Solution2: Time: O(nlogn)  Space: O(1)
using System;
using System.Linq;

public class Test
{
	//Check if the postorder array is a valid BST
	public static bool ValidateBST(int[] nodes, int len){
		return ValidateBSTHelper(nodes, 0, len-1);
	}
	
	//Helper method for checking if the postorder array is a valid BST
	private static bool ValidateBSTHelper(int[] nodes, int start, int end){
		if(end<=start)  //empty tree and a tree has only one node are BST
			return true;
		int root = nodes[end]; //current root value
		int i = end-1;
		while(i>=start&&nodes[i]>root){
			i--;
		}
		int left = i;
		while(i>=start&&nodes[i]<root){
			i--;
		}
		if(i!=start-1) 
			return false;
		//Recursively check left subtree and right subtree
		return ValidateBSTHelper(nodes, start, left) && ValidateBSTHelper(nodes,left+1,end-1);
	}
	
	public static void Main()
	{
		int numCase = int.Parse(Console.ReadLine());
		for(int i=0;i<numCase;i++){
			int len = int.Parse(Console.ReadLine());
			string[] array = Console.ReadLine().Split();
			int[] nodes = array.Select(y=>int.Parse(y)).ToArray();
			Console.WriteLine(ValidateBST(nodes, len));
		}
	}
}
