/**
The count-and-say sequence is the sequence of integers beginning as follows:
1, 11, 21, 1211, 111221, ...

1 is read off as "one 1" or 11.
11 is read off as "two 1s" or 21.
21 is read off as "one 2, then one 1" or 1211.
Given an integer n, generate the nth sequence.

Note: The sequence of integers will be represented as a string.


Idea:
The key point is to fully understand the meaning of the problem. 
For each n, look at string at n-1 and write the number of times a digit is concecutively seen and the
digit itself.
Base case: n=1, "1"
When n=1, read previous string, there is one of 1, so "11"
When n=2, read previous string, there is two of 1, so "21"
When n=3, read previous string, there is one of 2 and one of 1, so "1211"
When n=4, read previous string, there is one of 1, one of 2, and two of 1, so "111221"
.....

Solution1: Recursive
A very typical recursive problem, the string for n relied purely on the string of n-1.
So if we got string of n-1, we can iterate it and count each part of concecutive chars
and then construct string of n.
Base case: when n is 1, return "1".


Solution2: Iterative
It's also very easy to convert the recurisve solution to iterative solution.
We just need an extra Integer to control how many times the while loop would be
executed. If the input is k, then we need to construct the result from n=1 to n=k.
So the while loop should be executed (k-1) times. Set int round =1, the condition
is while round<k. Each time after the execution, increment round and update the 
string holding the result of current pass.
*/


//Solution1: Recursive Solution
public class Solution {
    public string CountAndSay(int n) {
        if(n==1) return "1";
        string temp = CountAndSay(n-1);
        int count=1;
        char previous = temp[0];
        StringBuilder sb = new StringBuilder();
        for(int i=1;i<temp.Length;i++){
            if(temp[i]==previous)
                count++;
            else{
                sb.Append(count);
                sb.Append(previous);
                count=1;
                previous=temp[i];
            }
        }
        sb.Append(count);
        sb.Append(previous);
        return sb.ToString();
    }
}

//Solution2: Iterative Solution
public class Solution {
    public string CountAndSay(int n) {
        int round = 1;
        string res = "1"; //when n is 1, string is "1"
        while(round<n){
            StringBuilder sb = new StringBuilder();
            int count = 1;
            char previous = res[0];
            for(int i=1;i<res.Length;i++){
                if(res[i]==previous)
                    count++;
                else{
                    sb.Append(count);
                    sb.Append(previous);
                    count=1;
                    previous=res[i];
                }
            }
            sb.Append(count);
            sb.Append(previous);
            res = sb.ToString();
            round++;
        }
        return res;
    }
}


