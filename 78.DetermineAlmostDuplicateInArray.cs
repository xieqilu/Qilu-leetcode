/**
     * Write a function that is given an array of integers. It should return true if
     * any value appears at least twice in the array, and it should return false if
     * every element is distinct.

boolean containsDuplicate(int[] arr) {

}
*/




/** 
* Write a function that is given an array of integers and an integer k. It
* should return true if and only if there are two distinct indices i and j into
	* the array such that arr[i] = arr[j] and the difference between i and j is at
		* most k.

		boolean containsNearbyDuplicate(int[] arr, int k) {
}
*/

/**
     * Write a function that is given an array of integers. It should return true if
     * and only if there are two distinct indices i and j into the array such that. 
     * the difference between arr and arr[j] is at most l and the difference
     * between i and j is at most k.
     *
		boolean containsNearbyAlmostDuplicate(int[] arr, int k, int l) {
	// Write code here. Waral
}
*/




using System;
using System.Collections.Generic;
using System.Collections;

namespace DetermineDuplicateInArray
{
	//Interval class
	public class Interval{
		public int low { get; set;}
		public int high { get; set;}
		public Interval(int l, int h){
			this.low = l;
			this.high = h;
		}
	}

	//Interval BST Node class
	public class ITNode{
		public Interval i {get;set;}
		public ITNode left {get;set;}
		public ITNode right {get;set;}
		public int max { get; set;} //maximum high value in subtree rooted with this node
		public ITNode(Interval i, int m, ITNode l, ITNode r){
			this.i = i;
			this.max = m;
			this.left = l;
			this.right = r;
		}

		public ITNode(Interval i){
			this.i = i;
			this.left = null;
			this.right = null;
		}
	}

	/**
	 * Interval Tree class:
	 * 
	 * private static ITNode newNode(Interval i)
	 * 
	 * public static ITNode insert(ITNode root, Interval i
	 * 
	 * private ITNode minValueNode(ITNode node)
	 * 
	 * public static ITNode delete(ITNode root, Interval i)
	 * 
	 * private static bool doOverlap(Interval i1, Interval i2)
	 * 
	 * public static bool overlapSearch(ITNode root, Interval i)
*/

	public class IntervalTree{

		//create a new interval tree node
		private static ITNode newNode(Interval i){

			ITNode temp = new ITNode (i, i.high, null, null);
			return temp;
		}

		//Insert a new Interval Search Tree node
		//this is very similar to BST Insert. The low value of interval
		//is used to maintain BST property
		public static ITNode insert(ITNode root, Interval i){

			//base case: tree is empty, new node become root
			if (root == null)
				return newNode (i);

			//get low value of interval of root
			int l = root.i.low;

			//if i.low is smaller than root's low value,
			//then i goes to the left subtree
			if (i.low < l)
				root.left = insert (root.left, i);

			//else, i goes to the right subtree
			else
				root.right = insert (root.right, i);

			//update the max value of this ancestor if needed
			if (root.max < i.high)
				root.max = i.high;
			return root;
		}

		//Given a non-empty BST, return the node with minimum key
		//value found in that tree. Note the entire tree does not
		//need to be searched
		private static ITNode minValueNode(ITNode node){
			ITNode current = node;

			//loop down to find the leftmost child
			while (current.left != null)
				current = current.left;
			return current;
		}

		//delete the node containing the given interval from tree
		public static ITNode delete(ITNode root, Interval i){

			//base case
			if (root == null)
				return root;

			//get low value of root
			int l = root.i.low;

			//if i.low is smaller than root's low value,
			//then it lies in the left subtree
			if (i.low < l)
				root.left = delete (root.left, i);

			//if i.low is greater than root's low value,
			//then it lies in the right subtree
			else if (i.low > l)
				root.right = delete (root.right, i);

			//if i.low is equal to root's low value
			//then root is the node to be deleted
			else {

				//if root has only one child or no child
				if (root.left == null) {
					ITNode temp = root.right;
					return temp;
				} else if (root.right == null) {
					ITNode temp = root.left;
					return temp;
				} 
				//if root with two childre: get the inorder successor
				//which is the smallest in the right subtree
				else {

					//Node with two children: get the inorder successor
					ITNode temp = minValueNode (root.right);

					//copy inorder successor's content to this node
					root.i = temp.i;
					root.max = temp.max;

					//delete the inorder successor
					root.right = delete (root.right, temp.i);
				}
			}
			return root;
		}

		//check if two given intervals overlap
		private static bool doOverlap(Interval i1, Interval i2){
			if (i1.low <= i2.high && i2.low <= i1.high)
				return true;
			else
				return false;
		}

		//Check if a given interval overlaps in the given interval tree
		public static bool overlapSearch(ITNode root, Interval i){

			//base case, tree is empty
			if(root == null) 
				return false;

			//if i overlaps with root
			if(doOverlap(root.i,i))
				return true;

			//if left child of root is present and max of left child is
			//greater than or equal to given interval, then i may overlap
			//with an interval in left subtree
			if (root.left != null && root.left.max >= i.low)
				return overlapSearch (root.left, i);

			//Else interval can only overlap with right subtree
			return overlapSearch (root.right, i);
		}
	}


	public class Finder{

		//use a hashset, if not found before, add to hashset; else, return true
		public static bool containsDuplicate(int[] arr){ //time: O(n), space: O(n)
			if (arr.Length == 0)
				return false;
			HashSet<int> hs = new HashSet<int> ();
			foreach (int i in arr) {
				if (hs.Contains (i))
					return true;
				else
					hs.Add (i);
			}
			return false;
		}

		//use a hashset to keep track the previous k elements
		//for every element, first test if it exists in the hashset, it it is, return true
		//if it is not, test if the size of hashset is equal or greater than k, it it is, remove the first element
		//Then add the current element to the hashset
		public static bool containsNearbyDuplicate(int[] arr, int k){ //time: O(n)  space: O(k)
			if (arr.Length == 0)
				return false;
			HashSet<int> hs = new HashSet<int> ();
			for (int i=0;i<arr.Length;i++) {
				if (hs.Contains (arr [i])) {
					return true;
				}
				if (hs.Count >= k) {
					hs.Remove (arr [i - k]);
				}
				hs.Add (arr [i]);
			}
			return false;
		}

		//use interval BST to store previous k intervals
		public static bool containsNearbyAlmostDuplicate(int[] arr, int k, int l){
			if (arr.Length == 0)
				return false;
			Interval interval = new Interval (arr [0] - l / 2, arr [0] + l / 2); //put first element into tree
			ITNode root = new ITNode (interval, interval.high, null, null);
			for(int i=1;i<arr.Length;i++){
				Interval curr = new Interval (arr [i] - l / 2, arr [i] + l / 2);
				if (IntervalTree.overlapSearch (root, curr)) //if overlap, return true
					return true;
				if (i >=k) {  //if tree size >= k, remove the earliest element from the tree
					Interval toDelete = new Interval (arr [i - k] - l / 2, arr [i - k] + l / 2);
					IntervalTree.delete (root, toDelete);
				}
				IntervalTree.insert (root, curr); //insert current interval to the tree
			}
			return false;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			//test containsDuplicate
			Console.WriteLine("test#1");
			Console.WriteLine ("=======");
			int[] arr = new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 };
			int[] test = new int[] { 1, 1, 2, 2, 3, 3, 4, 4, };
			Console.WriteLine (Finder.containsDuplicate (arr)); //false
			Console.WriteLine (Finder.containsDuplicate (test)); //true

			//test containsNearbyDuplicate
			Console.WriteLine ("");
			Console.WriteLine("test#2");
			Console.WriteLine ("=======");
			int[] test1 = new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			int[] test2 = new int[]{ 1, 2, 3, 4, 1, 6, 7, 6, 8, 10 };
			int[] test3 = new int[]{ 1, 2, 3, 4, 1, 6, 7, 12, 8, 10 };
			int[] test4 = new int[]{ 1 };
			Console.WriteLine (Finder.containsNearbyDuplicate (test1, 1)); //false
			Console.WriteLine (Finder.containsNearbyDuplicate (test1, 2)); //false
			Console.WriteLine (Finder.containsNearbyDuplicate (test1, 3)); //false
			Console.WriteLine (Finder.containsNearbyDuplicate (test2, 1)); //false
			Console.WriteLine (Finder.containsNearbyDuplicate (test2, 2)); //true
			Console.WriteLine (Finder.containsNearbyDuplicate (test3, 3)); //false
			Console.WriteLine (Finder.containsNearbyDuplicate (test3, 4)); //true
			Console.WriteLine (Finder.containsNearbyDuplicate (test3, 5)); //true
			Console.WriteLine (Finder.containsNearbyDuplicate (test4, 2)); //false

			Console.WriteLine ("");
			Console.WriteLine("test#3");
			Console.WriteLine ("=======");
			int[] test5 = new int[]{ 10,20,30,34 };
			int[] test6 = new int[]{ 10,20,30,50,60,34};
			int[] test7 = new int[]{ 10,20,30,36};
			Console.WriteLine (Finder.containsNearbyAlmostDuplicate (test5, 1, 5)); //true
			Console.WriteLine (Finder.containsNearbyAlmostDuplicate (test6, 1, 5)); //false
			Console.WriteLine (Finder.containsNearbyAlmostDuplicate (test7, 1, 5)); //false
		}
	}
}
