/**
Flipping Bits

Descirption:
You are given an array a of size N. The elements of the array area[0], a[1], ... a[N - 1], where each a is either 0 or 1. You can perform one transformation on the array: choose any two integers L, and R, and flip all the elements between (and including) the Lth and Rth bits. In other words, L and R represent the left-most and the right-most index demarcating the boundaries of the segment whose bits you will decided to flip. ('Flipping' a bit means, that a 0 is transformed to a 1 and a 1 is transformed to a 0.)

What is the maximum number of '1'-bits (indicated by S) which you can obtain in the final bit-string?

Input Format:
The first line has a single integerN
The next N lines contains the Nelements in the array,a[0], a[1], ... a[N - 1], one per line.
Note: Feel free to re-use the input-output code stubs provided.

Output format:
Return a single integer that denotes the maximum number of 1-bits which can be obtained in the final bit string

Constraints:
1 ≤ N ≤ 100,000. 
d can be either 0 or 1. It cannot be any other integer.
0 ≤ L ≤ R < N

Sample Input:
810010010

Sample Output:
6

Explanation:
We can get a maximum of 6 ones in the given binary array by performing either of the following operations:
Flip [1, 5] ⇒ 1 1 1 0 1 1 1 0
or 
Flip [1, 7] ⇒ 1 1 1 0 1 1 0 1


Solution:
The bits array will only contain 0 and 1. So we can view 0 as -1, then the task is to find the 
minimum sum of subArray in bits, which is the subArray that has the largest value of
(number of 0s- number of 1s). 

We can use the same method as find maximum sum subArray to find minimum sum subArray. Before that,
we need to traverse bits first to get original number of 1s. Suppose the minimum sum is minRes and
original number of 1s is currentOne. Then minRes should be a negative number, so return currentOne-minRes.

Edge case:
All edge cases can be handled using the above method. If all elements are 0, then we add all -1 together.
If all elements are 1, then the minRes should be 0, which means we do not do flip any bit.

Time: O(n)  Space: O(1)
*/

using System;
using System.Linq;

public class Test
{
	public static int FlippingBits(int[] bits){
		int currentOne = 0; //original number of 1s in bits
		foreach(int i in bits){
			if(i==1)
				currentOne++;
		}
		int minRes = MinSubArray(bits); //minRes is negative number
		return currentOne-minRes;
	}
	
	//find the min sum of subArray in bits
	private static int MinSubArray(int[] bits){
		int minRes = 0, minHere=0;
		foreach(int i in bits){
			if(i==0)
				minHere-=1;
			else
				minHere+=1;
			minHere = Math.Min(minHere,0); //keep minHere<=0
			minRes = Math.Min(minHere, minRes);
		}
		return minRes; //-minRes is the number of 1 can be added to the array after flipping
	}
	
	public static void Main()
	{
		int num = int.Parse(Console.ReadLine());
		for(int i=0;i<num;i++){
			string[] input = Console.ReadLine().Split();
			int[] bits = input.Select(y=>int.Parse(y)).ToArray();
			Console.WriteLine(FlippingBits(bits));
		}
	}
}
