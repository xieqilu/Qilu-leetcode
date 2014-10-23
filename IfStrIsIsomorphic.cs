//Check if a string is isomorphic


using System;
using System.Collections.Generic;
using System.Threading;
namespace CheckIsomorphic
{

	public class Checker
	{
		public Dictionary<char,char> DicA { get; private set;}
		public Dictionary<char,char> DicB { get; private set;}

		public Checker()
		{
			this.DicA = new Dictionary<char, char> ();
			this.DicB = new Dictionary<char, char> ();
		}

		public bool CheckIsomorphic (string strA, string strB)
		{
			if(strA == null || strB == null)
				return false;
			if (strA.Length != strB.Length)
				return false;
			if (strA.Equals (strB))
				return true;

			//put pair into two dictionaries.
			for (int i = 0; i < strA.Length; i++) {
				char tempA = strA [i];
				char tempB = strB [i];

				if (!DicA.ContainsKey (tempA)) // must check if the key already existed
					DicA.Add (tempA, tempB);
				if (!DicB.ContainsKey (tempB))
					DicB.Add (tempB, tempA);
			}

			//
			for (int i = 0; i < strA.Length; i++) {
				char tempA = strA [i];
				char tempB = strB [i];

				if (tempA != DicB [tempB])
					return false;
				if (tempB != DicA [tempA])
					return false;
			}
			return true;
		}
	}


	class MainClass
	{
		public static void Main (string[] args)
		{
			string strA = "abb";
			string strB = "oxc";
			Checker checker = new Checker ();
			bool result = checker.CheckIsomorphic (strA, strB);
			Console.WriteLine (result);
		}
	}
}



class SizeQueue<T>
{
	private readonly Queue<T> queue = new Queue<T>();
	private readonly int maxSize;
	public SizeQueue(int maxSize) { this.maxSize = maxSize; }

	public void Enqueue(T item)
	{
		lock (queue)
		{
			while (queue.Count >= maxSize)
			{
				Monitor.Wait(queue);
			}
			queue.Enqueue(item);
			if (queue.Count == 1)
			{
				// wake up any blocked dequeue
				Monitor.PulseAll(queue);
			}
		}
	}
	public T Dequeue()
	{
		lock (queue)
		{
			while (queue.Count == 0)
			{
				Monitor.Wait(queue);
			}
			T item = queue.Dequeue();
			if (queue.Count == maxSize - 1)
			{
				// wake up any blocked enqueue
				Monitor.PulseAll(queue);
			}
			return item;
		}
	}
}


