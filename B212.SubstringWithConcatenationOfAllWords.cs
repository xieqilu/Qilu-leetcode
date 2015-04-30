/**
You are given a string, s, and a list of words, words, that are all of the same length.
Find all starting indices of substring(s) in s that is a concatenation of each word in words exactly once 
and without any intervening characters.

For example, given:
s: "barfoothefoobarman"
words: ["foo", "bar"]

You should return the indices: [0,9].
(order does not matter).


Idea:
This problem is a typical Sliding Window problem. The approach is quite similiar to Minimum Window Substrings.
For fast look up, we need to use a dictionary to store the identity of the target string array words. Note that 
the order of words doesn't matter which enables us to use dictionary.Then use i (like begin pointer) to traverse 
each char in s, for each i, use j (like end pointer) starting from i, check if current word matches a word in words.
If it match, then forward j to check next word. If the length of current substring is equal to the total length of words,
stop checking and save i to result. If there is no match starting from current i, increment i and start the next round of
checking.


Solution:
Detailed steps are as follows:
1, Construct the dictionary according to words array.
2, Use i to traverse s from 0 to s.Length-len*wlen. (wlen is the length of words array, len is the length of a single word)
3, For each i, first copy the original dictionary, because we will modify it in this pass and the original one will be used
again for next pass.
4, Use j starting from i, while j<=s.Length-len, since if j>s.Length-len, no enough chars to match a single word.
5, for each j, get current word by substring(j, len). Then if this word is not in the dictionary OR the value of this word
is 0 (means no more this word need to be matched), break the inner while loop.
6, If the current word matches in the dictionary, decrement the dictionary value. And check if we already have enough
chars to match the whole words array (if j+len-i==len*wlen). If it is, add current i to result list and break inner loop.
If it's not, update j as j+=len to continue checking next word.
7, the outter loop will increment i to check for next begin index.

Time complexity: O(n), O(n*wlen)
The outter for loop will run for n-len*wlen times, the inner while loop will run at most wlen times. So the overall
time complexity is (n-len*wlen)*wlen = O(n*wlen), if we consider len and wlen are small constant value, the time complexity
would be O(n), n is the length of string s.

Or we can see the running time this way:
Since the length of a single word is len, then the start index of a word can have (n-len) options. So totally there are
(n-len) possible words. Then by using this approach, a single word can be visited at most twice, it can be visited as the
first word from i and a word in a substring starting from previous i. Thus the running time would be 2*(n-len), O(n). 

Space complexity: O(len*wlen), since we need to store words array into the dictionary.
*/


//Solution:  Time: O(n)  Space: O(l*wl)
public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
        IList<int> res = new List<int>();
        //construct a dictionary that identify words array
        Dictionary<string,int> dict = new Dictionary<string,int>();
        foreach(string str in words){
            if(!dict.ContainsKey(str))
                dict.Add(str,1);
            else
                dict[str]++;
        }
        
        int len = words[0].Length; //the length of each word in words
        int wlen = words.Length; //the length of words array
        for(int i=0;i<=s.Length-len*wlen;i++){  //if i>s.Length-len*wlen, no enough chars to match words
            //when starting a new matching process, copy the original dictionary
            Dictionary<string, int> currDict = new Dictionary<string,int>(dict);
            int j = i;
            while(j<=s.Length-len){  //if j >s.Length-len, no enough chars to match a single word in words
                string currWord = s.Substring(j,len);
                //if current word is not in dict OR no more current word need to be matched, then no match
                if(!currDict.ContainsKey(currWord) || currDict[currWord]==0)  
                    break;
                currDict[currWord]--;
                //if length of current substring is equal to length of all words, we find a match substring
                if(j+len-i==wlen*len){ 
                    res.Add(i);
                    break;
                }
                j+=len; //update j to try next word
            }
        }
        return res;
    }
}
