/**
Problem1: 
Find k most frequently occurring numbers
given a list of  N integers, write a program to find k most repeating integers. 
[1,1,1,2,2,3,4,4] (seems like the list is already sorted)
举例
k=1
[1]

k=2
[1,2]

k=3
[1,2,4].

Follow-up: infinite stream of sorted numbers coming（用什么实现，伪代码，时间复杂度)


Problem2:
Sort array by frequency
given an array of int, return a list in which element are ordered by frequency in the given array.
If two elements have the same frequency, the one appears first in array should also apprea first
in the output list

Example:
array: { 5, 2, 2, 8, 5, 6, 8, 8 }
output: {8,8,8,5,5,2,2,6}
 * 
 * 
*/

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace SortArrayByFrequency
{
	class Element{
		public int occurence{ get; set;}
		public int firstIndex{ get; set;}
		public Element(int o, int f){
			this.occurence = o;
			this.firstIndex = f;
		}

	}

	class Finder{

		//Sort list by frequency 
		public static List<int> sortArray(int[] arr){ //Time:O(nlogn), Space:O(n)
			//Handle edge case
			if (arr.Length == 0)
				return null;

			Dictionary<int, Element> dt = new Dictionary<int, Element> ();
			for (int i = 0; i < arr.Length; i++) { //put all info into dt, Time: O(n)
				if (dt.ContainsKey (arr [i])) {
					dt [arr [i]].occurence++;
				} else {
					Element temp = new Element (1, i);
					dt.Add (arr [i], temp);
				}
			}

			//sort object in dt by occurence in descending order then by firstIndex in ascending order
			//use QuickSort, time: O(nlogn)
			List<KeyValuePair<int, Element>> sortedList = dt.OrderByDescending (o => o.Value.occurence).
														ThenBy (o => o.Value.firstIndex).ToList ();
				
			//Convert the sortedList to a result list
			List<int> result = new List<int> ();
			foreach (KeyValuePair<int, Element> kp in sortedList) {
				for (int i = 0; i < kp.Value.occurence; i++)
					result.Add (kp.Key);
			}
			return result;
		}


		//get the k most repeating element in the array
		public static List<int> findTopK(int[] arr, int k){ //Time:O(nlogn) Space:O(n)
			//handle edge case
			if (k == 0 || arr.Length < k)
				return null;


			Dictionary<int,int> dt = new Dictionary<int, int> ();
			for (int i = 0; i < arr.Length; i++) { //put frequency info into dt
				if (dt.ContainsKey (arr [i]))
					dt [arr [i]]++;
				else
					dt.Add (arr [i], 1);
			}

			//convert dt to list, then sort the list
			List<KeyValuePair<int,int>> list= dt.OrderByDescending (o => o.Value).ToList ();
			List<int> result = new List<int> ();
			for (int i = 0; i < k; i++)
				result.Add (list [i].Key);
			return result;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] arr = new int[]{ 5, 2, 2, 8, 5, 6, 8, 8 };
			List<int> list = Finder.sortArray (arr);
			foreach (int i in list)
				Console.Write (i + " ");

			Console.WriteLine (" ");
			List<int> result = Finder.findTopK (arr,3);
			foreach (int i in result)
				Console.Write (i + " ");
		}
	}
}
