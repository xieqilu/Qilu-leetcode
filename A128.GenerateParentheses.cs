/**
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

For example, given n = 3, a solution set is:

"((()))", "(()())", "(())()", "()(())", "()()()"


Solution:
This is a very classic Recursion and Dynamic Programming Problem.
We can use a recursive DFS method to solve this problem.

Idea:
we can build all the valid strings from scratch. That is, we build all
strings by inserting left paren and right paren one by one.

Note three things:
1, the length of a valid string must be 2n, n is the number of left paren 
and right paren we can use.
2, In each position of the string, we have two options: insert a left paren
or insert a right paren as long as the string stays valid.
3, In all substrings of a valid string, the number of right paren cannot be 
more than the number of left paren.

So each time in the recursive method, we will insert a left paren and a right 
paren as long as the string is valid then continue the recursive call to finally
build all valid strings.

Then we need to know when we can insert a left paren and when we can insert a right
paren? That's the key point to solve this problem and reduce unnecessary recursive calls.
1, Left Paren: As long as we haven't used up all left parentheses, we can always insert
a left paren.
2, Right Paren: If the current number of right paren is less than left paren, we can insert
a right paren. Since in any substring of a valid string the number of right paren must be no
more than left paren. If currently the number of right paren is equal to left paren, we cannot
insert a right paren. Because it will lead an invalid substring.
In other words, if after inserting a right paren, right parens are not more than left parens,
then we can insert a right paren.

Know the above information, we can easily come up with the following method:
In the recursive method, we need to know the total number n, current number of left and right paren,
current string and the result List of strings.

Base case: current number of left and right paren are both n, then we already got a valid string. We 
just need to put the string into List and return.

Otherwise, we insert left and right paren to the current string recursivelly if the string will stay
valid. If number of left paren is less than n, we can insert left paren. If number of right paren
is less than left paren, we can insert right paren.

Time complexity: O(n^2)
*/

//Recursive DFS solution
public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        IList<string> result = new List<string>();
        string s="";
        DFS(n, 0, 0, s, result);
        return result;
    }
    //Recursive DFS method to add '(' and ')' to s
    private void DFS(int n, int leftNum, int rightNum, string s, IList<string> result){
        if(leftNum == rightNum && leftNum==n){
            result.Add(s);
            return;
        }
        if(leftNum<n)
            DFS(n,leftNum+1, rightNum, s+"(", result);
        if(rightNum<leftNum)
            DFS(n,leftNum, rightNum+1, s+")", result);
    }
}


