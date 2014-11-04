using System;
using System.Collections.Generic;

namespace SlidingWindowMax
{
	public class Finder
	{
		public List<int> FindMaximum(List<int> listA, int w)
		{
			int length = listA.Count;
			if (length < 3) //edge case!
				return null;
			LinkedList<int> ll = new LinkedList<int> ();
			List<int> listB = new List<int> ();
			for (int i = 0; i < w; i++) {
				while (ll.Count != 0 && listA [i] >= listA[ll.Last.Value]) 
					ll.RemoveLast (); //remove unnecessary element
				ll.AddLast (i);
			}

			for (int i = w; i < length; i++) {
				listB.Add (listA [ll.First.Value]);
				while (ll.Count != 0 && listA [i] >= listA[ll.Last.Value])
					ll.RemoveLast ();
				while (ll.Count != 0 && ll.First.Value <= i - w) //remove element that is out of the window
					ll.RemoveFirst ();
				ll.AddLast (i);
			}
			listB.Add(listA [ll.First.Value]); //add the final max value into listB
			return listB;
		}
	}


	class MainClass
	{
		public static void Main (string[] args)
		{
			List<int> testList = new List<int>(){3,2,4,5,6,1,0,9};
			//List<int> testList = new List<int>();
			Finder finder = new Finder ();
			List<int> result = finder.FindMaximum (testList, 3);
			if (result == null)
				Console.WriteLine ("null");
			else {
				foreach (int i in result) {
					Console.Write (i + " ");
				}
			}
		}
	}
}
