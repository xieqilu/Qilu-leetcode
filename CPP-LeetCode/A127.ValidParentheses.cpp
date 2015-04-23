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

//Driver Code
int main() {
    ofstream fout("user.out");
    string line;
    while (getline(cin, line)) { //read input line from STDIN
        string s = line.substr(1, line.length() - 2); //get substring
        fout << __Serializer__::serialize(Solution().isValid(s)) << endl;
    }
    return 0;
}

//Print Input Code:
int main() {
  string s;
  while (getline(cin, s)) {
    cout << s << endl; //print using STDOUT
  }

  return 0;
}


//Solution1: Better and Clean Solution
class Solution {
public:
    bool isValid(string s) {
        unordered_map<char,char> map;
        map.emplace('(',')');
        map.emplace('{','}');
        map.emplace('[',']');
        
        stack<char> st;
        int n = s.length();
        for(int i=0;i<n;i++){
            if(map.count(s[i])>0){
                st.push(s[i]);
            }
            else{
                //in c++, st.pop() doesn't return the top item, so must use st.top()
                //to get the top item from stack first.
                if(st.empty() || map[st.top()]!=s[i]){ 
                    return false;
                }
                st.pop(); //then pop from the stack
            }
        }
        return st.empty();
    }
};


//Solution2: has some sloppy code, but also work fine
class Solution {
public:
    bool isOpen(char c) {
        return c == '[' || c == '{' || c == '(';
    }
    char getMatchOpen(char c) {
        switch (c) {
            case ']':
                return '[';
            case '}':
                return '{';
            case ')':
                return '(';
        }
        return '\0';        
    }
    bool isValid(string s) {
        stack<char> st;
        int n = s.length();
        for (int i = 0; i < n; i++) {
            if (isOpen(s[i])) {
                st.push(s[i]);
            } else {
                if (st.empty() || st.top() != getMatchOpen(s[i])) {
                    return false;
                }
                st.pop();
            }
        }
        return st.empty();
    }
};
