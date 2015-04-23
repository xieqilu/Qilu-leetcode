/**
Abstract Factory Pattern

A factory creates objects. We implement the factory design pattern in a C# program. 
With this pattern, we develop an abstraction that isolates the logic for determining which type of class to create.
The factory design pattern relies on a type hierarchy. The classes must all implement an interface or derive from a base class. 
We use an abstract class as the base. The Manager, Clerk and Programmer classes derive from Position.
*/

//Simple Factory Pattern Example

using System;

namespace FactoryPattern
{

	public abstract class Position // abstract base class
	{
		public abstract string Title{ get;} // abstract property that can be overrided by child classes
	}

	public class Manager : Position //Manager class
	{
		public override string Title{  //override abstract property
			get{
				return "Manager";
			}
		}

	}

	public class Clerk : Position  // Clerk class
	{
		public override string Title{ //override abstract property
			get{ 
				return "Clerk";
			}
		}

	}

	public class Programmer : Position //Programmer class
	{
		public override string Title{ //override abstract property
			get{ 
				return "Programmer";
			}
		}
	
	}

	public class Factory //decides which class to instantiate
	{
		public static Position GetRole(int id)
		{
			switch (id) {  //return different instance according to the input id
			case 0:
				return new Manager ();
			case 1:
			case 2:
				return new Clerk ();
			case 3:
			default:
				return new Programmer ();
			}
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			for (int i = 0; i < 4; i++) {
				var currentPosition = Factory.GetRole (i);
				Console.WriteLine ("Where Id is {0}, position is {1}", i, currentPosition.Title);
			}
		}
	}
}
