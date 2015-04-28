/**
Given n numbers and k, determine the sum of each number to the power of k is Odd or Even.
In other words, given n numbers n1,n2,n3....., and a number k. Determine the result of 
n1^k+n2^k+n3^k...... is even or odd.
Note: the given number could be very large.

Idea: 
Because the given n numbers could be very large, so we cannot caculate each number to the power of k and
sum them together. It must cause Integer overflow. We can solve this problem based on the following fact:
1, If n is Odd number, then n^k must also be an odd number. If n is even number, then n^k must also be an even number.
2, If we add up n numbers, and in these n numbers there are k odd numbers. If k is an odd number, then the sum 
must be an odd number. If k is an even number, then the sum must be an even number.
(有n个数相加，如果其中奇数的个数是偶数个，那么结果一定是偶数。如果其中奇数的个数是奇数个，那么结果一定是奇数)

Then for this problem we don't need to caculate any number to the power of k, in fact, k won't affect the result at all.
We can analysis the input array and get the result.


Solution:
1, Traverse the input array and check each number is odd or even. 
2, Use a variable count to store the number of odd numbers in the input array.
3, if count is an even number, the sum is even. If count is an odd number, the sum is odd.

Note:
1, When checking a number is odd or even, we better use bitwise operator. If(n&1==1), it's odd, otherwise it's even.
2, If the input number could be larger than the largest Int, we can use long array to represent the input.
3, If the input number is so larger that long type cannot hold it, we can just check the last digit for each input
number to determine if it's odd or even.

Time complexity: O(n)   Space: O(1)
*/

//Solution: Time: O(n)  Space: O(1)
using System;
using System.Linq;

public class Test
{
	//Check if the sum of n^k is odd number
	public static bool IsSumEven(int[] nums){
		int count=0;
		foreach(int i in nums){
			if((i&1)==1) //i is odd number
				count++;
		}
		if((count&1)==0)
			return true;
		return false;
	}
	
	public static void Main()
	{
		int numCase = int.Parse(Console.ReadLine());
		for(int i=0;i<numCase;i++){
			int k = int.Parse(Console.ReadLine());
			int len = int.Parse(Console.ReadLine());
			string[] array = Console.ReadLine().Split();
			int[] nums = array.Select(y=>int.Parse(y)).ToArray();
			Console.WriteLine(IsSumEven(nums));
		}

	}
}
