/**
Reverse digits of an integer.

Example1: x = 123, return 321
Example2: x = -123, return -321

Clarification:
Here are some good questions to ask before coding. Bonus points for you if you have already thought through this!

If the integer's last digit is 0, what should the output be? ie, cases such as 10, 100.
We shoudl just output 1.

Did you notice that the reversed integer might overflow? Assume the input is a 32-bit integer, 
then the reverse of 1000000003 overflows. How should you handle such cases?

For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.


Solution1: (My Solution)
First convert the input int to a string, then we can easily reverse the string using a StringBuilder.
Then check if the input int is a negative number, if it is, append '-' to StringBuilder and get rid 
of the first char of the string (converted from input int).
Then we reverse the string using StringBuilder and get a new string. And we must use Int32.TryParse to
try converting the new string to an Interger. If the conversion succeed, we return the converted result.
If the conversion failed, then the converted int should be overflow/underflow, we just return 0.

Solution2: (Leetcode official Solution)
This solution doesn't use StringBuilder, just convert the Integer directly.
Each time we get the last digit of input x by x%10, and shift output ret to left
by 1 digit (ret*10), and then add x%10 to ret. After that, we update x to get rid of the last
digit by x=x/10;
In the loop, each time before we do the above operation, we need to check if Math.Abs(ret) is 
larger than Int32.MaxValue/10. We must do the check 1 digit ahead to avoid the above operation
producing wrong answer.
*/


using System;
using System.Text;

namespace A107ReverseInteger
{
	//My Solution
	public class Solution1 {
		public int Reverse(int x) {
			string str = x.ToString (); //convert int to string for easy reversing
			StringBuilder sb = new StringBuilder ();
			if (x < 0) { //if x is negative number, append '-' first
				sb.Append (str[0]);
				str = str.Substring (1);
			}
				
			for (int i = str.Length - 1; i >= 0; i--) //reverse the string
				sb.Append (str [i]);
			int result = 0;
			//use Int32.TryParse to handle Integer overflow/underflow issue
			//Int32.TryParse will try to parse the input string to int result
			//if the parse can be done, it will return true.
			//if the parse cannot be done, it will return false.
			if (Int32.TryParse (sb.ToString (), out result))
				return result;
			return 0;
		}
			
	}

	//Leetcode official solution
	public class Solution2 {
		public int Reverse(int x) {
			int ret = 0;
			while (x != 0) {
				// handle overflow/underflow, must check if ret will be overflow 1 dight ahead
				// Otherwise, the calculation below will produce wrong answer
				if (Math.Abs(ret) > Int32.MaxValue/10) {
					return 0;
				}
				ret = ret * 10 + x % 10; //shift ret to left by 1 digit, and add the last digit of x
				x /= 10; //shift x to right by 1 digit
			}
			return ret;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (new Solution1 ().Reverse (1534236469));
			Console.WriteLine (new Solution1 ().Reverse (-123125324));
			Console.WriteLine (new Solution1 ().Reverse (1000000003));
			Console.WriteLine (new Solution2 ().Reverse (1534236469));
			Console.WriteLine (new Solution2 ().Reverse (-123125324));
			Console.WriteLine (new Solution2 ().Reverse (1000000003));
		}
	}
}
