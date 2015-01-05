//Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

//push(x) -- Push element x onto stack.
//pop() -- Removes the element on top of the stack.
//top() -- Get the top element.
//getMin() -- Retrieve the minimum element in the stack.

//use two stacks:
//use the first stack to store all the elements
//use the second stack to keep track of the minmum element


using System;
using System.Collections.Generic;
using System.Collections;

namespace MinStack
{

	public class MinStack
	{
		private Stack<int> GeneralStack;
		private Stack<int> MinimumStack;

		public MinStack()
		{
			GeneralStack = new Stack<int> ();
			MinimumStack = new Stack<int> ();
		}

		public void Push(int x)
		{
			GeneralStack.Push (x);
			if (MinimumStack.Count == 0 || x <= MinimumStack.Peek ()) //consider duplicate element!!
				MinimumStack.Push (x);
		}

		public void Pop()
		{
			if (GeneralStack.Count == 0)
				return;
			int temp = GeneralStack.Pop ();
			if (temp == MinimumStack.Peek ())
				MinimumStack.Pop ();
		}

		public int Top()
		{
			if (GeneralStack.Count == 0)
				return 0;
			return GeneralStack.Peek ();
		}

		public int GetMin()
		{
			if (MinimumStack.Count == 0)
				return 0;
			return MinimumStack.Peek ();
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			MinStack tStack = new MinStack ();
			tStack.Push (3);
			tStack.Push (7);
			tStack.Push (2);
			tStack.Push (6);
			tStack.Push (19);
			tStack.Push (1);
			tStack.Push (13);
			Console.WriteLine (tStack.Top ());
			Console.WriteLine (tStack.GetMin ());
			tStack.Pop ();
			tStack.Pop ();
			Console.WriteLine (tStack.Top ());
			Console.WriteLine (tStack.GetMin ());
		}
	}
}
