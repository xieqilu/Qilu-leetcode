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

namespace JumpFrog
{
	class Finder{
		public static int FindJump(int n){
			if (n == 1)
				return 1;
			if (n == 2)
				return 2;
			int result = FindJump (n - 1) + FindJump (n - 2);
			return result;
		}

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

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (Finder.FindJump (11));
			Console.WriteLine (Finder.FindJumpThree (7));
		}
	}
}
