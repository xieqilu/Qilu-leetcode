/**
This kind of happy number may also be called pure number. 

A happy number is a number defined by the following process: 
Starting with any positive integer, replace the number by the square of the sum of all its digits, 
and repeat the process until the number equals 1 (where it will stay), 
or it loops endlessly in a cycle which does not include 1. 
Those numbers for which this process ends in 1 are happy numbers.

Example: 
8 is a happy number
8^2 = 64
(6+4)^2 = 100
(1+0+0)^2 = 1

4 is not a happy number
4^2 = 16
(1+6)^2 = 49
(4+9)^2 = 169
(1+6+9)^2 = 196
(1+9+6)^2 = 196
........


Solution:
Use the excately same method as the original Happy Number problem. Use a HashSet to store all
previously appeared number. And if the current number is already in the HashSet, terminate the while
loop. Check if the last number is 1, if it is, return true, otherwise return false.
The only difference is the way to caculate next number. We need to get the sum of all digits, then 
get square of the sum to produce next number.

Time Complexity: maybe also O(log*n) 


using System;
using System.Collections.Generic;

public class Test
{
	public static bool IsHappy(int n){
		HashSet<int> set = new HashSet<int>();
		while(!set.Contains(n)){
			set.Add(n);
			int digitSum=0;
			while(n>0){
				digitSum+=n%10;
				n/=10;
			}
			n=digitSum*digitSum;
		}
		return n==1;
	}
	
	public static void Main()
	{
		for(int i=1;i<100;i++){
			Console.WriteLine(i+": " +IsHappy(i));
		}
	}
}
