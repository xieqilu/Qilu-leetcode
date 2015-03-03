/**
Given two words word1 and word2, find the minimum number of steps required to convert word1 to word2.
(each operation is counted as 1 step.)

You have the following 3 operations permitted on a word:

a) Insert a character
b) Delete a character
c) Replace a character
*/

/**
Solution:
This is a very classic Dynamic Programming problem, the solution is Brilliant!

Assume that dp[i,j] is the minimum edit distance of word1.Substring(0,i) and 
word2.Substring(0,j).(first i chars of word1 and first j chars of word2, Note
that dp[i,j] is related to word1[i-1] and word2[j-1]). Then if we want to know
the value of dp[i,j], we can get the value from previous dp values. 

We have the following situations:
1, word1[i-1] is the same as word2[j-1]. Then we don't need to do any operation.
So dp[i,j] = dp[i-1,j-1].

2, word1[i-1] is not the same as word2[j-1]. Then from the problem description,
we can do the following three operation to convert word1.Substring(0,i) to
word2.Substring(0,j):
2.1, we can replace a char to convert word1.Substring(0,i) to word2.Substring(0,j).
Then dp[i,j] = dp[i-1,j-1]+1
2.2, we can insert a char to convert word1.Substring(0,i-1) to word2.Substring(0,j).
Then dp[i,j] = dp[i-1,j]+1
2.3, we can delete a char to convert word1.Substring(0,i) to word2.Substring(0,j-1).
Then dp[i,j] = dp[i,j-1]+1
And for each i and j, we need to make the best decision (use minimum edit distance) 
to convert word1.Substring(0,i) to word2.Substring(0,j). 
So dp[i,j] = minimum of (dp[i-1,j]+1, dp[i,j-1]+1, dp[i-1,j-1]+1)

The detail implemention is suprisingly simple and elegant. We use a 2D array dp to 
keep track of value for dp[i,j] as above. And we initialize dp[i,0]=i and dp[o,j]=j.
Then use a nested loop to iterate through all chars of word1 and word2. For each i
and j, do the operation as stated above.

Time Complexity: O(n*m) n is the size of word1, m is the size of word2
In the whole process, we need to fill a matrix with the size of (n+1)*(m+1)
and we will only fill each cell once. So the time complexity is O(n*m).

Space Complexity: O(n*m) the size of the matrix
*/

/**
Special Note:
In C#, Multidimension Array and Jagged Array are different. The constructor
are also different.

Multidimension 2D Array:
int[,] array = new int[a,b] will create a a*b multidimension array. We can specify
the size of row and column in the constructor. And each row will have the same 
length. To access the array, we must use both i and j as indices to get an element.

Jagged 2D Array:
int[][] array = new int[a][] will create a 2D multidimension array. We cannot specify
the size of column in the constructor. In fact, what we create is actually a 1D array
in which each element is also an array. So each row can have different length since
each element of the 1D array is also an array with possible different length.
To further initiliaze the jagged array:
array[0] = new int[b], array[1]= new int[c];
for(i=0;i<array.Length;i++) array[i]=new int[d];

To solve this problem, we'd better to use a uniform Multidimension 2D array.

In Java, the synatx for Multidimension Array and Jagged Array are more similiar, but the
difference between them is the same as in C#.
*/

public class Solution {
    public int MinDistance(string word1, string word2) {
        int len1 = word1.Length, len2 = word2.Length;
        //the value of dp[i,j] means minimum edit distance of
        //word1.Substring(0,i) and word2.Substring(0,j)
        int[,] dp = new int[len1+1,len2+2]; 
        //Base case: dp[i,0]=i, dp[0,j]=j
        for(int i=0;i<len1+1;i++){
            dp[i,0] = i;
        }
        for(int j=0;j<len2+1;j++){
            dp[0,j] = j;
        }
        
        //Use nested for loop to iterate through two strings
        //Note: dp[i,j] is related to word1[i-1] and word2[j-1]
        //So strat from i=1 to i<len+1, j=1 to j<len2+1
        for(int i=1;i<len1+1;i++){
            for(int j=1;j<len2+1;j++){
                if(word1[i-1]==word2[j-1])
                    dp[i,j] = dp[i-1,j-1];
                else{  //if word1[i-1]!=word2[j-1]
                    //dp[i,j] = minimum of (dp[i-1,j]+1, dp[i,j-1]+1, dp[i-1,j-1]+1)
                    dp[i,j] = Math.Min(Math.Min(dp[i-1,j]+1, dp[i,j-1]+1), dp[i-1,j-1]+1);
                }
            }
        }
        return dp[len1,len2];
    }
}
