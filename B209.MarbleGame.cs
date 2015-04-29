/**
You are playing game, where you are expected to keep a SINGLE marble on 2 dimension grid. 
The grid already has some marbles present.  There are 2 basic rules to keep the marble at a particular location X,Y

The location X, Y should be empty
You can keep a marble at a particular location (X,Y), only if there is at least 1 marble to the North 
(i.e., with the same x coordinate and a greater y coordinate), at least 1 marble to the South  (i.e., with the same x coordinate and a lesser y coordinate), 
at least 1 marble to the East (i.e., with a lesser x coordinate and the same y coordinate) and at least 1 marble to the West 
(i.e., with a greater x coordinate and the same y coordinate). 
The bottom left grid is marked as (0, 0).Edge locations , where there aren’t 4 possible sides aren’t considered valid positions to keep the marble.
Given a board configuration, print the maximum number of places where you can keep a new marble.

Input Format: 
First line has two integer N and K. N is the size of the NxN grid and K is the number of marbles already present in the grid. 
K lines follow, in which each line has 2 integers X and Y. (X, Y) is the position of the marble present. 

Output Format: 
One integer which is the total number of places where you can keep a marble. 
Limits. 
N <= 1000. K <= N*N
Example.Example to above Test Case
6 9
0 2
1 1
1 5
2 0
2 2
2 5
4 0
4 2
5 1

Output:
3

Explanation:
In the following diagram, the black marbles are the places where marbles are present already 
and blue ones are the list of places where you can place a new marble. 

Example 2
Input:
2 4
0 0
0 1
1 0
1 1

Output:
0

Explanation: 
This is a 2×2 grid, in which all 4 positions are already occupied. You can’t keep any more marbles in this grid.


Idea:
This is a very good problem. The brute force approach is obvious, for each cell in the board, we look for all the four 
directions to check if there is at least one marble in each direction. But this would take us O(n^3) running time， whcih
is not efficient. So we need a better approach.

So what kind of information do we need to find all the cell that can be placed new marble? We need to find the longest
distance between two existing marbles on each row and column. Then store the positions of these two marbles.
If there is less than two marbles on a row or column, then all  empty places on this row or column cannot be a qulified cell, 
because at least one direction has no marble. 
After that, we just need to use the above information to find intersections of qulified rows and columns. And if the qualified
cell is empty, we can put a marble on it.

For example:
If for row#2, we know the two marbles that have longest distance are (1,2) and (1,6). Then for all columns between y=3 and y=5,
we check if 1 is in the range of the two x coordinates of that column. If for y=3, the two marbles are (0,3) and (4,3), then 
because 1 is between 0 and 4, we get an intersection which is (1,3). Then if there is no existing marble on (1,3), we can put a
new cell on (1,3).


Solution:
Implement the above idea as follows:
1, Use two N*2 array to store positions of the two longest distanced marbles for each row and column.
2, In the X array, X[i][0] and X[i][1] store the y coordinates of the two marbles on the ith column.
The two positions are: (i,X[i][0]) and (i,X[i][1]).
3, In the Y array, Y[j][0] and Y[j][1] stores the x coordinates of the two marbles on the jth row.
The two positions are" (Y[j][0], j) and (Y[j][0], j).
4, Traverse the board and construct the X and Y array. We can do this in one pass because for each pair of i and j, we can
check two positions: (i,j) and (j,i). The initial value of X[i][0] is N and X[i][1] is -1 in case of there is less than two
existing marbles on this column. The same as Y array.
5, Then traverse X array, check X[i,0] and X[i,1], if there is less than two marbles, continue.
6, Then traverse j from X[i][0]+1 to X[i][1]-1, for each j, check Y[j,0] and Y[j,1]. If Y[j] has less than two marbles, continue.
7, Then check if i is between Y[j][0] and Y[j][1],if it is then  means the column and row has a intersection and 
there is no existing marble on position (i,j), then we find a qualified cell and res++. 
8, After the above work, return res.

Time complexity: O(n^2)   Space: O(n)

Construct the X and Y array: O(n^2)   Traverse the X and Y array to find intersection: O(n^2)
Overall: O(n^2)
And the space of X and Y array is O(2n) = O(n)
*/

//Solution:
using System;
using System.Linq;

namespace Solution {
    class Solution {
        //find number of positions to put new marble
        static int GetNumOfMarble(bool[,] board, int size){ 
            int[,] X = new int[size,2]; 
            int[,] Y = new int[size,2]; 
            
            for(int i=0;i<size;i++){
                int maxY=-1, minY=size, maxX=-1, minX=size;
                for(int j=0;j<size;j++){
                    if(board[i,j]==true){
                        maxY=Math.Max(maxY,j); //update maxY and minY
                        minY=Math.Min(minY,j);
                    }
                    if(board[j,i]==true){
                        maxX=Math.Max(maxX,j); //update maxX and minX
                        minX=Math.Min(minX,j);
                    }
                }
                X[i,0]=minY;
                X[i,1]=maxY;
                Y[i,0]=minX;
                Y[i,1]=maxX;
            }
            int res = 0;
            for(int i=0;i<size;i++){
                if(X[i,0]==size || X[i,0]==X[i,1]) //no marbles or only one marble for this i
                    continue;
                for(int j=X[i,0]+1;j<X[i,1];j++){  //only check j between x[i,0]+1 and x[i,1]-1, inclusive
                    if(Y[j,0]==size || Y[j,0]==Y[j,1]) //no marbles or only one marble for this j
                        continue;
                    if(i>=Y[j,0]&&i<=Y[j,1]&&board[i,j]!=true) //if there is intersection and it's empty
                        res++;
                }
            }
            return res;           
        }
        //Parse STDIN
        static int[] ParseInput(string line){
            string[] input = line.Split();
            int[] nums = input.Select(y=>int.Parse(y)).ToArray();
            return nums;
        }
        
        static void Main(string[] args) {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            int[] firstLine = ParseInput(Console.ReadLine());
            int size = firstLine[0], numMarble = firstLine[1];
            bool[,] board = new bool[size,size];
            for(int i=0;i<numMarble;i++){
                int[] position = ParseInput(Console.ReadLine());
                board[position[0],position[1]] = true; //true means this position has marble
            }
            Console.WriteLine(GetNumOfMarble(board, size));
        }
    }
}


