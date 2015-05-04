//Design and implement a data structure
//in which Insert, Peek, Remove, Contains
//GetElement can be done in O(n) time

using System;
using System.Collections.Generic;


namespace LinearTimeDataStructure
{
	public class myDS 
	{
		private Dictionary<int,int> dictionary;
		private List<int> list;
		public myDS()
		{
			this.dictionary = new Dictionary<int, int> ();
			this.list = new List<int> ();
		}

		public List<int> Peek()
		{
			return list;
		}
		public void Insert (int n)
		{
			list.Add (n);
			int index = list.Count - 1;
			dictionary.Add (n, index);
		}

		public void Remove (int n)
		{
			int index = dictionary[n];
			int last = list [list.Count - 1];
			list.RemoveAt (list.Count - 1);
			list [index] = last;
			dictionary [last] = index;
			dictionary.Remove (n);
		}

		public bool Contains (int n)
		{
			return dictionary.ContainsKey (n);
		}

		public int GetRandomElement ()
		{
			Random rd = new Random ();
			int number = rd.Next (list.Count);
			return list [number];
		}

		public int GetElement(int index)
		{
			return list [index];
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			myDS myds = new myDS ();
			myds.Insert (11);
			myds.Insert (12);
			myds.Insert (13);
			myds.Insert (54);

			myds.Remove (12);
			List<int> testlist = myds.Peek ();
			foreach (int i in testlist) {
				Console.WriteLine (i);
			}

			bool b = myds.Contains (34);
			Console.WriteLine (b);

			Console.WriteLine (myds.GetRandomElement ());
			Console.WriteLine (myds.GetRandomElement ());
			Console.WriteLine (myds.GetRandomElement ());
			Console.WriteLine (myds.GetRandomElement ());
		}
	}
}
