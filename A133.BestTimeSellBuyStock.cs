/**
Say you have an array for which the ith element is the price of a given stock on day i.

If you were only permitted to complete at most one transaction (ie, buy one and sell one share of the stock), 
design an algorithm to find the maximum profit.


Solution:
The puporse of this problem is to find the max value of (prices[i]-prices[j]) where j<i. If this max value is 
less than 0, we just return 0. Because if we do not do any transcation, the profit is 0.

The brute force method is for each p[i], find all p[i]-p[j] where j<i and update maxProfit in the same time.
But this is very unefficient, the time complexity is O(n^2).

We easily solve this problem using Dynamic Programming in one pass. For each p[i], what we need is the minimum
elements before it, so we can get the maxProfit for p[i] and try to update the final maxProfit. Thus, we can 
use an integer lastMin to store this information. For each p[i], lastMin is the minimum element before p[i-1].
Then we can update lastMin to the minimum of lastMin and p[i-1] (which is the minimum element before p[i]) and
then update maxProfit. Initially lastMin is p[0] and start iterate p from the second element.

Edge Case: If the input array p is empty, we just return 0.
*/


//Dynamic Programming Time:O(n)  Space:O(1)
public class Solution {
    public int MaxProfit(int[] prices) {
        int len = prices.Length, maxProfit = 0;
        if(len==0) return 0;
        int lastMin=prices[0];
        for(int i=1;i<len;i++){
            lastMin=Math.Min(lastMin,prices[i-1]);
            if(prices[i]-lastMin>maxProfit)
                maxProfit=prices[i]-lastMin;
        }
        return maxProfit;
    }
}
