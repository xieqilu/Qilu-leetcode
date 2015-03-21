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

public class Solution {
    public string IntToRoman(int num) {
        string [,] table = new string[4,2]{
            {"I", "V"},
            {"X", "L"},
            {"C", "D"},
            {"M", " "}
        };
        int digit=0;
        string res="";
        while(num>0){
            int currNum = num%10;
            if(currNum>0&&currNum<=3){
                for(int i=0;i<currNum;i++)
                    res=table[digit,0]+res;
            }
            else if(currNum==4){
                res=table[digit,0]+table[digit,1]+res;
            }
            else if(currNum>4&&currNum<=8){
                for(int i=5;i<currNum;i++)
                    res=table[digit,0]+res;
                res=table[digit,1]+res;
            }
            else if(currNum==9)
                res=table[digit,0]+table[digit+1,0]+res;
            digit++;
            num/=10;
        }
        return res;
    }
}
