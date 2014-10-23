using System;
using System.Diagnostics;

namespace RegularExpressionMatching
{

	public class Matcher
	{
		public bool isMatch(string s, string p, int s_offset, int p_offset)
		{
			//Debug.Assert (s && p);
			if (s_offset == s.Length)
				return (p_offset == p.Length);
			if (s_offset+1 == s.Length || s [s_offset + 1] != '*') { //s[s_offset+1] is easy to be out of range
				Debug.Assert (s [s_offset] != '*');
				bool result = (s [s_offset] == p [p_offset] || s [s_offset] == '.' && p_offset!= p.Length);
				return result && isMatch (s, p, s_offset + 1, p_offset + 1);
			} else {
				while (s [s_offset] == p [p_offset] || s [s_offset] == '.' && p_offset!= p.Length) {
					if (isMatch (s, p, s_offset + 2, p_offset))
						return true;
					p_offset++;
				}
			}

			return isMatch (s, p, s_offset + 2, p_offset);
		}
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
			string s = "ab*aa";
			string p ="aaa";
			Matcher matcher = new Matcher ();
			bool result = matcher.isMatch (s, p, 0, 0);
			Console.WriteLine (result);
		}
	}
}
