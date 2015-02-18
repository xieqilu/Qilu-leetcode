/**
Reverse a string
Example:  "Hello I am a boy"
output:  "boy a am I Hello"

Clarification:

What constitutes a word?
A sequence of non-space characters constitutes a word.

Could the input string contain leading or trailing spaces?
Yes. However, your reversed string should not contain leading or trailing spaces.

How about multiple spaces between two words?
Reduce them to a single space in the reversed string.

Solution:
Basic idea: Reversely traverse the given string and for each word,
reversely append the char to the new stringBuilder.
After the loop, append the last word to the stringBuilder

To get rid of the leading, trailing and concecutive duplicate spaces,
we need to preprocess the string to remove all leading, trailing and concecutive 
duplicate spaces

Leetcode better solution:
*/


using System;
using System.Text;
using System.Collections.Generic;

namespace ReverseWords
{
	public class Reverser
	{
		private static bool IsAllSpace(string str){ //check if a string contains only spaces
			foreach (char c in str) {
				if (c != ' ')
					return false;
			}
			return true;
		}

		public static string Reverse(string str)
		{
			if (IsAllSpace (str))
				return "";

			List<char> strlist = new List<char> (); //convert str to a char list
			foreach (char c in str)
				strlist.Add (c);

			                                       
			while (strlist [0] == ' ') {         //remove all leading spaces
				strlist.RemoveAt (0);
			}
				
			while (strlist [strlist.Count-1] == ' ') { //remove all trailing spaces
				strlist.RemoveAt (strlist.Count-1);
			}

			int prev = 0;     //remove all concecutive duplicate spaces
			for(int i =1;i<strlist.Count-1;i++){
				if (strlist[prev]==' ' && strlist[i]==' ') {
					strlist.RemoveAt (i);
					i--;
				} else
					prev = i;
			}

			StringBuilder strb = new StringBuilder ();
			List<char> charlist = new List<char> ();

			for (int i =strlist.Count-1;i>=0;i--) { //from the end of the string
				if(strlist[i]==' ')
				{
					for(int j = charlist.Count-1;j>=0;j--) //charlist contains "uoy", we need to add scan from the end to head
						strb.Append(charlist[j]);
					strb.Append(' ');
					charlist.Clear (); //clear the list for next word

				}
				else charlist.Add(strlist[i]);
			}
			for (int i = charlist.Count - 1; i >= 0; i--) {
				strb.Append (charlist [i]);
			}

			string result = strb.ToString();
			return result;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			string result = Reverser.Reverse ("    how     are     you    today");
			Console.WriteLine("/"+"    how     are     you    today    "+"/");
			Console.WriteLine ("/"+result+"/");
			Console.WriteLine ("/" + "    " + "/");
			Console.WriteLine("/"+Reverser.Reverse("    ")+"/");
		}
	}
}
