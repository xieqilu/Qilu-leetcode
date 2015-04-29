/**
Given two strings s and t, determine if they are isomorphic.

Two strings are isomorphic if the characters in s can be replaced to get t.

All occurrences of a character must be replaced with another character while preserving the order of characters. No two characters may map to the same character but a character may map to itself.

For example,
Given "egg", "add", return true.

Given "foo", "bar", return false.

Given "paper", "title", return true.

Note:
You may assume both s and t have the same length.


Idea:
This is a clearly HashTable problem. We need to use HashTable to store the mapping relationship between chars in both
strings. We can conclude the mapping rules as follows:
1, A specific char in s cannot map to two different chars in t
2, Two different chars in s cannot map to a same char in t.
Basically, it's a two-way mapping rules, which means all char c in s must map to the same char k in t AND all char k 
in t must also map to the same char c in s. So we cannot only check the match from s to t, we need to check it both ways.

Then we know we must use two dictionary to store the mapping for both ways.

Edge case:
1, if s and t are both null, they are not isomorphic, return false
2, if s and t has different length, they cannot be isomorphic, return false
3, if s and t are the same, they must be isomorphic, return true.

Solution1: 
We can use two dicitionary (sdict and tdict) to implement a simple solution:
1, Traverse each char in s and t, if s[i] is not in sdict, put (s[i],t[i]) into sdict.
If t[i] is not in tdict, put (t[i], s[i]) into tdict.
2, Traverse each char in s and t again. If at any stage that sdict[s[i]]!=t[i] OR tdict[t[i]]!=s[i],
return false.

Basically we use the first traverse to construct the two dictionary, then use the second traverse to check
if there is any mismatch in s and t.

This solution is simple to implement and understand, but require two traverse which is not necessary.

Time complexity: O(n)  n is the length of s and t
Space: O(1), the chars that can be stored in dictionary are limited, like all chars in ASCII are limited.


Solution2:
We can modify the solution1 to avoid an additional traverse by checking the match in the first traverse as well as
add new mapping pairs into the two dictionary. When traversing s and t, for current char s[i] and t[i], there are 
totally three situations as follows:
1, s[i] and t[i] are both in their dictionary. Then we need to check the match, 
if sdict[s[i]]!=t[i] OR tdict[t[i]]!=s[i], return false.
2, s[i] and t[i] are both not in their dictionary. Then we need to add the two pairs into the two dictionary.
3, One of s[i] and t[i] is in the dictionary, the other is not. Then there must be a mismatch, so return false.

By spliting the above three situations in the traverse, we can solve the problem in one traverse.

Time complexity: O(n)   Space: O(1)


Solution3:
Assume s and t will only contain ASCII chars. we can use two array instead of two dictionary. The two array have 
the length of 256 and we can use the index as the key to store the mapping pair. It's always easier and more 
convenient to use array instead of dictionary. Other parts of the solution are identical to solution2.

Time complexity: O(n)  Space: O(1)

*/

//Solution1: Use two dictionary, two pass  Time: O(n)  Space: O(1)
public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if(s==null || t==null)
            return false;
        if(s.Length!=t.Length)
            return false;
        if(s==t)
            return true;
        Dictionary<char,char> sdict = new Dictionary<char,char>();
        Dictionary<char,char> tdict = new Dictionary<char,char>();
        for(int i=0;i<s.Length;i++){
            if(!sdict.ContainsKey(s[i]))
                sdict.Add(s[i],t[i]);
            if(!tdict.ContainsKey(t[i]))
                tdict.Add(t[i],s[i]);
        }
        
        for(int i=0;i<s.Length;i++){
            if(sdict[s[i]]!=t[i] || tdict[t[i]]!=s[i])
                return false;
        }
        return true;
    }
}


//Solution2: Use two dictionary, one pass  Time: O(n)  Space: O(1)
public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if(s==null || t==null)
            return false;
        if(s.Length!=t.Length)
            return false;
        if(s==t)
            return true;
        Dictionary<char,char> sdict = new Dictionary<char,char>();
        Dictionary<char,char> tdict = new Dictionary<char,char>();
        for(int i=0;i<s.Length;i++){
            //if s[i] and t[i] both are not in dicts, just add the pair to dicts
            if(!sdict.ContainsKey(s[i])&&!tdict.ContainsKey(t[i])){
                sdict.Add(s[i],t[i]);
                tdict.Add(t[i],s[i]);
            }
            //if s[i] and t[i] both are in the dict, check if they match each other
            else if(sdict.ContainsKey(s[i]) && tdict.ContainsKey(t[i])){
                if(sdict[s[i]]!=t[i] || tdict[t[i]]!=s[i])
                    return false;
            }
            else  //one of s[i] and t[i] is in the dict, and the other is not, return false
                return false;
        }
        return true;
    }
}


//Solution3: Use two array, one pass  Time: O(n)  Space: O(1)
public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if(s==null || t==null)
            return false;
        if(s.Length!=t.Length)
            return false;
        if(s==t)
            return true;
        //suppose s and t only contains ASCII chars, 0 is related to null char as initial value.
        int[] smap = new int[256]; 
        int[] tmap = new int[256];
        for(int i=0;i<s.Length;i++){
            if(smap[s[i]]==0 && tmap[t[i]]==0){ //s[i] and t[i] both are not in maps 
                smap[s[i]] = t[i];
                tmap[t[i]] = s[i];
            }
            else if (smap[s[i]]!=0 && tmap[t[i]]!=0){ //s[i] and t[i] both are in the maps, check if match
                if(smap[s[i]]!=t[i] || tmap[t[i]]!=s[i])
                    return false;
            }
            else  //one of s[i] and t[i] is in the map and the other not, must not match
                return false;
        }
        return true;
    }
}
