/**
 * Given a string and a set of rules. Try to compress the string
 * using the given rules. Return the most compressed string.
 * 
 * Rules:
 * AB->AA,
 * BA->AA,
 * CB->CC,
 * BC->CC,
 * AA->A,
 * CC->C,
 * 
 * Example: given ABBCC, output: AC
 * 
 * Solution:
 * According to the rules, any B that is next to A or C could be removed.
 * In fact, if the string contains any A or C, then all the B in the string
 * can be removed immideately. 
 * And any concecutive A or C can be compressed as a single A or C.
 * 
 * So based on the above facts, the most compressed string would be as the following format:
 * ACACAC.....ACAC
 * 
 * But there are several exceptions:
 * 1, the string only contains B, like "BBBBBBBB", then we cannot compress it, so 
 * return the original string
 * 
 * 2, the string is null or empty string, we return the original string.
 * 
 * So the steps is as follows:
 * First we handle the two edge cases
 * Then we convert the string to a list of chars.
 * Then traverse the list, remove all B.
 * Then traverse the list again, convert all concecutive A and C to single A and C
 * Return compressed string.
 * */


using System;
using System.Collections.Generic;
using System.Text;

namespace CompressStringCodility
{
	class Finder{

		private static bool IsAllB(string str){ //check if the str contains only 'B'
			foreach (char c in str) {
				if (c != 'B')
					return false;
			}
			return true;
		}

		public static string CompressString(string str){ //time:O(n),space:O(n) n is the size of str,
			if (str == null || str == "") //handle edge cases
				return str;
			if (IsAllB (str))
				return str;

			List<char> list = new List<char> (); //convert str to list
			foreach (char c in str)
				list.Add (c);

			for (int i = 0; i < list.Count; i++) { //remove all B from the list
				if (list [i] == 'B') {
					list.RemoveAt (i); //every time we remove an element, the list will be reconstructed
					i--; //do not forget this
				}
			}

			char prev = list [0];
			for (int i = 1; i < list.Count; i++) { //remoive all concecutive A and C
				if (list [i] == prev) {
					list.RemoveAt (i);
					i--; //do not forget this
				} else {
					prev = list [i];
				}
			}
			StringBuilder sb = new StringBuilder (); //use stringBuilder to build compressed string
			foreach (char c in list)
				sb.Append (c);
			string compressedStr = sb.ToString ();
			return compressedStr;

		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine(Finder.CompressString("ABBCC")); //AC
			Console.WriteLine(Finder.CompressString("BBBBBBBB")); //BBBBBBBB
			Console.WriteLine(Finder.CompressString("CCCBBBBABBBACBBAACBA")); //CACACA
			Console.WriteLine(Finder.CompressString("")); //""
			Console.WriteLine(Finder.CompressString(null));
			Console.WriteLine(Finder.CompressString("ACACACACAAAAAAAAAA"));//ACACACACA
		}
	}
}
