/**
 * How to design a sequence of random numbers in a specific range?
 * 
 * Solution:
 * In C#, use the Random system class to generate almost random numbers.
 * The constructor of Random class is Random() or Random(Int32).
 * we can specify an Integer seed value that is used to generate random number.
 * The default seed value of Random() is time-dependent, so if we create
 * two random instances in a very short time, it's highly likely that the 
 * two instances will generate identical random number sequence.
 * 
 * To avoid that, We can create one Random object to generate many random numbers over time, 
 * instead of creating new Random objects to generate one random number.
 * 
 * A much better way to avoid identical random number sequence is to create a static random object (class-level)
 * and provide a static method the generate random numbers. 
 * Thus we avoid the creating many instances of the class and created many new random objects in a short time.
 * 
 * Or We can also directly create a static class to generate random number sequences.
 * */


using System;

namespace GenerateRandomNumber
{
	public class Generator{
		private static Random rd = new Random();
		public static int GenerateRandomNumber(int min, int max){
			int n = rd.Next (min, max); //include min, but exclude max
			return n;
		}
	}

	public static class SGenerator{
		private static Random rd = new Random();
		public static int GenerateRandomNumber(int min, int max){
			int n = rd.Next (min, max); //include min, but exclude max
			return n;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			for(int i=0;i<20;i++)
				Console.WriteLine (Generator.GenerateRandomNumber (1, 100));

			for(int i=0;i<20;i++)
				Console.WriteLine (SGenerator.GenerateRandomNumber (1, 100));

		}
	}
}
