//Write a string compress function: give you "RRGB" and return "R2G1B1"
//CC150 1.5 

//solution: 
//use a StringBuilder to build the result string
//use a char last to keep track of the last found char in the string
//use an int count to store how many same concecutive char
//traverse from the second char of string, if current char == last, count++
//else: StringBuilder.append(current char), StringBuilder.append(count)
//after the loop, append the current char and count to StringBuilder

//If cannot use StringBuilder, use a char array instead
//Note that count is possibely more than two digits, so must convert 
//count to char array, then insert each digit to the result char array
//use an int index to keep track of the current insertion location of the char array

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace StringCompress
{
	public class Finder{
		public static string Compress(string str){
			if (str == null)
				return null;
			StringBuilder sb = new StringBuilder ();
			char last = str [0];
			int count = 1;
			for (int i = 1; i < str.Length; i++) {
				if (str [i] == last) {
					count++;
				} else {
					sb.Append (last);
					sb.Append (count);
					last = str [i];
					count = 1; //do not forget reset count
				}
			}
			sb.Append (last);//append last result
			sb.Append (count);
			string result = sb.ToString ();
			return result;
		}

		public static string CompressNoStringBuilder(string str){
			if (str == null)
				return null;
			int length = str.Length;
			char[] temp = new char[length*2];//result string is at most twice as long as the input string
			char last = str [0];
			int index = 0;
			int count = 1;

			for (int i = 1; i < length; i++) {
				if (str [i] == last) {
					count++;
				} else {
					index = SetChar (temp, last, index, count);
					count=1;
					last = str [i];
				}
			}
			index = SetChar (temp, last, index, count);//append last result
			string result = new string (temp);
			return result;
		}

		//put current char and count correctly to char array
		private static int SetChar(char[] arr, char c, int index, int count){
			arr [index] = c;
			index++;
			//it's possible the count has more than one digit, so must convert it to a char array
			//instead of a single char
			char[] cnt = count.ToString ().ToCharArray (); //convert int to a char array
			foreach(char ch in cnt){
				arr [index] = ch;
				index++;
			}
			return index;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			string test = "RRGB";
			Console.WriteLine (Finder.Compress(test));
			Console.WriteLine (Finder.Compress("aaaaaaaaaaaaaaaaaaaaaaadasdsadasdf"));
			Console.WriteLine (Finder.Compress("a"));
			Console.WriteLine (Finder.Compress("abcd"));

			Console.WriteLine (Finder.CompressNoStringBuilder(test));
			Console.WriteLine (Finder.CompressNoStringBuilder("aaaaaaaaaaaaaaaaaaaaaaadasdsadasdf"));
			Console.WriteLine (Finder.CompressNoStringBuilder("a"));
			Console.WriteLine (Finder.CompressNoStringBuilder("abcd"));
		}
	}
}
