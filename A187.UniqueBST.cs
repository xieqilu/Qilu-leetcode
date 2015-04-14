/**
Given n, how many structurally unique BST's (binary search trees) that store values 1...n?

For example,
Given n = 3, there are a total of 5 unique BST's.

   1         3     3      2      1
    \       /     /      / \      \
     3     2     1      1   3      2
    /     /       \                 \
   2     1         2                 3
   

Important Reference: 
卡塔兰数：http://zh.wikipedia.org/wiki/%E5%8D%A1%E5%A1%94%E5%85%B0%E6%95%B0
Catalan Number: http://en.wikipedia.org/wiki/Catalan_number


Idea:
This is a typical dynamic programming problem and related to catalan number-an important math number.
A BST don't have duplicate nodes, so given n number we actually have n nodes to build the BST. 

We can choose any node as the root, as long as the in-order traversal of this tree is an ascending sequence,
it would be a valid BST. After choosing the root, we divide all other nodes into two parts: nodes belong to
left subtree and nodes belong to right subtree. So for a specific root, the result is the product of number 
of left BST and number of right BST. There could be n different roots, so the final result is the sum of all
possible products of number of left BST and number of right BST.

If given n nodes, then the number of nodes in left/right subtree could be:
(0,n-1), (1,n-2), (2,n-3),....., (n-3,2), (n-2,1), (n-1,0). 
There are totally n possible combinations for above left/right pairs.

Assume f(n) is the number of BST for n, then we have the following relationship:
f(n) = f(0)*f(n-1)+f(1)*f(n-2)+...+f(n-2)*f(1)+f(n-1)*f(0)

This sequence is actually the sequence of catalen number.


Solution:
According to the above analysis, we can use an array with length of n+1 to store all intermediate results.
Edge case: if n<=0 return 0.
Initiallly set array[0]=1, array[1]=1. (base case)
Then we use the above relationship to caculate array[2] to array[n]. To do this, we will use a nested loop
so the running time would be O(n^2).

Time complexity: O(n^2)  Space complexity: O(n)

*/

//Solution: Dynamic Programming  Time: O(n^2)  Space: O(n)
public class Solution {
    public int NumTrees(int n) {
       if(n<=0) return 0; //edge case
       int[] result = new int[n+1]; //a DP array
       result[0] = 1;
       result[1] = 1;
       for(int i=2;i<=n;i++){
           for(int j=0;j<i;j++)
                result[i]+=result[j]*result[i-j-1];
       }
       return result[n];
    }
}
