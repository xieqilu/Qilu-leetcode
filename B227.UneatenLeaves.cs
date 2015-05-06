using System;
using System.Collections.Generic;

public class Test
{
	public static int UneatenLeaves(int[] a, int num){
		int res = 0;
		int numOfSubsets = 1<<a.Length;
		for(int i=1;i<numOfSubsets;i++){
			int product=1;
			int s = CountOne(i) & 1==1? 1:-1;
			for(int j=0;j<a.Length;j++){
				if(1<<j & i==1)
					product*=a[j];
			}
			res+= s*num/product;
		}
		return num-res;
	}
	
	private static int CountOne(int n){
		int count=0;
		while(n>0){
			n = n & (n-1);
			count++;
		}
		return count;
	}
	
	public static void Main()
	{
		Console.WriteLine(UneatenLeaves(new int[]{2,3,4}, 24));
	}
}
