/**
Given a roman numeral, convert it to an integer.

Input is guaranteed to be within the range from 1 to 3999.


Idea:
The logic behind this problem is simple and straightforward, all we need to know is the 
rules of Roman number.

The chinese version of Roman number rules is as follows:

罗马数字有如下符号：
基本字符	    I	V	X	L	C	D	M
对应阿拉伯数字	1	5	10	50	100	500	1000

计数规则：
1，相同的数字连写，所表示的数等于这些数字相加得到的数，例如：III = 3
2，小的数字在大的数字右边，所表示的数等于这些数字相加得到的数，例如：VIII = 8
3，小的数字，限于（I、X和C）在大的数字左边，所表示的数等于大数减去小数所得的数，例如：IV = 4
4，正常使用时，连续的数字重复不得超过三次
5，在一个数的上面画横线，表示这个数扩大1000倍（本题只考虑3999以内的数，所以用不到这条规则）

其次，罗马数字转阿拉伯数字规则（仅限于3999以内）：
从前向后遍历罗马数字，如果某个数比前一个数小，则加上该数。反之，减去前一个数的两倍然后加上该数


Solution:
First we need to map the basic Roman digit to related numbers. The most convenient way is to use
an array with length of 256. And use 'I','V','X','L','C','D','M' as the index, use related numbers
as value to build a mapping table. Then we can use table['I'] to get the number related to 'I'.

Then we can set an int prev to keep track of the previous char, use int total to store result.
Iterate the string, for each current char, if it's greater than prev, add curr-2*prev to total.
Otherwise, add curr to total. After the iteration, return total.

Special Note: 
we can set the initial value of prev as 0, then iterate the string from first char.
Then no matter what the first char is, it must be greater than 0, after first operation,
the first char will be added to total and prev will be updated to first char.

Or we can set the initial value of prev and total as first char, then start iteration from
the second char of string.
*/

//Driver Code
int main() {
    ofstream fout("user.out");
    string line;
    while (getline(cin, line)) {
        
        string param_1 = __Deserializer__::toString(line);
        
        fout << __Serializer__::serialize(Solution().romanToInt(
            param_1
        )) << endl;
    }
    return 0;
}

//Print Input Lines
int main() {
  string s;
  while (getline(cin, s)) {
    cout << s << endl;
  }

  return 0;
}


//Solution Code
class Solution {
public:
    int table[256];
    Solution() {
        for (int i = 0; i < 256; i++)
            table[i] = 0;
        table['I'] = 1; table['V'] = 5; 
        table['X'] = 10; table['L'] = 50; 
        table['C'] = 100; table['D'] = 500; 
        table['M'] = 1000;
    }
    int romanToInt(string s) {
        int n = s.length();
        int prev = 0;
        int total = 0;
        for (int i = 0; i < n; i++) {
            int curr = table[s[i]];
            if (curr > prev) {
                total += curr - 2*prev;
            } else {
                total += curr;
            }
            prev = curr;
        }
        return total;
    }
}; //Note there must be a ";" to end C++ class
