/**
Given two binary strings, return their sum (also a binary string).

For example,
a = "11"
b = "1"
Return "100".


Idea:
The method is pretty straightforward. But notice the two following points:
1, Make up '0' for shorter input string can greatly reduce code size, and is very importatn.
2, Sometimes we can build a result string by using char[] to get better time complexity than
using StringBuilder.

Detail steps:
1, Do make-up for the shorter input string. Add '0' to the head of shorter string to make the 
two input string have the same length.

2, Loop reversely of the two strings. Use an int carry to hold the extra value of each pass.
In each pass, caculate the sum of two current digits and carry. Then add sum%2 to the head of 
result string and then set carry as sum/2.

3, After the loop, check the value of carry to see if there is an extra digit in the result.
If carry is 1, add '1' to the head of result string. Return result.


Solution: 
We will need to use something to build the result string. If we use a StringBuilder, the method would
be very inefficient. Because we will build the result string reversely and insert digit to the head of
result string. If we use StringBuilder, then we will use StringBuilder.Insert() to repeatedly add digit,
which has a running time of O(n) because of shifting elements. Then the overall running time is O(n^2), 
which is very bad for this problem.

Thus we must use a char[] to solve this problem. 
We know that the result string will be at most one digit longer than the longer input string. 
And after the make-up step, both input strings have the same length. So we can create a char[] with length of
a.Length+1. Then in the loop, each pass we put the current result digit to char[i+1]. 
After the loop, we check carry. If carry is 1, then set char[0]='1' to add an additional '1' to the result
and return. If carry is 0, we don't need the first element of char[], so convert char[] to string and return
the Substring from the second char of result string.

The time complexity is O(n), much better than using a StringBuilder.

Time complexity: O(n)
*/




//Solution: My Solution, better than Leetcode official solution.  Time: O(n)
public class Solution {
    public string AddBinary(string a, string b) {
        int diff = Math.Abs(a.Length-b.Length);
        if(a.Length>b.Length){ //do Make-up for shorter input string!
            for(int i=0;i<diff;i++)
                b= "0"+b;
        }
        if(a.Length<b.Length){
            for(int i=0;i<diff;i++)
                a= "0"+a;
        }
        
        int carry = 0;
        char[] result = new char[a.Length+1];//result has at most one more digit than Max(a.Length,b.Length)
        for(int i=a.Length-1;i>=0;i--){
            int v1 = a[i]-'0', v2 = b[i]-'0';
            int temp = v1+v2+carry;
            result[i+1] = (char) (temp%2+'0'); //convert 1 to '1', 0 to '0'
            carry = temp/2; //carry could be 0 or 1
        }
        if(carry==1){ //if result has one more digit
            result[0] = '1';   
            return new string(result);
        } 
        return new string(result).Substring(1); //get rid of the extra digit of char array
    }
}
