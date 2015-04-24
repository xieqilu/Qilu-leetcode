/**
Given an integer, convert it to a roman numeral.

Input is guaranteed to be within the range from 1 to 3999.


Idea:
This problem is a little harder than Roman to Integer. The key point is also knowing the mapping
rules from regular numbers to Roman numbers. The basic Roman letter to number map is the same:
I = 1; II=2; III=3; IV=4;
V = 5; VI=6; VII=7; VIII=8; IX=9;
X = 10;
L = 50;
C = 100;
D = 500;
M = 1000;

Notice that for the number like 4, 9, 40, 90, we need to use minus format. For example, IV is 
V-I=5-1=4; And IX=X-I=10-1=9. And because the input num is between 1 to 3999, and the Roman 
string is an add-up number, which means we can add all parts of Roman string together to get the
value of entire number. So the Roman string should at most contain four parts: 1-9, 10-90, 100-900, 1000-3000.
Then in each pass, we get the last digit of input num and convert it directly to Roman string using
the above rules and add it to result string. Then update num/=10.

Solution:  
We will need a two-diminsion array to store the Roman letters used to build Roman string for each digit
of the input num (there are at most four digits). The table is as follows: (each part is a row)
digit 0-9 : I, V
digit 10-90: X, L
digit 100-900: C, D
digit 1000-3000: M

Then we use an int digit to indicate the current digit we are dealing with. And use num%10 to get the current
digit (n). Then we have totally five situations:
If n==0, don't add anything to result.
If 0<n<4, add n first letter of current digit to result.
If n==4, add a first letter and a second letter of current digit to result.
If 4<n<9, add a second letter and n-5 first letter of current digit to result.
If n==9, add a first letter of current digit and a first letter of next digit to result.
Then we update num as num/=10 and increment digit and repeat the above process until num==0.

Note: Since we build the Roman string from small digit to large digit, every time we add a new digit string
to the result string, we need to add it in front of the current result string.
*/

//Solution Code
class Solution {
public:
    string intToRoman(int num) {
        const string roman[][10] = {
            {"I", "V"},
            {"X", "L"},
            {"C", "D"},
            {"M"}
        };
        int digits = 0;
        string r;
        while (num > 0) {
            int dig = num%10;
            if (dig == 0) {
            } else if (dig <= 3) {
                for (int i = 0; i < dig; i++)
                    r = roman[digits][0] + r;
            } else if (dig == 4) {
                r = roman[digits][0] + roman[digits][1] + r;
            } else if (dig <= 8) {
                string temp = roman[digits][1];
                for (int i = 5; i < dig; i++)
                    temp += roman[digits][0];
                r = temp + r;
            } else if (dig == 9) {
                r = roman[digits][0] + roman[digits+1][0] + r;
            }
            digits++;
            num /= 10;
        }
        return r;
    }
};

//Driver Code
int main() {
    ofstream fout("user.out");
    string line;
    while (getline(cin, line)) {
        
        int param_1 = __Deserializer__::toInteger(line);
        
        fout << __Serializer__::serialize(Solution().intToRoman(
            param_1
        )) << endl;
    }
    return 0;
}

//Print Input Code
// Insert input formatter code here...
int main() {
  int i;
  while (cin >> i) {
    cout << __Serializer__::serialize(i) << endl;
  }
}
