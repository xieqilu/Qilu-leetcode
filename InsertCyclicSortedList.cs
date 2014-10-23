using System;
using System.Collections;
using System.Collections.Generic;

namespace cyclicSortedList
{
	public class Node //construct a node class to represent node in cyclic sorted list
	{
		public int Value{ get; private set;} //value cannot be changed ouside
		public Node Next { get; set;} // next is read-write
		public Node ()
		{
			this.Next = null;
		}
		public Node(int value)
		{
			this.Value = value;
			this.Next = null;
		}
		public Node(int value, Node next)
		{
			this.Value = value;
			this.Next = next;
		}
	}

	public class Inserter
	{
		public Node Insert(Node aNode, int x)
		{
			if (aNode==null) {
				aNode = new Node (x);
				aNode.Next = aNode;
				return aNode;
			}

			Node p = aNode;
			Node previous = null;

			do {
				previous = p;
				p = p.Next;
				if (x <= p.Value && x >= previous.Value)
					break; //x satisfy Case1
				if (previous.Value > p.Value && (x < p.Value || x > previous.Value))
					break; //x satisfy Case2
			} while(p != aNode); // when back to starting point, x satisfy Case3

			Node xNode = new Node (x);
			previous.Next = xNode;
			xNode.Next = p;
			return xNode;
		}

	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			//construct a cyclic sorted list
			List<Node> CyclicSortedList = new List<Node>();
			CyclicSortedList.Add(new Node(11));
			CyclicSortedList.Add(new Node(1));
			CyclicSortedList.Add(new Node(2));
			CyclicSortedList.Add(new Node(4));
			CyclicSortedList.Add(new Node(5));
			CyclicSortedList.Add(new Node(7));
			CyclicSortedList.Add(new Node(9));

			for(int i=0;i<CyclicSortedList.Count;i++)
			{
				if(i==CyclicSortedList.Count-1)
					CyclicSortedList[i].Next = CyclicSortedList[0];
				else CyclicSortedList[i].Next = CyclicSortedList[i+1];
			}

			Inserter inserter = new Inserter ();
			Node xNode = inserter.Insert (CyclicSortedList[5], 8);
			Node aNode = inserter.Insert (CyclicSortedList[5], 15);
			CyclicSortedList.Add (xNode);
			CyclicSortedList.Add (aNode);

			foreach(var node in CyclicSortedList)
			{

				Console.WriteLine(node.Value+" -> "+node.Next.Value);
			}
		}
	}
}
