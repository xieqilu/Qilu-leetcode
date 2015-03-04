/**
Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.

Example Questions Candidate Might Ask:
Q: Is the empty string valid?
A: Yes.


Solution:
To validate the parentheses, we need to match each closing parenthesis with its opening
counterpart. A Last-In-First-Out (LIFO) data structure such as stack is the perfect fit.

As we see an opening parenthesis, we push it onto the stack. On the other hand, when we
encounter a closing parenthesis, we pop the last inserted opening parenthesis from the
stack and check if the pair is a valid match.

It would be wise to avoid writing multiple if statements when matching parentheses, as
your interviewer may think that you are writing sloppy code. You could use a map, which
is more maintainable.

Note: It's definitely not wise to use a lot of if statements for this problem. We can simply
use a Dictionary to match the related opening and closing parenthesis together. It's a good 
use of Dictionary. And also if we want to change the matching rules, we can easily modify the
Dicitionary instead changing code of the method. That's a great trick, must remember it!
*/


public class Solution {
    public bool IsValid(string s) {
        Dictionary<char,char> dict = new Dictionary<char,char>(); //used to get matche parentheses
        dict.Add('(',')');
        dict.Add('{','}');
        dict.Add('[',']');
        
        Stack<char> stack = new Stack<char>();
        foreach(char c in s){
            if(dict.ContainsKey(c))
                stack.Push(c);
            else if(stack.Count==0 || dict[stack.Pop()]!=c)
                return false;
        }
        if(stack.Count==0)
            return true;
        return false;
    }
}
