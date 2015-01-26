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

	//Pre process the document/text and find the closest pairs faster for multiple times

	//create a wrapper class to wrap a value(location) and an ID indicating which list it belongs to
	public class Word
	{
		public int value { get; set;}
		public string id {get;set;}

		public Word(int v, string i)
		{
			this.value = v;
			this.id = i;
		}
	}

	//use a hashtable to store each word and its locations.
	//key: word,  value: a list containing all of its locations
	public class PreProcessFinder
	{
		//private static List<string> words = new List<string> (){ "I", "am", "a", "good", "boy", "I", "good" };

		private static Dictionary<string, List<int>> dic = new Dictionary<string, List<int>> ();

		public static void DocumentAnalyzer(List<string> words)
		{
			for(int i=0;i<words.Count;i++) {
				if (!dic.ContainsKey (words [i])) {
					List<int> temp = new List<int> ();
					temp.Add (i);
					dic.Add (words [i], temp);
				} else {
					dic [words [i]].Add (i);
				}
			}
		}

//		public static void Print()
//		{
//			foreach (string s in words) {
//				Console.Write (s + ": ");
//				foreach (int i in dic[s]) {
//					Console.Write (i + " ");
//				}
//				Console.WriteLine ("");
//			}
//		}

		//retrive two lists from the hashtable with locations
		//merge the lists together and mantain the new list sorted
		//example: new list: {1a, 2a, 4b, 9a, 10b,15a,19b,25a}
		//traverse this merged list to find the minimum distance between two consecutive numbers
		//which have different list tags(ID).
		public static int FindClosestPairs(string a, string b)
		{
			List<int> aList = dic [a];
			List<int> bList = dic [b];
			List<Word> fList = new List<Word> ();


			int i = 0;
			int j = 0;

			while (i < aList.Count || j < bList.Count) {
				if (i<aList.Count &&(j == bList.Count || aList [i] < bList [j])) {
					Word w = new Word (aList[i], "a");
					fList.Add (w);
					i++;

					continue;
				} else if (j<bList.Count&&(i == aList.Count || aList [i] > bList [j])) {
					Word w = new Word (bList[j], "b");
					fList.Add (w);
					j++;
					continue;
				}
			}

			int min = int.MaxValue;

			for(int k=0;k<fList.Count-1;k++){
				if (fList [k].id != fList [k + 1].id) {
					int temp = fList [k + 1].value - fList [k].value;
					if (temp < min)
						min = temp;
				}
			}

			return min;
		}
	}

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
			List<string> words = new List<string> (){ "I", "am", "a", "good", "boy", "I", "good" };
			Console.WriteLine (Finder.FindShortestDis (text, "I", "good"));

			string test = "I am a good boy I good";
			Console.WriteLine (Finder.FindShortestDisText (test, "am", "good"));
			PreProcessFinder.DocumentAnalyzer (words);
			//PreProcessFinder.Print ();
			int res = PreProcessFinder.FindClosestPairs ("I", "good");
			Console.WriteLine (res);

		}
	}
}

