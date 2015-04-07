//Problem: There are n houses built in a line, each of which contains some value in it. 
//A thief is going to steal the maximal value in these houses, 
//but he cannot steal in two adjacent houses. What is the maximal stolen value?
//All house values are postive int, no negative number

//For example, if there are four houses with values {6, 1, 2, 7}, 
//the maximal stolen value is 13 when the first and fourth houses are stolen.



using System;
using System.Collections.Generic;
using System.Collections;


namespace StoleHouse
{
	class Finder
	{
		//Iterative Solution, recommended, much more efficient than recursive solution
		public static int FindMaxValue(int[] houses)  //Time: O(n), space: O(1)
		{
			if (houses.Length == 0) //if input array is empty
				return 0;

			int preValue = houses [0]; //if array size is 1
			if (houses.Length == 1)
				return preValue;

			int currentValue = Math.Max (houses [0], houses [1]);
			if (houses.Length == 2) //if array size is 2
				return currentValue;

			//use iterative, not use recursive method
			int tempValue;
			for (int i = 2; i < houses.Length; i++) { //update preValue and currentValue
				tempValue = Math.Max (preValue + houses [i], currentValue);
				preValue = currentValue;
				currentValue = tempValue;
			}

			return currentValue;
		}


		//Recursive Solution, not recommended, much less efficient than the iterative solution
		public static int RecurFindMaxValue(int[] houses, int index) //Time; O(2^n)  T(n) = T(n-1) + T(n-2)
		{
			int preValue, currentValue; 
			if (index >= houses.Length) {  //Base case
				preValue = 0;
				currentValue = 0;
			} else {
				int tempValue;
				preValue = RecurFindMaxValue (houses, index + 2); //T(n-2)
				currentValue = RecurFindMaxValue (houses, index + 1); //T(n-1)
				tempValue = Math.Max (preValue + houses [index], currentValue);
				preValue = currentValue;
				currentValue = tempValue;
			}
			return currentValue;
		}


		//get the max value and all selected elements. This solution needs fixing later
		public static List<int> FindMaxValueAndHouse(int[] houses)
		{
			List<int> result = new List<int> ();

			if (houses.Length == 0)//if input array is empty
				result.Add (0);
			else if (houses.Length == 1) {
				result.Add (houses [0]);
				result.Add (houses [0]);
			} else if (houses.Length == 2) {
				if (houses [1] >= houses [0]) {
					result.Add (houses [1]);
					result.Add (houses [1]);
				} else {
					result.Add (houses [0]);
					result.Add (houses [0]);
				}
			} else {
				int preValue = houses [0];
				int currentValue = Math.Max (houses [0], houses [1]);
				int tempValue;
				for (int i = 2; i < houses.Length; i++) {
					if (preValue + houses [i] >= currentValue) {
						tempValue = preValue + houses [i];
						if(!result.Contains(houses[i-2]))
						result.Add (houses [i - 2]);
						if(!result.Contains(houses[i]))
						result.Add (houses [i]);
					} else {
						tempValue = currentValue;
						if(!result.Contains(houses[i-1]))
							result.Add (houses [i - 1]);
					}
					preValue = currentValue;
					currentValue = tempValue;
				}
				result.Add (currentValue);
			}
			return result;
		}
	}



	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] houses = new int[]{ 34,1,3,6,9,72,65,13,24,31,2,4};
			Console.WriteLine (Finder.FindMaxValue (houses));
			Console.WriteLine (Finder.RecurFindMaxValue (houses,0));
			List<int> result = Finder.FindMaxValueAndHouse (houses);
			Console.WriteLine (result [result.Count - 1]);
			Console.WriteLine (" ");
			foreach (int i in result)
				Console.Write (i + " ");
		}
	}
}
