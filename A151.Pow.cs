/**
Implement pow(x, n). Pow(x,n) returns the value of x^n.


Idea:
It's not a hard problem, but impelemnt the best solution in a short time requires some thinking.
Notice that in this pow method, x is a double and n is an Integer. So n must be positive int, negative int
or zero, n could not have any decimal digits, we don't need to consider that.

Then we have two edge cases:
1, when x is 0, no matter what n is, return 0.
2, when n is 0, no matter what x is, return 1.


Solution1: Naive solution
If n is a positive Integer, we need to simply mutiply x for n times. (1*x*x....*x) 
If n is a negative Integer, we use x to divide 1 for n times. (1/x/x..../x)
Also we need to handle the above two edge cases. 
Although this method works, the running time is not good enough. We surely can do better
than this.

Time Complexity: O(n)


Solution2: Recursive solution
There is a very obvious relationship between pow(x,n) and pow(x,n/2).
If n%2 ==0, no matter n>0 or n<0, then pow(x,n) = pow(x,n/2)*pow(x,n/2).
If n%2 ==1, and n>0, then pow(x,n) = pow(x,n/2)*pow(x,n/2)*x
If n%2 ==1, and n<0, then pow(x,n) = pow(x,n/2)*pow(x,n/2)/x
Using this relationship, we can divide and conquer this problem. In each pass, we can
reduce half the size of this problem to n/2. Then get a much better running time.

Note that we can use n%2 to determine if n is greater than 0, if n%2>0, then n>0.
The second state edge case is actually the bace case for this recursion:
If we keep dividing this problem, at the end n would be 0, then we just return 1.
Also we need to handle the edge case when x is 0, we always return 0.

Time complexity: O(logn)  same as binary search


Solution3: Iterative Solution
Always think of how to conver a recursive solution to iterative solution.
For this problem, it's a little bit tricky.

First there is a special edge case:
if n is -2147483648 (the smallest 32 bits Integer), then Math.Abs(n) would cause
a runtime error. Because the largest 32 bits Integer is 2147483647. And -n would not
cause a runtime error, but -n is also -2147483648, the '-' operator would not convert
n to a positive number. 
So we cannot try to convert n to positive when n is a negative number, we must deal with 
n directly (not its absolute value of -n).

Through solution2, we know that this problem can be solved in Logn time using iterative method.
No matter n is positive or negative, the condition of while loop is while(n!=0), in each pass
we divide n by 2, then we can make sure the loop will be executed for logn times. 
Before the loop, we create a double res as 1 and use it to store the final result.
Now, in the loop, we cannot directly use the same code in the recursive method. Because the recursive
solution is a bottom-up method, and the iterative solution should be a top-down method. But the logic
is the same, we need to handle the situation when n%2!=0. So No matter what n%2 is, we always do x*=x,
if n&2>0 (n>0) we append current x to res by res*=x, and if n&2<0 (n<0), we append current x to res by
res/=x.

No matter what n is, eventually the last loop will occur when n is 1, and the intermediate result stored
in x will be append to res. Then whenever n%2>0, that means in this pass, the relationship changes. So 
we need to append an additional current x to res. (note it's append current x not original x)
*/

//Naive Approach(TLE): Time: O(n)
class Solution {
    public double Pow(double x, int n) {
        if(x==0) return 0;
        if(n==0) return 1;
        int temp = Math.Abs(n);
        double res=1;
        while(temp>0){
            if(n>0)
                res*=x;
            else
                res/=x;
            temp--;
        }
        return res;
    }
}


//Recursive Solution, Time: O(logn)
class Solution {
    public double Pow(double x, int n) {
        if(x==0) return 0; //edge case
        if(n==0) return 1; //Base case for Recursion
        
        double lastRes = Pow(x,n/2);
        int reminder = n%2;
        if(reminder==0)
            return lastRes*lastRes;
        else if(reminder>0)
            return lastRes*lastRes*x;
        else  //reminder <0, indicates n<0
            return lastRes*lastRes/x;
    }
    
}

//Iterative Solution, Time: O(logn)
class Solution {
    public double Pow(double x, int n) {
        if(x==0) return 0;
        if(n==0) return 1;
        double res = 1;
        while(n!=0){
           if(n%2>0)
                res*=x;
            if(n%2<0)
                res/=x;
            x*=x;
            n/=2;
        }
        return res;
    }
}

