//Find Intersection of two Sorted Array
//An intersection is an element that exists in both arraies.

using System;
using System.Collections.Generic;
using System.Collections;

namespace IntersectionOfTwoSortedArray
{
	class Finder
	{
		public static List<int> FindIntersection(List<int> listA, List<int> listB)
		{
			int p1 = 0, p2 = 0;
			List<int> Inter = new List<int> ();
			while (p1 != listA.Count && p2 != listB.Count) {
				if (listA [p1] > listB [p2])
					p2++;
				else if (listA [p1] < listB [p2])
					p1++;
				else {
					Inter.Add (listA [p1]);
					p1++;
					p2++;
				}
			}
			return Inter;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
//			List<int> test1 = new List<int>(){1,3,4,5};
//			List<int> test2 = new List<int> (){2,7,8,9};
			List<int> test1 = new List<int> (){ 2, 3, 4, 6, 7, 8, 9 };
			List<int> test2 = new List<int> (){ 1, 3, 5, 7, 9,11,12,13 };
			List<int> result = Finder.FindIntersection (test1, test2);
			if (result.Count == 0)
				Console.WriteLine ("There is no Intersection Found");
			else {
				foreach (int i in result)
					Console.Write (i + " ");
			}
		}
	}
}
