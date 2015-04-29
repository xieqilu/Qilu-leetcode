/**
Given a list of numbers, determine whether it can represent the pre-order traversal list of 
a binary search tree (BST).

Input
The first line contains the number of test cases, T. T lines follow, consisting of two lines each.
The first line of each test case contains the number of nodes in the tree, N. 
In next line there will be a list of N unique numbers, where each number is from the range [1, N].

Output
For each test case, print the string “YES” if there exists a BST whose pre-order traversal is equal to the list, 
otherwise print the string “NO” (without quotes, preserving capitalization).

Constraints
1 ≤ T ≤ 10
1 ≤ N ≤ 100

Sample Input
5
3
1 2 3
3
2 1 3
6
3 2 1 5 4 6
4
1 3 4 2
5
3 4 5 1 2

Sample Output
YES
YES
YES
NO
NO

Explanation
The first three cases are from the above examples.
In case 4, after encountering the 3, the 4 tells us we are on the right sub-tree, 
which means no values smaller than 3 are allowed any longer. So when we see the 2 we know the list is invalid.
Similarly, in case 5, after encountering the 3, the 4 and 5 tell us we are on the right sub-tree, 
so the subsequent encounter of values 2 and 1, which belong in the left sub-tree, 
tells us that the list is not valid as a pre-order traversal of a BST.


Idea:
The idea is excately the same as validate postorder traversal of BST. Use the recursive method
to validate BST level by level. On each level, check if there is any node in the left or right 
subtree breaks the BST rules, then recursively check for left and right subtrees.


Solution:
The process is very similiar to validate postorder traversal of BST. In the recursive helper
method:
1, the edge case is still when end<=start, there is only one node or no node, return true.
2, Then because we suppose the list is a preorder traversal list, so take the first node of current
range as the root node (nodes[start]). Then traverse from nodes[start+1] to nodes[end] and try to find
the partition point, which should be the first node for right subtree. The condition of while loop
is i<=end && nodes[i]<root. 
3, Then store the partition point and continue the traverse to the end. 
4, Then i should be equal to end+1, because all nodes in the range should be valid for right or left
subtree. If i is not end+1, then at this level the tree is not a BST, so return false.
5, if i is end+1, then recursively check for left and right subtree.

For left subtree: start=start+1, end=right-1
For right subtree: start=right, end=end

Time complexity: O(nlogn)   Space: O(1)
*/

using System;
using System.Linq;

public class Test
{
	public static bool ValidatePreOrder(int[] nodes, int len){
		return ValidatePreOrderHelper(nodes, 0, len-1);
	}
	
	private static bool ValidatePreOrderHelper(int[] nodes, int start, int end){
		if(end<=start)  //if empty tree or has only one node, it's valid BST
			return true;
		int root = nodes[start]; //get current root value
		int i = start+1;
		while(i<=end && nodes[i]<root)
			i++;
		int right = i; //i is now at first node for right subtree
		while(i<=end && nodes[i]>root)
			i++;
		if(i!=end+1)
			return false;
		//recursively check left and right subtree
		return ValidatePreOrderHelper(nodes, start+1, right-1) &&
			ValidatePreOrderHelper(nodes, right, end);
	}
	
	public static void Main()
	{
		int numCase = int.Parse(Console.ReadLine());
		for(int i=0;i<numCase;i++){
			int len = int.Parse(Console.ReadLine());
			string[] array = Console.ReadLine().Split();
			int[] nodes = array.Select(y=>int.Parse(y)).ToArray();
			if(ValidatePreOrder(nodes,len))
				Console.WriteLine("YES");
			else
				Console.WriteLine("NO");
		}
	}
}
