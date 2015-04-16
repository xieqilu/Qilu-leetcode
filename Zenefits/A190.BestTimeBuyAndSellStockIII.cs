/**
Say you have an array for which the ith element is the price of a given stock on day i.

Design an algorithm to find the maximum profit. You may complete at most two transactions.

Note:
You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).


Idea:
Note we cannot engage in mutiple transcations at the same time. So the key point is how to avoid overlapping 
transcations. To ensure that two transcations never overlap each other, we can divide the array into two
parts at a point. Then if one transcation happens at the left part and the other at the right, they will never
overlap. And the dividing point could be any day (any element in the prices array). So we need to compute left
and right max profit for each day in the prices array, then get the maximum of [left profit+right profit] for 
every day, which is the result.

Note because we choose each element in the prices array as the dividing point, by using the above algorithm, we
can traverse all possible max profits for two transcations.


Solution:
The detailed solution is very similiar to the problem Get product of all elements except for current one, which I 
solved in LinkedIn Phone Interview.

Basically we will use two arraies left and right, in which left[i] is the max profit from [0...i] and right[i]
is the max profit from [i...last day]. We can construct the two arraies in linear time. Then just traverse the 
two arries at the same time, and get the maximum of (left[i]+right[i]) as final result.

Detailed Steps:
1, Construct left[]: traverse prices[]
Use lastMin to store min prices before ith day. In each pass, update lastMin and update left[i]
as Maximum of left[i-1] and prices[i]-lastMin.

2, Construct right[]: traverse prices[] in reverse order
Use lastMax to store max prices after ith day. In each pass, update lastMax and update right[i]
as Maximum of right[i+1] and lastMax-prices[i].

3, Traverse both of left[] and right[], in each pass, update result using left[i]+right[i].


Time complexity: O(n)
*/

public class Solution {
    public int MaxProfit(IList<int> prices) {
        if(prices.Count<2) return 0;
        int[] left = new int[prices.Count];
        int[] right = new int[prices.Count];
        
        //get left max profit for every day 
        int lastMin = prices[0]; //min price before the ith day
        left[0]=0;
        for(int i=1;i<prices.Count;i++){ //start from the second element
            lastMin = Math.Min(lastMin, prices[i-1]);
            left[i] = Math.Max(left[i-1], prices[i]-lastMin);
        }
        
        //get right max profit for every day
        int lastMax = prices[prices.Count-1]; //max price after the ith day
        right[prices.Count-1] = 0;
        for(int i= prices.Count-2;i>=0;i--){ //start from the second last element
            lastMax = Math.Max(lastMax, prices[i+1]);
            right[i] = Math.Max(right[i+1], lastMax-prices[i]); //use lastMax - prices[i]
        }
        
        //traverse left and right array to get result
        int max=0;
        for(int i=0;i<prices.Count;i++){
            max = Math.Max(max, left[i]+right[i]);
        }
        return max;
    }
}
