/**
Given an Interger n, find the smallest number whose digits product is n.
return a string that is the smallest number in which the product of all digits is equal to n.
Each digit of the result must be between 2 and 9, inclusive.

If n cannot be represented by a result, n has a facotr which is a primary number larger than 9, return "-1".

Example:
Input: 24
Output: 234
Explaination: 
The possible results for 24 is 3222, 2322, 2232, 2223, 432, 423, 342, 324, 234, 243, in which 234 is the smallest.

Idea:
For this problem, we know the following facts:
1, The result should have the least number of digits.
2, For each digit we can choose from 2 to 9.
3, If we got k numbers that has the product as n, when constructing the result, we need to put the smallest number at the
tallest digit. In other words, put the k numbers in descending order from taller digit to lower digit.

So for the above example, 4 is a factor of 24, then we must include 4 into the result, if we do not include 4, then we have
to use two 2 thus make the result larger. So our primary task is to find the largest k numbers whose product is n, then
put these k numbers in descending order to construct the result.


Solution:
The solution is actually very simple, we don't need to consider starting from prime number at all. Because in this problem,
all numbers from 2 to 9 are treated equal for each digit, whether prime or not. Basically we try use numbers from 9 to 2 to 
divide n and each time we find a factor or n, we put it at the head of result string and update n. Since we start from the 
largest number to the smallest number, We can make sure the result has least digits and all digits are at descending order.

Detailed steps:
1, Use i to traverse from 9 to 2, for each i, check if it's a factor of n. 
2, If it is, update n to n/i and convert current i to string and attach it to the head of result string.
3, After step 2, don't update i, because i may still be a digit of updated n. So we use a while loop to check if i is
a factor of current n. While n%i==0, repeat the above process. 
4, When the inner while loop breaks, then n%i!=0, so we can continue the outter for loop and try another i.
5, After the for loop, check if current n is 1. If it is, return result string. If it's not, that means the original n has
a prime factor larger than 9, so return "-1".

Note: It's not a good idea to use StringBuilder to build the string, because each time we got a new digit we need to attach
it to the head of result string. We can directly use an empty result string, and use "+" to connect new digit and result string.

Time complexity: O(k), k is the least number of factor n has.
Space: O(1)
*/

static string getXNumber(int n) {
        string res = "";
        for(int i=9;i>1;i--){
            while(n%i==0){
                n/=i;
                res = i.ToString()+res;
            }
        }
        if(n!=1) 
            return "-1";
        return res;
    }
