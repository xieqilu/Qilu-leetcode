/**
Adapter Pattern

What is Adapter Pattern
Adapter pattern acts as a bridge between two incompatible interfaces. This pattern involves a single class called adapter 
which is responsible for communication between two independent or incompatible interfaces.
For Example: 
A card reader acts as an adapter between memory card and a laptop. 
You plugins the memory card into card reader and card reader into the laptop so that memory card can be read via laptop.

The classes, interfaces and objects in this pattern are as follows:
01.ITarget This is an interface which is used by the client to achieve its functionality/request.

02.Adapter This is a class which implements the ITarget interface and inherits the Adaptee class. 
It is responsible for communication between Client and Adaptee.

03.Adaptee This is a class which have the functionality, required by the client. 
However, its interface is not compatible with the client.

04.Client This is a class which interact with a type that implements 
*/

//Simple Example for Adapter pattern

using System;

namespace AdapterPattern
{
	public interface Target //Target interface that is compitable with client
	{
		void MethodA();
	}

	public class Client  //client class has Target instance, can only make call through Target interface
	{
		private Target target;
		public Client(Target t)
		{
			this.target = t;
		}

		public void MakeRequest()
		{
			target.MethodA ();
		}
	}

	public class Adaptee  //Adaptee has the MethodB that client wants to call
	{
		public void MethodB()
		{
			Console.WriteLine("Method B is called!!");
		}
	}


	public class Adapter: Adaptee, Target //Adapter inherit from both Adaptee and Target
	{	
		void Target.MethodA() //implement MethodA of Target interface
		{
			this.MethodB ();  //using MethodB from parent clccass
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Target t = new Adapter (); //instiante Target interface with Adapter
			Client c = new Client (t); //put the instance of Target interface into client
			c.MakeRequest ();          //now client can use method B from Adaptee through Adapter
			Adapter a = new Adapter (); // we can also directly put the instance of Adapter into client
			Client cc = new Client (a);
			cc.MakeRequest ();
		}
	}
}
