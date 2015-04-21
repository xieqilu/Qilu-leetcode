//Design a stack that supports push, pop, top, and retrieving the maximum element in constant time.

//push(x) -- Push element x onto stack.
//pop() -- Removes the element on top of the stack.
//top() -- Get the top element.
//getMin() -- Retrieve the maximum element in the stack.

//use two stacks:
//use the first stack to store all the elements
//use the second stack to keep track of the maximum element


using System;
using System.Collections.Generic;
using System.Collections;

namespace MaxStack
{

	public class MaxStack
	{
		private Stack<int> GeneralStack;
		private Stack<int> MaximumStack;

		public MaxStack()
		{
			GeneralStack = new Stack<int> ();
			MaximumStack = new Stack<int> ();
		}

		public void Push(int x)
		{
			GeneralStack.Push (x);
			if (MaximumStack.Count == 0 || x >= MaximumStack.Peek ())
				MaximumStack.Push (x);
		}

		public void Pop()
		{
			if (GeneralStack.Count == 0)
				return;
			int temp = GeneralStack.Pop();
			if (temp == MaximumStack.Peek ())
				MaximumStack.Pop ();
		}

		public int Top()
		{
			if (GeneralStack.Count == 0)
				return 0;
			return GeneralStack.Peek ();
		}

		public int GetMin()
		{
			if (MaximumStack.Count == 0)
				return 0;
			return MaximumStack.Peek ();
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			MaxStack tStack = new MaxStack ();
			tStack.Push (512);
			tStack.Push (1024);
			tStack.Push (1024);
			tStack.Push (512);
			tStack.Pop ();
			Console.WriteLine (tStack.GetMin ());
			tStack.Pop ();
			Console.WriteLine (tStack.GetMin ());
			tStack.Pop ();
			Console.WriteLine (tStack.GetMin ());
		}
	}
}

