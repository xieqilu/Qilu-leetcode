/**
Implement MyQueue class which implements a queue using two stacks.


Solution:
The major difference between a stack and a queue is the order(FIFO and LIFO).
So we can use the second stack to reverse the order of the elements (by poping
the first stack and pushing elements into second stack). In such an implementation,
on each Peek() and Dequeue() operation, we would pop everything from first stack
to second stack, perform the peek/pop operation and then push everything back.

This will work but cost us needless movement of elements. We can let the elements 
sit in the second stack until we absolutely must reverse the elements. Because we only
need to make sure the Peek() and Dequeue() method will return the first element of the
queue.

So stackNewest has the newest elements on top and stackOldest has the oldes elements on
top. When we dequeue an element, we want to remove the oldest element first, and so we 
dequeue from stackOldest. Only if stackOldest is empty, then we want to transfer all 
elements from stackNewest into this stack in reverse order. When Enqueue elements, we
always push it to stackNewest.
*/


using System;
using System.Collections.Generic;

namespace A170QueueUsingStacks
{
	public class MyQueue<T> 
	{
		private Stack<T> stackNewest, stackOldest; //two stacks
		public int Count{  //Count property, in java, should be a method size()
			get{ 
				return stackNewest.Count + stackOldest.Count;
			}
		}
		public MyQueue(){  //constructor
			stackNewest = new Stack<T> ();
			stackOldest = new Stack<T> ();
		}

		public void Enqueue(T item){ //always push item into stackNewest
			stackNewest.Push (item);
		}

		private void ShiftStacks(){  //only shift when stackOldest is empty
			if (stackOldest.Count == 0) {
				while (stackNewest.Count != 0)
					stackOldest.Push (stackNewest.Pop ());
			}
		}

		public T Dequeue(){
			ShiftStacks (); //if stackOldest is not empty, won't shift
			return stackOldest.Pop ();
		}

		public T Peek(){
			ShiftStacks (); //if stackOldest is not empty, won't shift
			return stackOldest.Peek ();
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			MyQueue<int> MyQ = new MyQueue<int> ();
			Console.WriteLine (MyQ.Count); //0
			MyQ.Enqueue (1);
			MyQ.Enqueue (2);
			Console.WriteLine (MyQ.Peek ()); //1
			MyQ.Dequeue ();
			MyQ.Enqueue (5);
			MyQ.Enqueue (7);
			Console.WriteLine (MyQ.Dequeue ());//2
			Console.WriteLine (MyQ.Dequeue ());//5
			MyQ.Enqueue (17);
			Console.WriteLine (MyQ.Count); //2
		}
	}
}
