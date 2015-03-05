/**
All DNA is composed of a series of nucleotides abbreviated as A, C, G, and T, for example: "ACGAATTCCG". 
When studying DNA, it is sometimes useful to identify repeated sequences within the DNA.

Write a function to find all the 10-letter-long sequences (substrings) that occur more than once in a DNA molecule.

For example,

Given s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT",

Return:
["AAAAACCCCC", "CCCCCAAAAA"].



Solution:

MLE Solution:
We can easily get the idea of a direct solution: 
Use a HashMap, key is the substring, value is the number of appearence.
Iterate through all substring that has length of 10. For each 
substring, if is not in the HashMap, put it into the HashMap. And if it's already in the HashMap, then it's a repeated 
substring, increment the HashMap value.
Then we iterate through the HashMap, and for each substring that occurs more than once, put it into result list.

The runtime of above solution is O(n), which is the best we can do. But the above solution will use a lot of memory
space to store all the substrings, especially when there are a lot of substrings. So the above solution will be
Memory Limit exceed.

Accepted Solution:
The idea must be the same, but we need to use less memory space to solve it. We must not store all substrings in the
HashMap at all to avoid Memory Limit Exceed.
Then we need a way to convert the substring to number representation. Since the string can only contain for chars:
A,C,G,T. We can map each char to an int that has only two binary digit (00,01,10,11). Then we can convert each 
substring to an Integer. 
So for the HashMap, the key should be the Integer reprensentation of a substring and the value should be the ending
index of this substring. Suppose the ending index is i, then we can easily retrieve the substing as
s.Substring(i-9,10).

Details:
use a method int getHash(char) to conver char to int.
To append a char to a current hash representation: hash<<2|getHash(char).
shift hash to left by 2 digit and copy current int to the end.
To get rid of unnecessary digit of current hash: hash<<2 & 0x000FFFFF
shift hash to left by 2 and do AND with 000FFFFF, will only keep the lower 20 digits, which is the length of 
a DNA sequence.

If a hash doesn't exist in the HashMap, we set map[hash]=i, i is the ending index of current DNA sequence.
If a hahs exists in the HashMap, we retrive the substring and put it into result list. Then set map[hash]=-1.
So that we won't do duplicate comparison. (we don't need to know how many times a sequence appear, only need
to know if it appears more than once)

Time Complexity: O(n)
Space Complexity: will save a log of spaces
*/

public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s) {
        IList<string> result = new List<string>();
        if(s.Length<11)
            return result;
        Dictionary<int,int> dict = new Dictionary<int,int>();
        int hash=0;
        int i=0;
        while(i<10){
            hash=hash<<2 | ConvertHash(s[i]);
            i++;
        }
        dict[hash] = i-1; //i-1 must be 9
        while(i<s.Length){
            hash=(hash<<2 & 0x000FFFFF) | ConvertHash(s[i]);//get current hash
            if(!dict.ContainsKey(hash))
                dict.Add(hash, i);
            else{
                if(dict[hash]>-1){ //dict[hash] only used to check if the substring is added to result before
                    result.Add(s.Substring(i-9,10));
                    dict[hash] =-1;
                }
            }
            i++;
        }
        return result;
    }
    
    //convert char to int
    private int ConvertHash(char c){
        if(c=='A') return 0;
        if(c=='C') return 1;
        if(c=='G') return 2;
        else return 3;
    }
}
