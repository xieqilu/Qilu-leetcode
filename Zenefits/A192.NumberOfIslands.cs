/**
Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. 
An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
You may assume all four edges of the grid are all surrounded by water.

Example 1:

11110
11010
11000
00000

Answer: 1

Example 2:

11000
11000
00100
00011

Answer: 3


Idea:
This is a classic problem for Floodfill algorithm. Reference for floodfill is as follows:
http://en.wikipedia.org/wiki/Flood_fill

Based on the description, an island is formed by connected land and surrounded by water. So our task
is to find the number of component formed by connected '1' cells in the matrix. In other words, all connected
cells that are '1' can be considered as one land and find out how many lands in the matrix.

The idea is traverse the matrix, if the cell is '1', then use recursive DFS to search all adjecent cells and if
an adjecent cell is also '1', mark it as '0'. By marking adjecent cell as '0', we make sure that for each island, 
there is only one land('1') in it. Thus we won't detect a land twice. So after this process, the number of '1' is
the number of island.


Solution:
1, use count to store the number of islands. And traverse the matrix grid.
2, if grid[i][j] is '1', increment count, and call DFS method for (grid, i, j).
3, In the recursive DFS method:
3.1, Base case: 
    check if i or j is out of range (i<0 or j<0 or i>RowLength-1 or j>ColumnLength-1)
    if one of i and j is out of range, return.
3.2, If current cell is '1', set current cell as '0', call DFS method for all four adjecent cells around it.
    If current cell is not '1', do nothing and return.
    
Note: the key point is to identify the number of connected '1' in the matrix, the content of the matrix after
the process doesn't matter at all.

Time complexity: O(n*m)  n is the row length, m is the column length.
*/


public class Solution {
    public int NumIslands(char[][] grid) {
        int r = grid.Length;
        if(r==0) return 0; //edge case
        int c = grid[0].Length;
        if(c==0) return 0; //edge case
        
        int count=0;
        for(int i=0;i<r;i++){
            for(int j=0;j<c;j++){
                if(grid[i][j]=='1'){
                    count++;
                    DFS(grid,i,j);
                }
            }
        }
        return count;
    }
    
    //Recursive method to mark all connected '1' as '0', avoid future duplicate visit
    private void DFS(char[][] grid, int i, int j){
        int r = grid.Length;
        int c = grid[0].Length;
        //Base Case to stop recursion
        if(i<0 || j<0 || i>r-1 || j>c-1)
            return;
        if(grid[i][j]=='1'){ //visit all adjecent cells around '1' and mark '1' as '0'
            grid[i][j]='0';
            DFS(grid, i+1,j);
            DFS(grid, i-1,j);
            DFS(grid, i, j+1);
            DFS(grid, i, j-1);
        }
    }
}
