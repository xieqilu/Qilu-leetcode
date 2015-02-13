/**
 * A frog can jump 1 step or 2 steps at a time. There are totally
 * n steps, how many different ways the frog can jump to the nth step?
 * 
 * Follow-up:
 * A frog can jump 1 step or 2 steps or 3 steps at a time. There are totally
 * n steps, how many different ways the frog can jump to the nth step?
 * 
 * Solution:
 * This is a classic recursion problem.
 * 
 * If the frog can only jump 1 or 2 steps at a time.
 * F(1) = 1;
 * F(2) = 2;
 * Then F(n) = F(n-1) + F(n-2)
 * 
 * If the frog can jump 1, 2 or 3 steps at a time.
 * F(1) = 1;
 * F(2) = 2;
 * F(3) = 4;
 * Then F(n) = F(n-1) + F(n-2) + F(n-3)
 * 
 * If the frog can jump 1, 2, 3 or 4 steps at a time,
 * F(1) = 1;
 * F(2) = 2;
 * F(3) = 4;
 * F(4) = 8;
 * F(n) = F(n-1) + F(n-2)+F(n-3)+F(n-4);
 * 
 * 
 * 
 * 
 * */



using System;
using System.Collections.Generic;

namespace JumpFrog
{
	class Finder{
	
		//recursive solution, simple code, but worse time complexity
		public static int FindJump(int n){//Time: O(2^n), space:O(1)
			if (n == 1)
				return 1;
			if (n == 2)
				return 2;
			int result = FindJump (n - 1) + FindJump (n - 2);
			return result;
		}

		//iterative solution, no need to use list, time:O(n), space:O(1)
		//longer code, but better time complexity
		public static int FindJumpIterative(int n){
			if (n == 1)
				return 1;
			if (n == 2)
				return 2;
			int a = 1, b = 2, c = 0;
			for (int i = 3; i <= n; i++) {
				c = a + b;
				a = b;
				b = c;
			}
			return b;
		}

		//Iterative solution, time: O(n), space:O(1)
		public static int FindJumpThreeIterative(int n){
			if (n == 1)
				return 1;
			if (n == 2)
				return 2;
			if (n == 3)
				return 4;
			int a = 1, b = 2, c = 4, d = 0;
			for (int i = 4; i <= n; i++) {
				d = a + b + c;
				a = b;
				b = c;
				c = d;
			}
			return c;
		}

		//recursive solution, time: O(3^n), space:O(1)
		public static int FindJumpThree(int n){
			if (n == 1)
				return 1;
			if (n == 2)
				return 2;
			if (n == 3)
				return 4;
			int result = FindJumpThree (n - 1) + FindJumpThree (n - 2) + FindJumpThree (n - 3);
			return result;
		}
	}

	//Memorized Recursive Method, use a global list to store values, time:O(n),space:O(n)
	//this method is recursive method but faster than naive recursive method. And it's 
	//very fast when we need to do lookup for many times.
	class CacheFinder{
		private List<int> cache = new List<int> ();
		public CacheFinder(){
			this.cache.Add (1);
			this.cache.Add (2);
			this.cache.Add (4);
		}

		//Memorized Recursive Method, for one time: time: O(n), space:O(n)
		public int FindJumpMR(int n){
			if (n > cache.Count)
				cache.Add (FindJumpMR (n - 1) + FindJumpMR (n - 2)+FindJumpMR(n-3));
			return cache [n - 1];
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (Finder.FindJump (11));
			Console.WriteLine (Finder.FindJumpThree (9));
			Console.WriteLine (Finder.FindJumpIterative (11)); 
			Console.WriteLine (Finder.FindJumpThreeIterative (9));
			CacheFinder cf = new CacheFinder ();
			Console.WriteLine (cf.FindJumpMR (9));
		}
	}
}
