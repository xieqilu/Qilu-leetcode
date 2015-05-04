/**
There are n tickets window in the railway station. The ith window has ai tickets avaiable. The 
price of ticket is equal to the number of tickets remaining in the window at that time. What is
the maximum amount money the station can earn by selling m tickets?

Input:
n m 
a1 a2 a3...

Output:
S

Constraints:
1<=n<=100,000
1<=ai<=100,000
1<=m<=a1+a2+a3...+ai

Sample Input:
2 4
2 5

Sample Output:
14

Explanation:
The maximum revenue would be obtained if all 4 tickets sold from the 2nd window at prices 
5,4,3,2 and total = 14.

Solution1:
For each window, the ticket price sequence is a descending sequence like (5,4,3,2,1), So our task
is to sell the most expensive ticket for each pass. Then we can use a function to get the maximum
element of the window array with size n, each time add the max element to res then put max element-1
to the array. Then we need to repeat this process by m times. Since m<a1+a2+....an, m is at most n^2.
Each time finding maximum element in the array would take O(n) time, so total time complexity is
O(m*n) = O(n^3)

Solution2:
Notice this problem is like we have m sorted array, and each time we need to get the current max 
element from them and add max element-1 to them. So we can use a max heap or priority queue, each
pass we get the top element and put top element-1 to the heap. Then each pass need O(logn) time.
So time complexity is O(mlogn) = O(n^2logn).

Solution3:
The best solution of this problem using Arithmetic Sequence(等差数列). The key point is what we have
is not m random sorted array. Actually each array will have elements that decreased concecutively.
For example, if the original prices in two windows is 4 and 9 and we need to sell totall 7 tickets.
9-4=5, so we know that the first 5 tickets should be sold at the second window. We don't need to get
max ticket each time. In fact, by getting a[i]-a[i-1], we will know how many tickets can we sell in
this pass. Also, we can keep track of how many windows to sell tickets in this pass. Using the same
example, after selling the first 5 tickets, the prices would be 4,4 and we need to sell 2 more tickets.
So we immideately know we need to sell one ticket from each window. In fact, no matter how many tickets
we need to sell, since we only have two windows left, we need to sell them evenly at two windows.

Thus, we can traverse the input array in reverse order. In each pass, we need to know how many tickets
to sell, how many windows to sell and how many tickets to sell at each window. Then we can use 
Arithmetic Sequence to caculate the the revenue for this pass. The initial sort would take O(nlogn),
so the time complexity is O(nlogn+n) = O(nlogn).

*/


using System;
using System.Linq;

public class Test
{
	//Best Solution: Arithmetic Sequence  Time: O(nlogn)
	public static long GetMaxRevenue(int[] a, int n, long m){
		Array.Sort(a); //sort the array in ascending order
		long res = 0; //using long to avoid integer overflow
		for(int i=n-1;i>=0;i--){
			int num = n-i; //number of maximum windows
			//p is the next smaller window than current
			int p = i>0? a[i-1]:0;
			//the number of ticktes to sell in this pass
			long tSell = Math.Min((long)num*(a[i]-p), (long)m);
			//the number of tickets to sell in each window 
			long eSell = tSell/num;
			//get sum of Arithmetic Sequence: (a1+an)*n/2
			//(a[i]+a[i]-d+1)*eSell/2*l
			res+= (2*a[i]-eSell+1)*eSell/2*num;
			//if tSell is not multiply of num, need to sell (tSell%num) tickets
			res+= (tSell%num)*(a[i]-eSell);
			m-=tSell;
			if(m==0) 
				break;
		}
		return res;
	}
	
	public static void Main()
	{
		string[] firstLine = Console.ReadLine().Split();
		int n = int.Parse(firstLine[0]); //size of array
		long m = long.Parse(firstLine[1]); //total number of tickets
		string[] secondLine = Console.ReadLine().Split();
		int[] a = secondLine.Select(y=>int.Parse(y)).ToArray();
		Console.WriteLine(GetMaxRevenue(a, n, m));
	}
}
