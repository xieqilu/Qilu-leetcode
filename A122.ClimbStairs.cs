/**
You are climbing a stair case. It takes n steps to reach to the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?


Solution:
The same question as Jump Frog. if there is only one stair, there is only one way to climb.
If there are two stairs, there are two way to climb. If n>=3 (n is the number of stairs)
Then C(n) = C(n-1)+C(n-2). 
So use iterative solution to solve it. Do not use recursive solution. Iterative solution
is much more efficient than recursive one.

Time complexity: O(n)
*/


public class Solution {
    public int ClimbStairs(int n) {
        if(n==1) return 1;
        if(n==2) return 2;
        int a=1, b=2, c=0;
        while(n>=3){
            c=a+b;
            a=b;
            b=c;
            n--;
        }
        return c;
    }
}
