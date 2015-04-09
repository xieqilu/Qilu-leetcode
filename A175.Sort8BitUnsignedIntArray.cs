/**
Given an integer array containing 1 million 8 bit unsigned integers, sort them 
efficiently.

Solution:
This is a classic count sort problem. The value of 8 bit unsigned integers are from
0 to 255. Since the array only contains 8 bit unsigned integers, we can use another array
count[] with length of 256 to store the number of appearence of each int in the input array.
Then we traverse the input array and for each int i, increment count[i]. Then we traverse
count[] array and rewrite the input array according to elements in count[] array.

In detail, assume count[i] is c, for each count[i], we put c elements with value i into
input array. We can use a pointer p (starting from 0) to keep track of the next index to
rewrite element, each time we put a new element to array[p], increment p.

Time: O(n)  Space: O(1) 
*/

using System;

public class Solution{
	public static void countSort(int[] array){
		int[] count = new int[256]; //count appearence
		foreach(int i in array)
			count[i]++;
		int p=0;
		for(int i=0;i<256;i++){
			for(int j=0;j<count[i];j++){
				array[p]=i;
				p++;
			}
		}
	}
}
public class Test
{
	public static void Main()
	{
		int[] test = new int[]{5,8,2,9,6,5,7,1,3,13,58,91,42,43,55,19,5,8,0,1};
		int[] test1 = new int[]{1};
		int[] test2 = new int[0];
		Solution.countSort(test);
		foreach(int i in test)
			Console.Write(i+" ");
		Console.WriteLine(" ");
		Solution.countSort(test1);
		foreach(int i in test1)
			Console.Write(i+" ");
		Console.WriteLine(" ");
		Solution.countSort(test2);
		foreach(int i in test2)
			Console.Write(i+" ");
		Console.WriteLine(" ");
	}
}
