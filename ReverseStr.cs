//Reverse a string
//Example:  "Hello I am a boy"
//output:  "boy a am I Hello"

using System;
using System.Text;
using System.Collections.Generic;

namespace ReverseWords
{
	class MainClass
	{
		public class Reverser
		{
			public string Reverse(string str)
			{
				StringBuilder strb = new StringBuilder ();
				List<char> charlist = new List<char> ();

				for (int i =str.Length-1;i>=0;i--) { //from the end of the string
					if(str[i]==' ' || i==0)
					{
						if(i==0)
							charlist.Add(str[i]); //add last char into the charlist
						for(int j = charlist.Count-1;j>=0;j--) //charlist contains "uoy", we need to add scan from the end to head
							strb.Append(charlist[j]);
						strb.Append(' ');
						charlist = new List<char>(); //empty the charlist to receive the next word

					}
					else charlist.Add(str[i]);
				}
				string result = strb.ToString();
				return result;
			}
		}
		public static void Main (string[] args)
		{
			Reverser reverser = new Reverser ();
			string teststr = "how are you today";
			string result = reverser.Reverse (teststr);
			Console.WriteLine (result);
		}
	}
}
