/**
The famous Fizz Buzz Test:
// FizzBuzz

// multiple of 3 -> "Fizz"
// multiple of 5 -> "Buzz"
// multiple of BOTH 3 and 5 -> "FizzBuzz"

// fizzBuzz(1, 6) → ["1", "2", "Fizz", "4", "Buzz"]
// start and end are integers fizzBuzz(start, end)

Solution1:
This problem doesn't require much coding skill at all. Just to test if I could solve it 
clean and quickly. 
Solution is pretty simple:
for i from begin to end:
if i is divisable by 3 and 5 - > "FizzBuzz"
else if i is divisable by 3 -> "Fizz"
else if i is divisable by 5 -> "Buzz"
else->i

Time complexity: O(n)  Space: O(n)

Solution2:
We can improve the solution a little bit by using the fact that if i is divisable by both
3 and 5, the output is "FizzBuzz" which is the sum of "Fizz" and "Buzz". So we can use a 
string to hold the output for each i, then if i is divisable by 3, add "Fizz" to it, then
if i is divisable by 5, add "Fizz" to it. Then if the out put string is still empty, we
add i to it. Then add the string to ouput list finally.

Time complexity: O(n)  Space: O(n)
*/

using System;
using System.Collections.Generic;
public class Test
{
	//Solution1
	public static List<string> FizzBuzz(int begin, int end){
		List<string> result = new List<string>();
		for(int i=begin;i<end;i++){
			string res="";
			if(i%3==0 && i%5==0)
				res = "FizzBuzz";
			else if(i%3==0)
				res = "Fizz";
			else if(i%5 == 0)
				res = "Buzz";
			else
				res = i.ToString();
			result.Add(res);
		}
		return result;
	}
	
	//Solution2
	public static List<string> FizzBuzz2(int begin, int end){
		List<string> result = new List<string>();
		for(int i=begin;i<end;i++){
			string res = "";
			if(i%3==0)
				res+="Fizz";
			if(i%5==0)
				res+="Buzz";
			if(res=="")
				res = i.ToString();
			result.Add(res);
		}
		return result;
	}
	
	public static void Main()
	{
		string[] input = Console.ReadLine().Split();
		int begin = int.Parse(input[0]);
		int end = int.Parse(input[1]);
		List<string> output = FizzBuzz(begin,end);
		foreach(string s in output)
			Console.Write(s+" ");
		Console.WriteLine(" ");
		output = FizzBuzz2(begin,end);
		foreach(string s in output)
			Console.Write(s+" ");
	}
}
