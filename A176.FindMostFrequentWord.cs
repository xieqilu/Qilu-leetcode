/**
Find the most frequent word in a string text. The text contains word and period.

Solution:
1, get rid of non-letter char in the input string (using string.Replace());
In this problem, we only need to get rid of period, but we can use the same method
to get rid of other non-letter char.
2, split the input string by whitespace into a string array (using string.Split())
3, traverse the array and use a hashmap to store count for each word.
4, go through the hashmap and get the string that have the highest count.

Time: O(n)  Space: O(n)
*/
 

using System;
using System.Collections.Generic;

public class Solution{
	public static string findMostWord(string text){
		string newText = text.Replace(".", ""); //get rid of "."(period)
		string[] array = newText.Split(); //split string by whitespace
		Dictionary<string,int> dict = new Dictionary<string,int>();
		foreach(string s in array){
			if(dict.ContainsKey(s))
				dict[s]++;
			else
				dict.Add(s,1);
		}
		string result = "";
		int maxCount=0; //keep track of current max count
		foreach(KeyValuePair<string,int> pair in dict){
			if(pair.Value>maxCount){
				result = pair.Key;
				maxCount=pair.Value;
			}
		}
		return result;
	}
}
public class Test
{
	public static void Main()
	{
		string test = "I have a apple which is I have apple and have have is is apple apple apple.";
		//string test = "";
		Console.WriteLine(Solution.findMostWord(test));
	}
}
