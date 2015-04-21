/**
Implement int sqrt(int x).

Compute and return the square root of x.


Idea: 
We can use Binary Search to solve this problem. For any positive integer X, the square root cannot be 
larger than X/2+1. So the searching range is (1, X/2+1). In fact, if X>1, then the square root cannot
be larger than X/2. Each pass we check the relationship between the middle element and X, then we can
reduce the size of the problem by half. 

Solution1:
Very similiar to normal Binary Search. The searching range is (1, X/2+1). Note that for the middle element
M, M*M might be overflow for 32bit integer. So the best way is we compare X/M and M to check if M is the result.
Condition: If M<=X/M and X/(M+1)<M+1 (M*M<X and (M+1)*(M+1)>X), then return M
Else If: X/M<M (M*M > X), continue searching on the left side, right = M-1.
Else: continue searching on the right side, left = M+1.

Time complexity: O(logn)


Solution2:
The method is excately the same as solutuion1. The only difference is we directly compare M*M and 
(M+1)*(M+1) with X to check if M is the square root. But note we must use long variable to hold the value
of them because they could possibly be overflow for 32 bit integer. 
Although the method is the same, this code is more clear and readable.

Time complexity: O(logn)
*/

//Solution1: Binary Search  Time:O(logn)
public class Solution {
    public int MySqrt(int x) {
        if(x<0) return -1; //edge case
        if(x==0) return 0;
        int left = 1, right=x/2+1;
        while(left<=right){
            int M = (left+right)/2;
            if(M<=x/M && x/(M+1)<M+1) //special condition to check M
                return M;
            else if (x/M<M)
                right=M-1;
            else
                left=M+1;
        }
        return -1;
    }
}

//Solution2: more clear Binary Search  Time: O(logn)
public class Solution{
    public int MySqrt(int x){
        if(x<0) return -1;
        if(x==0) return x;
        int left=1, right=x/2+1;
        while(left<=right){
            int M = (left+right)/2;
            long sqrtM = (long)M*M; //need these two values to check if M is the result
            long sqrtM1 = (long)(M+1)*(M+1); 
            if(sqrtM<=x && sqrtM1>x)
                return M;
            else if(sqrtM>x)
                right=M-1;
            else
                left=M+1;
        }
        return -1;
    }
}
