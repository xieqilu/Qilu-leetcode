//Find all subsets of a specific set
// input: {1,2,3}  output: {},{1}, {2}, {3}, {1,2}, {1,3}, {2,3}, {1,2,3}

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
namespace FIndSubSets
{
	class Finder
	{
		public static List<List<int>> FindSubset(List<int> input, int index)
		{
			List<List<int>> allSubsets;
			int length = input.Count;
			if (index == length) {
				List<int> empty = new List<int> ();
				allSubsets = new List<List<int>> ();
				allSubsets.Add (empty);
			} else {
				List<List<int>> addSubsets = new List<List<int>> ();
				allSubsets = FindSubset (input, index + 1);
				int current = input [index];
				foreach (List<int> l in allSubsets) {
					List<int> temp = new List<int> (l);
					temp.Add (current);
					addSubsets.Add (temp);
				}
				foreach (List<int> l in addSubsets)
					allSubsets.Add (l);
			}
			return allSubsets;
		}
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
			List<int> test = new List<int> (){ 1, 2, 3, 4 };
			List<List<int>> result = new List<List<int>> ();
			result = Finder.FindSubset (test,0);
			Console.WriteLine (result);
			foreach (List<int> l in result) {
				foreach (int i in l)
					Console.Write (i + " ");
				Console.WriteLine (" ");
			}
		}
	}
}
