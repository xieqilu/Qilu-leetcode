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
 * In Java, String.substring() method can take two arguments.
 * For example, String.substring(a,b) will get the substring starting
 * at index a and ending at index (b-1).
 * 
 * BUT in C#, String.substring method can also take two arguments,
 * For example, String,Substring(s,l) will get the substring starting
 * at index s and has the length of l.
 * 
 * So we can iterate the given string in one pass and keep track of the 
 * starting and ending (a and b) position of a word, then when we need to
 * append the word to StringBuilder, we can use b-a to get the length of 
 * the word, then use String.Substring(s,l) to get the word.
 * 
 * In detail:
 * we use int j to keep track of ending position of a word. In the loop, if 
 * current char is ' ', we let j=i. So that j would ignore all leading, trailing
 * or concecutive duplicate space and move with i. Until current char is not space,
 * j will stay at the last space found, then we check if s.charAt(i-1) is ' ' or i==0.
 * If it is, we found a word, then append the word to StringBuilder.
*/


using System;
using System.Text;
using System.Collections.Generic;

namespace ReverseWords
{
	public class Reverser
	{
		//Leetcode official solution, much simpler and better than mine!
		public static string ReverseBetter(string str){
			StringBuilder sb = new StringBuilder ();
			int j = str.Length;   // j is used to keep track of ending position of a word
			for (int i = str.Length - 1; i >= 0; i--) {
				if (str [i] == ' ')  //ignore all the leading, trailing and concecutive duplicate spaces
					j = i;
				else if(i==0 || str[i-1]==' '){  //Notice the use of else if, detect a word
					if (sb.Length != 0)  //if it is not the first word
						sb.Append (' ');
					sb.Append (str.Substring (i, j - i));
				}
			}
			return sb.ToString ();
		}


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
			string result = Reverser.Reverse ("    how     are     you    today    ");
			Console.WriteLine("/"+"    how     are     you    today    "+"/");
			Console.WriteLine ("/"+result+"/");
			Console.WriteLine ("/"+Reverser.ReverseBetter("    how     are     you    today    ")+"/");
			Console.WriteLine ("/" + "    " + "/");
			Console.WriteLine("/"+Reverser.Reverse("    ")+"/");
			Console.WriteLine("/"+Reverser.ReverseBetter("    ")+"/");
		}
	}
}
