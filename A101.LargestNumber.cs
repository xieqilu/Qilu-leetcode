/**
 * Given a list of non negative integers, arrange them such that they form the largest number.

For example, given [3, 30, 34, 5, 9], the largest formed number is 9534330.

Note: The result may be very large, so you need to return a string instead of an integer.

Solution:
The key point to this problem is to compare each number and determine which should be where.
The simplest and most effective way to compare two stings in this case is compare s1+s2 and s2+s1.
If the (int)(s1+s2) > (int)(s2+s1), then s1 should be ahead of s2, otherwise, s2 should be ahead of s1.

We will use a List to store all the strings (first convert int to string).
In C#, the List.Sort() method can take another method as parameter. If no parameter, it will use 
the default comparison method. There are two ways to apply customized comparision method to it:

1, write another private method A, and use A as a parameter of List.Sort().
2, use delegate to overload an anonymous method like: List.Sort(delegate(string s1, string s2))

No matter which method we use, the comparison method should return int value. And the return value
can be positive(s1>s2), negative(s2>s1) or 0(s1==s2). Then the list will be sorted according to the 
return value of each pair of elements in the list. The List.Sort() method will still use QuickSort.

Reference:
https://msdn.microsoft.com/en-us/library/w56d4y5z(v=vs.110).aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-2

After sort the string list, we can iterate it reversely and append each element to a StringBuilder.

Note if the input int array only contains 0, we need to only keep one zero at the result and get 
rid of other zeros.
*/


using System;
using System.Collections.Generic;
using System.Text;

namespace LargestNumber
{
	class Finder{

		public static string LargestNumber(int[] num){
			StringBuilder sb = new StringBuilder ();
			List<string> strList = new List<string> (); //convert int array to string list
			foreach (int i in num)
				strList.Add (i.ToString());

			//use delegate to invoke anonymous comparison method

			strList.Sort (delegate(string x, string y) { //return: positive:x>y, negative:x<y, zero:x==y
				if(Convert.ToInt64(x+y)>Convert.ToInt64(y+x))
					return 1;
				if(Convert.ToInt64(x+y)<Convert.ToInt64(y+x))
					return -1;
				return 0;
			});


			bool IsLeadingZero = true; //used to check leading zeros
			for (int i = strList.Count - 1; i >= 0; i--) {
				if (IsLeadingZero && strList [i] == "0") //check if there is leading zero
					continue;
				IsLeadingZero = false;
				sb.Append (strList [i]); //construct result
			}

			if(sb.Length==0) //if all zeros, return a single "0"
				return "0";
			return sb.ToString ();
		}

	}


	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (Finder.LargestNumber (new int[]{ 3, 30, 34, 5, 9 })); //9534330
			Console.WriteLine (Finder.LargestNumber (new int[]{ 0, 0, 0, 0, 0 })); //0

		}
	}
}
