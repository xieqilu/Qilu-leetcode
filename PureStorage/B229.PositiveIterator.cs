/**
given an IntegerIterator （which implements hasNext, next, remove),
implement a PositiveIterator that has hasNext, next, remove

Solution:
The key point is when we calling HasNext(), we must using integer iterator to try to get next positive
element, and after getting the next positive element, we must store it somewhere. So that if we keep
calling HasNext() won't affect the result of calling Next(). 
We can store the next positive to an integer variable prev, each time when calling HasNext(), 
we firstly check prev, if prev>0, directly return true. When calling Next(), 
we also firstly check prev by calling HasNext(), then return the value of prev and set prev to -1 again.


*/

using System;
using System.Collections.Generic;

//Suppose this is an working integer iterator
public class IntegerIterator{
	private int[] array;
	private int index;
	public IntegerIterator(int[] a){
		this.array = a;
		index = 0;
	}
	//check if there is next integer
	public bool HasNext(){
		if(index>array.Length-1)
			return false;
		return true;
	}
	
	//return next integer
	public int Next(){
		if(index>array.Length-1)
			throw new ArgumentException("no next element!");
		int res = array[index];
		index++;
		return res;
	}
	
	//remove last integer returned by iterator
	public void Remove(){
		if(index==0)
			throw new ArgumentException("no element to remove!");
		List<int> list = new List<int>(array);
		list.RemoveAt(index-1);
		array = list.ToArray();
	}
		
}


public class PositiveIterator{
	private IntegerIterator iter;
	private int prev; //hold the previous positive number
	public PositiveIterator(IntegerIterator i){
		this.iter = i; 
		prev = -1;
	}
	
	//check if there is next positive integer
	public bool HasNext(){
		if(prev>0)  //first look up prev
			return true;
		while(iter.HasNext()){
			prev = iter.Next();
			if(prev>0)
				return true;
		}
		return false;
	}
	
	//return next positive integer
	public int Next(){
		// if(prev>0){
		// 	int num = prev;
		// 	prev = -1;
		// 	return num;
		// }
		if(HasNext()){ //will firstly check prev in HasNext()
			int num = prev;
			prev = -1;
			return num;
		}
		throw new ArgumentException("no next positive number!");
	}
	
	//remove last returned positive integer
	public void Remove(){
		if(prev<0)
			iter.Remove();
		else
			throw new Exception("can't remove!");
	}
}

public class Test
{
	public static void Main()
	{
		//Test self Integer Iterator
		int[] a = new int[]{1,-2,-3,4,5,-6,7,-8,9};
		IntegerIterator it = new IntegerIterator(a);
		PositiveIterator iter = new PositiveIterator(it);
		Console.WriteLine(iter.HasNext()); //true
		Console.WriteLine(iter.HasNext()); //true
		Console.WriteLine(iter.HasNext()); //true
		Console.WriteLine(iter.Next()); //1
		Console.WriteLine(iter.Next()); //4
		Console.WriteLine(iter.Next()); //5
		
		
	}
}
