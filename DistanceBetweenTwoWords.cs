//find shortest distance between two words in a string test
//example: 
//input: "I am a good girl", find distance of "I" and "good"
//output: distance is 3
//if the given input is a string text instead of a string array, 
//we need to split the text by ' ' first, the use the method

using System;
using System.Collections.Generic;
using System.Collections;

namespace WordsDistanceInString
{
	public class Finder
	{

		//if input is a long string text, use this method
		public static int FindShortestDisText(string text, string a, string b)
		{
			string[] textWords = text.Split (' ');
			return FindShortestDis (textWords, a, b);
		}


		//if input is a string array, use this method
		public static int FindShortestDis(string[] text, string a, string b)// Time: O(n)
		{
			int state = 0; //0: not found, 1: a is found, 2: b is found
			int previous=0;
			int length = text.Length;
			int minDistance = int.MaxValue;

			for (int i = 0; i < length; i++) {
				if (text[i].Equals(a)|| text[i].Equals(b)) {
					if (state == 0) {
						state = text [i].Equals (a) ? 1 : 2;
						previous = i;
					}

					else if (state == 1) {
						if (text [i].Equals (b)) {
							if (minDistance > i - previous)
								minDistance = i - previous;
							state = 2;
						}
						previous = i;
					}

					else if (state == 2) {
						if (text [i].Equals (a)) {
							if (minDistance > i - previous)
								minDistance = i - previous;
							state = 1;
						}
						previous = i;
					}
				}
			}

			if (minDistance == int.MaxValue) //at least one of the two words is not found
				throw new ArgumentException ("Words Not Found");
			return minDistance;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			string[] text = new string[]{ "I", "am", "a", "good", "boy","I","good" };
			Console.WriteLine (Finder.FindShortestDis (text, "I", "good"));

			string test = "I am a good boy I good";
			Console.WriteLine (Finder.FindShortestDisText (test, "am", "good"));

		}
	}
}
