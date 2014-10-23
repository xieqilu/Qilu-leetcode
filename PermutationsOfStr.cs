//find all permutations of a string


using System;
using System.Collections.Generic;

namespace PermutationsOfString
{
	class MainClass
	{
		public class Finder
		{
			private void swap(ref char first, ref char second)
			{
				if (first == second)
					return;
				char temp = first;
				first = second;
				second = temp;

			}

			public void FindPermutation(char[]strArray)
			{
				int maxDepth = strArray.Length;
				this.GetPermutation (strArray, 0, maxDepth);
			}

			private void GetPermutation(char[] strArray, int recurisonDepth, int maxDepth)
			{
				int i;
				if (recurisonDepth == maxDepth) {
					Console.WriteLine (strArray);
					Console.WriteLine ("");
				} else {
					for (i = recurisonDepth; i < maxDepth; i++) {
						swap (ref strArray [recurisonDepth], ref strArray [i]); // try to put each element at the head, isolate each element
						this.GetPermutation(strArray, recurisonDepth+1, maxDepth);
						swap (ref strArray [recurisonDepth], ref strArray [i]); // restore strArray
					}
				}

			}
		}


		public static void Main (string[] args)
		{
			Finder finder = new Finder ();
			string teststr = "abcd";
			char[] testchar = teststr.ToCharArray ();
			finder.FindPermutation (testchar);
		}
	}
}
