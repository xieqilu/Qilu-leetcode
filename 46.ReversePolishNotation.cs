//Evaluate the value of an arithmetic expression in Reverse Polish Notation.
//
//Valid operators are +, -, *, /. Each operand may be an integer or another expression.
//
//Some examples:
//["2", "1", "+", "3", "*"] -> ((2 + 1) * 3) -> 9
//["4", "13", "5", "/", "+"] -> (4 + (13 / 5)) -> 6

//Question to ask the interviewer
//How to handle the division by 0 situation?


//Note: we can use '0'=<char<='9' to ensure the char is a number

using System;
using System.Collections.Generic;
using System.Collections;

namespace ReversePolishNotation
{
	class Finder
	{
		public static int Calculate(string[] notations)
		{
			Stack<int> stack = new Stack<int> ();
			foreach (string s in notations) {
				if (s [0] == '-' && s.Length > 1 || (s [0] >= '0' && s [0] <= '9'))
					stack.Push (Convert.ToInt32 (s));
				else {
					int num1 = stack.Pop ();
					int num2 = stack.Pop ();
					if (s == "+")
						stack.Push (num2 + num1);
					else if (s == "-")
						stack.Push (num2-num1);
					else if (s == "*")
						stack.Push (num2 * num1);
					else if (s == "/")
						stack.Push (num2 / num1); //might need to handle the division
												  //by 0 situation
				}
			}
			return stack.Pop ();
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			string[] test = new string[]{ "2", "1", "+", "3", "*" };
			string[] test2 = new string[]{ "4", "13", "5", "/", "+" };
			string[] test3 = new string[]{ "4", "13", "0", "/", "+" };
			Console.WriteLine (Finder.Calculate (test));
			Console.WriteLine (Finder.Calculate (test2));
			//Console.WriteLine (Finder.Calculate (test3));
		}
	}
}
