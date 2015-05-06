/**
第一个是football题，比赛得分可能得3分，也可能得6分，如果得了6分得话，
后面还可以选择什么touch down或者kick，分别又是得1分或2分，然后如果给你一个N分，问你有几种可能。
就是把这个想成一个树形结构，root是N，下面可以有3、6、7、8，然后每个再下面又3、6、7、8
这样递归一个就好了，代码很简单


Idea:
This problem is very similiar to Fibonacci sequence. We can solve it both bottom-up and top-down.
According to the description, each time, we can score 3 points, 6 points, 7 points or 8 points. 
Our task is to find out how many different combinations to score N points. For N points, we know
from the last play, we have four situations that can lead to N points which are N-3 points, N-6 
points, N-7 points and N-8 points. Suppose f(n) is the number of combinatons to score n points.
If we already know f(n-3), f(n-6), f(n-7), f(n-8), then by summing them up we can get f(n). So
the recursion relationship is as follows:
f(n) = f(n-6) + f(n-3) + f(n-7) + f(n-8)

And the base case is when we only need to score 0 points, we can always have one way to do that, we
don't play at all. And obviously if n is less than 0, no way to score a negative points. Thus we 
actually have two base cases:
f(0) = 1 and when n<0 f(n) = 0.

So we can easily sovel this problem using recursion. In order to make the algorithm more efficient,
we can use an array to cache results of recursion so that we don't need to caculate f(n) repeatedly.

We can also use Dynamic Programming to solve this problem from bottom-up and don't use recursion at all.


Solution1:  Naive Recursive solution
Don't use any cache, for any n, we use recursion to get its value. Then the calling structure is 
actualy like a tree in which each root has 4 children. Thus the time complexiy is O(4^n) and since
execution stack will hold all recursive call, so the space complexity is also likely O(4^n). Both
are not efficient.

Solution2: Recursive solution with caching
We can use an array with size of n+1 to cache all intermideate results for the recursive calls. 
And cache[n] is the number of combinations for scoring n points. Initially cache[0] is 1 and all
other cache[i] is -1. So in the recursive call, if n<0, return 0. Then we look up cache[n], if it
is -1, means cache[n] is not filled yet. So we use recursion to caculate cache[n] and return it. If
cache[n] is not -1, means it's been filled before, so we directly return its value. 
Then we will only fill each cache[i] for once, so the time and space complexity are both O(n).

Solution3: DP solution
We also use an array with size of n+1, and dp[i] is the number of combinations to score i points.
Then we can actually fill the array dp from smaller index to larger index (bottom-up). First set
dp[0] =1, then traverse from i=0 to n, for each i we add the value of dp[i] to dp[i+3], dp[i+6],
dp[i+7] and dp[i+8]. Because in the tree structure, dp[i] could be child of those 4 roots. If i+3,
i+6, i+7. i+8 are larger than n, we just ignore them since we only need to know dp[n]. After the
loop, return n.

Obviously the time and space complexity are both O(n). 
*/

using System;
using System.Collections.Generic;
public class Test
{
	//Solution1: Top-Down Naive Recursive Solution (with no caching) 
	//Time: O(4^n)  Space: O(1)
	public static int FootBall(int n){
		if(n==0)  //base case#1
			return 1;
		if(n<0)   //base case#2
			return 0;
		return FootBall(n-3) + FootBall(n-6) + FootBall(n-7) + FootBall(n-8);
	}
	
	//Solution2: Top-Down Recursive Solution with caching
	//Time: O(n)  Space: O(n)
	public static int FootBallCaching(int n){
		int[] cache = new int[n+1];
		for(int i=1;i<n+1;i++)
			cache[i] = -1;
		cache[0] = 1;
		return Helper(n, cache);
	}
	
	private static int Helper(int n, int[] cache){
		if(n<0)
			return 0;
		if(cache[n]!=-1) //if cache[n] is already caculated, directly get the value
			return cache[n];
		cache[n] = Helper(n-3,cache)+Helper(n-6,cache)+Helper(n-7,cache)+Helper(n-8,cache);
		return cache[n];
	}
	
	//Solution3: Bottom-Up Dynamic Programming Solution  Time: O(n) Space: O(n)
	//Better than naive recursive solution
	public static int FootBallIter(int n){
		int[] dp = new int[n+1];
		dp[0] = 1;
		for(int i=0;i<n+1;i++){ //O(n)
			if(i+3<n+1)
				dp[i+3]+=dp[i];
			if(i+6<n+1)
				dp[i+6]+=dp[i];
			if(i+7<n+1)
				dp[i+7]+=dp[i];
			if(i+8<n+1)
				dp[i+8]+=dp[i];	
		}
		return dp[n];
	}
	
	
	public static void Main()
	{
		Console.WriteLine("Test naive recursive solution");
		Console.WriteLine(FootBall(4)); //0
		Console.WriteLine(FootBall(6)); //2
		Console.WriteLine(FootBall(9)); //3
		Console.WriteLine(FootBall(12)); //5
		Console.WriteLine(FootBall(13)); //5
		Console.WriteLine("Test recursive solution with caching");
		Console.WriteLine(FootBallCaching(4)); //0
		Console.WriteLine(FootBallCaching(6)); //2
		Console.WriteLine(FootBallCaching(9)); //3
		Console.WriteLine(FootBallCaching(12)); //5
		Console.WriteLine(FootBallCaching(13)); //5
		Console.WriteLine("Test Dp solution");
		Console.WriteLine(FootBallIter(4)); //0
		Console.WriteLine(FootBallIter(6)); //2
		Console.WriteLine(FootBallIter(9)); //3
		Console.WriteLine(FootBallIter(12)); //5
		Console.WriteLine(FootBallIter(13)); //5
	}
}
