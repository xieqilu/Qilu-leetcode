//There is an incoming stream of Integer,
//Each time reveiving an int, we need to 
//find out the current median of all received
//integers

//Design a data structure to efficientlly find
//the median each time. 

//Try to do it in O(n) time


using System;
using System.Collections;
using System.Collections.Generic;

namespace MedianOfIntegerStream
{
	public class ListReceiver
	{
		public List<int> list { get; set;}
		public ListReceiver ()
		{
			this.list = new List<int> ();
		}

		public void Insert(int n) //O(1)
		{
			this.list.Add (n);
		}

		public decimal FindMedian() //O(nlogn), worst case is O(n^2)
		{
			list.Sort (); //O(nlogn), worst case is O(n^2)
			int length = list.Count;
			decimal median = 0;
			if (length % 2 == 0) {
				int first = list [length / 2];
				int second = list [(length / 2) - 1];
				median = (first + second) / 2;
			} else {
				median = list [length / 2]; 
			}
			return median;
		}

		private int QuickSelect(int k, List<int> targetList) //O(n)
		{
			List<int> leftList = new List<int> ();
			List<int> rightList = new List<int> ();
			//int pivot = targetList [targetList.Count/2];
			int pivot = targetList[0];
			foreach (int i in targetList) {  //O(n)
				if (i < pivot)
					leftList.Add (i);
				if (i > pivot)
					rightList.Add (i);
			}

			if (leftList.Count < k - 1) 
				return this.QuickSelect (k - 1 - leftList.Count, rightList); //O(n)
			else if (leftList.Count > k - 1)
				return this.QuickSelect (k, leftList); //O(n)
			else
				return pivot;
		}

		public decimal NewFindMedian() //O(n)
		{
			decimal median = 0;
			int length = list.Count;
			if (length % 2 == 0) {
				int first = this.QuickSelect (length / 2, list); //lenth/2 means find length/2 th element, not list[length/2]
				int second = this.QuickSelect ((length / 2) +1, list);
				median = (first + second) / 2;
			} 

			else {
				median = this.QuickSelect ((length / 2) +1, list);
			}
			return median;
		}

	}


	public class MinHeap<T> where T : IComparable 
	{
		private List<T> list = new List<T>();

		public int Count{ get; set;}

		public void Insert (T t){} //O(logn)
		public T Peek(){return list [0];}
		public T RemoveRoot (){return list [0];}
	}

	public class MaxHeap<T> where T : IComparable 
	{
		private List<T> list = new List<T>();

		public int Count{ get; set;}

		public void Insert(T t){} //O(logn)
		public T Peek(){return list [0];}
		public T RemoveRoot(){return list [0];}
	}

	public class HeapReceiver
	{
		public MinHeap<int> minheap { get; set;}
		public MaxHeap<int> maxheap { get; set;}
		public HeapReceiver()
		{
			this.minheap = new MinHeap<int> ();
			this.maxheap = new MaxHeap<int> ();
		}
		public void Insert(int n) //O(logn)
		{
			//insert n to one of the two heaps
			if (n < maxheap.Peek ())
				maxheap.Insert (n);
			else
				minheap.Insert (n);

			//balance the two heaps
			int diff = maxheap.Count - minheap.Count;
			if (diff > 1) {
				int temp = maxheap.RemoveRoot ();
				minheap.Insert (temp);
			}
			if (diff < -1) {
				int temp = minheap.RemoveRoot ();
				maxheap.Insert (temp);
			}
		}

		public decimal FindMedian() //O(1)
		{
			decimal median = 0;
			int maxRoot = maxheap.Peek ();
			int minRoot = minheap.Peek ();
			int diff = maxheap.Count - minheap.Count;
			if (diff == 0) {
				median = ((maxRoot + minRoot) / 2);
			} 

			else if (diff > 0) {
				median = maxRoot;
			} 

			else if (diff < 0) {
				median = minRoot;
			}
			return median;
		}
	}



	class MainClass
	{
		public static void Main (string[] args)
		{
			ListReceiver listreceiver = new ListReceiver ();
			while (true) {
				Console.WriteLine ("Please enter an integer: ");
				string tempstr = Console.ReadLine ();
				if (tempstr == "stop")
					break;
				else {
					int temp = Convert.ToInt32 (tempstr);
					listreceiver.Insert (temp);
					//decimal median = listreceiver.FindMedian ();
					decimal median = listreceiver.NewFindMedian ();
					Console.WriteLine ("The current Median is " + median);
				}

			}

		}
	}
}
