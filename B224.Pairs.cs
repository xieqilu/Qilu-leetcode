/**
Problem Statement

Given N integers, count the number of pairs of integers whose difference is K.

Input Format 
The first line contains N and K. 
The second line contains N numbers of the set. All the N numbers are unique.

Output Format 
An integer that tells the number of pairs of integers whose difference is K.

Constraints: 
N≤105 
0<K<109 
Each integer will be greater than 0 and at least K smaller than 231−1.

Sample Input #00:

5 2  
1 5 3 4 2  
Sample Output #00:

3
Sample Input #01:

10 1  
363374326 364147530 61825163 1073065718 1281246024 1399469912 428047635 491595254 879792181 1069262793 
Sample Output #01:

0


Solution:
This problem is very similiar to Two Sum. But we need to be careful to not count a same pair twice. The method is traverse
the int array, for each integer i, check if i-k is in the hashset, if it is, increment count. Then check if i+k is in the 
hashset, if it is, increment count. Then add i to hashset. Because the elements of input array is unique, so we don't need
to worry about duplicate element. By using this method, we will count each pair only once, so the result is correct.

Time complexity: O(n) n is the size of input array
*/

using System;
using System.Collections.Generic;
using System.IO;
class Solution {
/* Head ends here */
static int pairs(int[] a, int k) {
    HashSet<int> dict = new HashSet<int>();
    int count = 0;
    foreach(int i in a){
        if(dict.Contains(i-k))
            count++;
        if(dict.Contains(i+k))
            count++;
        dict.Add(i);
    }
    return count;
    }
/* Tail starts here */
static void Main(String[] args) {
        int res;
        
        String line = Console.ReadLine();
        String[] line_split = line.Split(' ');
        int _a_size = Convert.ToInt32(line_split[0]);
        int _k = Convert.ToInt32(line_split[1]);
        int[] _a = new int [_a_size];
        int _a_item;
        String move = Console.ReadLine();
        String[] move_split = move.Split(' ');
        for(int _a_i = 0; _a_i < move_split.Length; _a_i++) {
            _a_item = Convert.ToInt32(move_split[_a_i]);
            _a[_a_i] = _a_item;
        }
        
        res = pairs(_a,_k);
        Console.WriteLine(res);
        
    }
}

