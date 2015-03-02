/**
Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

For example,
"A man, a plan, a canal: Panama" is a palindrome.
"race a car" is not a palindrome.

Note:
Have you consider that the string might be empty? This is a good question to ask during an interview.
For the purpose of this problem, we define empty string as valid palindrome.
*/

/**
Solution:
The idea is simple, have two pointers – one at the head while the other one at the tail.
Move them towards each other until they meet while skipping non-alphanumeric characters.
In the process, if at any step the two chars at two pointers are not same, return false.

To determine if a char is alphanumeric char, we use a private method to check if a char
is at the range ('A'-'Z') or ('a'-'z') or ('0'-'9'). Do not try to use ASCII number to set
the range, we cannot remember all the ASCII number but we can use char to set the range.

To check if an uppercase char is equal to an lowercase char, we have two approaches:

1, we can firstly convert all uppercase char in the string to lowercase char by using
string.ToLower() method. And then we can only consider lowercase char.

2, we can have a method IsSame to check if two chars are the same. If a==b or a-b=='A'-'a',
we consider a and b are the same.

Time Complexity: O(n)
Space Complexity: O(1)
*/

//Solution1: convert input string to lowercase, then check.
//we can just check if two char are the same withoug considering
//the uppercase char and the lowercase char
public class Solution {
    //Check is a char is alphanumeric char
    private bool IsAlphaNum(char a){
        //do not use ASCII number but use ASCII char to set the range!
        if((a<='9'&&a>='0')||(a<='z'&&a>='a'))
            return true;
        return false;
    }
    
    public bool IsPalindrome(string s) {
        if(s=="" || s==null) return true;
        s=s.ToLower();
        int first = 0;
        int last = s.Length-1;
        
        while(first<last){
            if(!IsAlphaNum(s[first])){
                first++;
                continue;
            }
            if(!IsAlphaNum(s[last])){
                last--;
                continue;
            }
            if(s[first]!=s[last])
                return false;
            else{
                first++;
                last--;
            }
        }
        return true;
    }
}

//Solution2: Do not convert input string to lowercase, add the range
//('A'-'Z') to IsAlphaNum and determine two chars are the same if 
//char a==char b or Math.Abs(a-b)==Math.Abs('a'-'A').
//use a private method to do this.
public class Solution {
    private bool IsSame(char a, char b){
        if(a==b || Math.Abs(a-b)==Math.Abs('a'-'A'))
            return true;
        return false;
    }
    
    //Check is a char is alphanumeric char
    private bool IsAlphaNum(char a){
        //do not use ASCII number but use ASCII char to set the range!
        if((a<='9'&&a>='0')||(a<='Z'&&a>='A')||(a<='z'&&a>='a'))
            return true;
        return false;
    }
    
    public bool IsPalindrome(string s) {
        if(s=="" || s==null) return true;
        s=s.ToLower();
        int first = 0;
        int last = s.Length-1;
        
        while(first<last){
            if(!IsAlphaNum(s[first])){
                first++;
                continue;
            }
            if(!IsAlphaNum(s[last])){
                last--;
                continue;
            }
            if(s[first]!=s[last])
                return false;
            else{
                first++;
                last--;
            }
        }
        return true;
    }
}
