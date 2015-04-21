/**
We have a list of N nodes with each node pointing to one of the N nodes. 
It could even be pointing to itself. We call a node ‘good’, if it satisfies one of the following properties: 

* It is the tail node (marked as node 1) 
* It is pointing to the tail node (node 1) 
* It is pointing to a good node 

You can change the pointers of some nodes in order to make them all ‘good’. 
You are given the description of the nodes. 
You have to find out what is minimum number of nodes that you have to change in order to make all the nodes good. 

Input: 
The first line of input contains an integer number N which is the number of nodes. 
The next N lines contains N numbers, 
all between 1 and N. 
The first number, is the number of the node pointed to by Node 1; 
the second number is the number of the node pointed to by Node 2;
the third number is the number of the node pointed to by Node 3 and so on. 

N is no larger than 1000. 

Output: 
Print a single integer which is the answer to the problem 

Sample Input 1: 
5 
1 
2 
3 
4 
5 

Sample output 1: 
4 

Explanation: 
We have to change pointers for four nodes (node #2 to node #5) to point to node #1. 
Thus 4 changes are required 

Sample input 2: 
5 
5 
5 
5 
5 
5 

Sample output 2: 
1 

Explanation: 
We have to just change node #5 to point to node #1 (tail node) which will make node #5 good. 
Since all the other nodes point to a good node (node #5), every node becomes a good node.
*/


//Solution
using System;

public class Test
{
	public static void Main()
	{
		int len = int.Parse(Console.ReadLine());
		int[] input = new int[len];
		for(int i=0;i<len;i++){
			int curr = int.Parse(Console.ReadLine())-1;
			input[i] = curr;
		}
		Console.WriteLine(GetMinNum(input,len));
	}
	
	private static int GetMinNum(int[] input, int len){
		if(len<2)
			return 0;
		int[] componentNum = new int[len];
		int currCompo = 1;
		componentNum[0] = currCompo;
		int result = 0;
		for(int i=1;i<len;i++){
			if(componentNum[i]>0)
				continue;
			currCompo++;
			int j=i;
			while(componentNum[j]==0){
				componentNum[j] = currCompo;
				j=input[j];
			}
			if(componentNum[j]==currCompo)
				result++;
		}
		return result;
	}
}

