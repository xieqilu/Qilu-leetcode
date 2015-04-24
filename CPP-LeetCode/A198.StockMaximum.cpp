/**
Problem Statement
Your algorithms have become so good at predicting the market that you now know what the share price of Wooden Orange Toothpicks Inc. (WOT) will be for the next N days.
Each day, you can either buy one share of WOT, sell any number of shares of WOT that you own, or not make any transaction at all. What is the maximum profit you can obtain with an optimum trading strategy?
Input
The first line contains the number of test cases T. T test cases follow:
The first line of each test case contains a number N. The next line contains N integers, denoting the predicted price of WOT shares for the next N days.
Output
Output T lines, containing the maximum profit which can be obtained for the corresponding test case.
Constraints
1 <= T <= 10 
1 <= N <= 50000
All share prices are between 1 and 100000
Sample Input
3 
3 
5 3 2 
3 
1 2 100 
4 
1 3 1 2 
Sample Output
0 
197 
3 
Explanation
For the first case, you cannot obtain any profit because the share price never rises. 
For the second case, you can buy one share on the first two days, and sell both of them on the third day. 
For the third case, you can buy one share on day 1, sell one on day 2, buy one share on day 3, and sell one share on day 4.
*/

//C++ Solution including STDIN and STDOUT
#include <iostream>
#include <vector>
using namespace std;

class Solution{
public:
	long GetProfit(vector<int>& stock, int len){
		if(len<2) return 0;
		long profit=0;
		int maxValue = 0;
		for(int i=len-1;i>=0;i--){
			if(stock[i]>=maxValue)
				maxValue=stock[i];
			else
				profit+=maxValue-stock[i];
		}
		return profit;
	}
	
};

int main() {
	//shows how to Parse STDIN in C++
	int num;
	cin>>num;
	for(int i=0;i<num;i++){
		int len = 0;
		cin>>len;
		vector<int> stock(len);
		for(int i=0;i<len;i++)
			cin>>stock[i];
		cout<<Solution().GetProfit(stock,len)<<endl; //write to STDOUT
	}
	return 0;
}

