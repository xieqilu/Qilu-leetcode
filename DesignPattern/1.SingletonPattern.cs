/**
Singleton Pattern

The singleton pattern is one of the best-known patterns in software engineering. 
Essentially, a singleton is a class which only allows a single instance of itself to be created, 
and usually gives simple access to that instance. 
Most commonly, singletons don't allow any parameters to be specified when creating the instance - 
as otherwise a second request for an instance but with a different parameter could be problematic!

All these implementations share four common characteristics, however:
1 A single constructor, which is private and parameterless. This prevents other classes from instantiating it 
(which would be a violation of the pattern). Note that it also prevents subclassing - 
if a singleton can be subclassed once, it can be subclassed twice, and if each of those subclasses can create an instance, 
the pattern is violated. The factory pattern can be used if you need a single instance of a base type, 
but the exact type isn't known until runtime.

2 The class is sealed. This is unnecessary, strictly speaking, due to the above point, 
but may help the JIT to optimise things more.

3 A static variable which holds a reference to the single created instance, if any.
4 A public static means of getting the reference to the single created instance, creating one if necessary.

Note that all of these implementations also use a public static property Instance as the means of accessing the instance. 
In all cases, the property could easily be converted to a method, with no impact on thread-safety or performance.
*/


//simple example of a thread-safe singleton pattern

using System;

namespace SingletonPattern
{

	public sealed class Singleton
	{
		private static Singleton instance = null; //A static variable which holds a reference 
												//to the single created instance, if any
		private static readonly object PadLock = new object ();//A thread lock object

		private Singleton() //A single constructor, which is private and has no paramenter
		{

		}

		public static Singleton Instance  //A public property providing access to instance
		{
			get{
				lock (PadLock) { // The lock keyword marks a statement block as a critical section 
								//by obtaining the mutual-exclusion lock for a given object, 
								//executing a statement, and then releasing the lock.

					if (instance == null) // if instance is null, create a new Singleton instance
						instance = new Singleton ();
					return instance;
				}
			}
		}

	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
		}
	}
}
