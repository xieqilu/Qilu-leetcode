/**
Problem Statement

You are given a square map of size n×n. Each cell of the map has a value denoting its depth. We will call a cell of the map 
a cavity if and only if this cell is not on the border of the map and each cell adjacent to it has strictly smaller depth. 
Two cells are adjacent if they have a common side.

You need to find all the cavities on the map and depict them with the uppercase character X.

Input Format
The first line contains an integer, n, denoting the size of the map. Each of the following n lines contains n positive digits without spaces.
Each digit (1-9) denotes the depth of the appropriate area.

Constraints
1≤n≤100

Output Format
Output n lines, denoting the resulting map. Each cavity should be replaced with character X.

Sample Input
4
1112
1912
1892
1234
Sample Output
1112
1X12
18X2
1234


Solution:
This is a very simple problem, but there are some points to be noticed. The method is just traverse the whole map, if current
cell is a border cell, output its value. Then compare current cell with all four adjecent cells, if the value of current cell is
larger than all four adjecent cells, output "X". Otherwise output its value.

Note:
1, When parse the input and build a 2D int array (matrix), the line of input doesn't contain any space. So converse the line to
a char array using string.ToCharArray(), then map[i,j] = line[j]-'0'. Don't try to use int.Parse to convert a string array to int.
Think outside of the box.

2, Don't try to modify the value of the matrix then output the whole matrix. This will require an extra traverse which is not
efficient. Besides, we cannot change the value of an integer cell to "X", it's better to output the result when traversing the
matrix. Then we only need to traverse for once.
*/

using System;
using System.Collections.Generic;
using System.IO;

class Solution {
    public static void FindCavity(int[,] map, int size){
        for(int i=0;i<size;i++){
            for(int j=0;j<size;j++){
                if(i==0 || j==0 || i==size-1 || j==size-1)
                    Console.Write(map[i,j]);
                else if(map[i,j]>map[i-1,j]&&map[i,j]>map[i+1,j]&&map[i,j]>map[i,j+1]&&map[i,j]>map[i,j-1])
                    Console.Write("X");
                else
                    Console.Write(map[i,j]);
            }
            Console.WriteLine(); //start a new line
        }
    }
    
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int size = int.Parse(Console.ReadLine());
        int[,] map = new int[size,size];
        for(int i=0;i<size;i++){
            char[] line = Console.ReadLine().ToCharArray();
            for(int j=0;j<size;j++)
                map[i,j] = line[j]-'0';
        }
        FindCavity(map,size);
    }
}
