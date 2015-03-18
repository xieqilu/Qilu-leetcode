/**
Say you have an array for which the ith element is the price of a given stock on day i.

Design an algorithm to find the maximum profit. You may complete as many transactions as you like 
(ie, buy one and sell one share of the stock multiple times). 
However, you may not engage in multiple transactions at the same time 
(ie, you must sell the stock before you buy again).


Solution:
This problem looks tricky but in fact the method is very simple.
We just need to get the point of this problem quickly enough.

For the array prices, no matter what the length is, the array can always be divided into two kinds of
subArrays: Ascedning subArrays and Descending SubArrays. Since at the same time we can only engage in
one transcation, the best strategy would always be as follows:
Buy the stock at the start of the first ascending subArray and sell it at the end. Then continue the action
on the second ascending subArray until the last ascending subArray.
For the descending subArray, we don't do any transcation, because it can only let us lose money.

So the task becomes to find all ascending subArray of prices. But we can further simplify the method. 
Notice that if we have an ascending subArray {1,2,4}, according to the above strategy, 
we need to buy the stock at 1 and sell it at 4. But if we buy it at 1, sell it at 2 then buy it at 2 and
sell it at 4. The overall profit is exactly the same. In other words, the sum of profits between all 
adjecent elements in an ascending subArray is equal to the profit between start and end.

Therefore, our taks is pretty simple as we only need to find all adjecent pair(i,j) 
in which i<j of the prices array. Then add the profit (j-i) together to get the overall max profit.

So in detail, we iterate the prices array, if prices[i]>prices[i-1], add prices[i]-prices[i-1] to result.

Time: O(n)
*/

public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices.Length<2) return 0;
        int profit=0;
        for(int i=1;i<prices.Length;i++){
            if(prices[i]>prices[i-1])
                profit+=prices[i]-prices[i-1];
        }
        return profit;
    }
}
