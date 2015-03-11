/**
 * Compare two version numbers version1 and version2.
If version1 > version2 return 1, if version1 < version2 return -1, otherwise return 0.

You may assume that the version strings are non-empty and contain only digits and the . character.
The . character does not represent a decimal point and is used to separate number sequences.
For instance, 2.5 is not "two and a half" or "half way to version three", it is the fifth second-level revision of the second first-level revision.

Here is an example of version numbers ordering:

0.1 < 1.1 < 1.2 < 13.37



Solution1: my solution
Looks like a simple problem, but there are a lot of edge cases to consider.
Basic idea: split the input strings by "." to get each part of number. 
Then compare each part of the two versions, if at any stage, v1[i]>v2[j] return 1;
if v1[i]<v2[j] return -1; After the while loop, if no rest part for both versions,
return 0. If v1 has an additional part, return 1, if v2 has an additional part, return -1.

Edge cases:
After the while loop, if one version has an additional part of number but the number is 0,
then the two versions are considered equal. We need to return 0. Like "1.0" and "1" are equal.
So after the while loop, check if additional parts of the longer version are all 0, if any part
is not 0, return 1 if version1 is longer or -1 if version2 is longer. We do not know which version
is longer after the while loop but we know that only one version has additional parts. So we use
two while loops to check for version1 and version2 and return accordingly. If after the two while
loop still not return, then two versions must be equal, return 0.


Solution2: Leetcode official solution
This is a beautiful and elegant solution! It handles all the above edge cases using one simple method.
Notice that all the above edge cases are because of different number of parts for two versions. So we can
match the missing part for the shorter version in the while loop to handle all edge cases. In the while
loop, if i==v1.length, just set curr1 = 0. if i==v2.length, just set curr2=0, until i is equal to the length
of the longer version. In other words, we use 0 to represent the missing part of the shorter version.
Then for example: "1.0.0.1" and "1.0"
we will compare 1 and 1, then 0 and 0, then 0 and 0, then 1 and 0. Finally we will find that "1.0.0.1" is 
larger than "1.0".
*/

//Solution1: My solution
public class Solution {
    public int CompareVersion(string version1, string version2) {
        string[] v1 = version1.Split('.'); //note must use regular expression to split string
        string[] v2 = version2.Split('.');
        int i=0, j=0;
        while(i<v1.Length&&j<v2.Length){ //compare each part of two versions
            if(int.Parse(v1[i])>int.Parse(v2[j]))
                return 1;
            else if(int.Parse(v1[i])<int.Parse(v2[j]))
                return -1;
            i++;
            j++;
        }
        //if i==v1.length, the loop won't be executed.
        while(i!=v1.Length){
            if(int.Parse(v1[i])!=0) return 1; //if any part is not 0, then v1>v2
            i++;
        }
        //if j==v2.length, the loop won't be executed.
        while(j!=v2.Length){
            if(int.Parse(v2[j])!=0) return -1; //if any part is not 0, then v2>v1
            j++;
        }
        return 0;
    }
}


//Solution2: Leetcode Official Solution
public class Solution {
    public int CompareVersion(string version1, string version2) {
        string[] v1 = version1.Split('.');
        string[] v2 = version2.Split('.');
        int i=0;
        while(i<v1.Length||i<v2.Length){
            int num1 = i<v1.Length? int.Parse(v1[i]) : 0;
            int num2 = i<v2.Length? int.Parse(v2[i]) : 0;
            if(num1>num2) return 1;
            else if(num1<num2) return -1;
            i++;
        }
        return 0;
    }
}
